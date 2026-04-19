using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Tip.TransactionStandard.Validation;

public static class TipValidator
{
    public static IReadOnlyList<TipValidationIssue> ValidateObject<T>(T instance)
    {
        ArgumentNullException.ThrowIfNull(instance);

        var issues = new List<TipValidationIssue>();
        ValidateRecursive(instance!, typeof(T).Name, issues);
        return issues;
    }

    public static bool TryValidateObject<T>(T instance, out IReadOnlyList<TipValidationIssue> issues)
    {
        issues = ValidateObject(instance);
        return issues.Count == 0;
    }

    private static void ValidateRecursive(object instance, string path, ICollection<TipValidationIssue> issues)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(instance, new ValidationContext(instance), results, validateAllProperties: true);

        foreach (var result in results)
        {
            var members = result.MemberNames?.Any() == true ? result.MemberNames : [string.Empty];
            foreach (var member in members)
            {
                var issuePath = string.IsNullOrWhiteSpace(member) ? path : path.Append(member);
                issues.Add(new TipValidationIssue(issuePath, result.ErrorMessage ?? "Validation failed."));
            }
        }

        if (instance is ITipValidatable custom)
        {
            foreach (var issue in custom.Validate(path))
            {
                issues.Add(issue);
            }
        }

        foreach (var property in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!property.CanRead)
            {
                continue;
            }

            var value = property.GetValue(instance);
            if (value is null || value is string || property.PropertyType.IsEnum || IsSimple(property.PropertyType))
            {
                continue;
            }

            var propertyPath = path.Append(property.Name);
            if (value is IEnumerable enumerable)
            {
                var index = 0;
                foreach (var item in enumerable)
                {
                    if (item is null || item is string || IsSimple(item.GetType()))
                    {
                        index++;
                        continue;
                    }

                    ValidateRecursive(item, $"{propertyPath}[{index}]", issues);
                    index++;
                }

                continue;
            }

            ValidateRecursive(value, propertyPath, issues);
        }
    }

    private static bool IsSimple(Type type)
    {
        var targetType = Nullable.GetUnderlyingType(type) ?? type;

        return targetType.IsPrimitive
            || targetType.IsEnum
            || targetType == typeof(decimal)
            || targetType == typeof(DateTime)
            || targetType == typeof(DateTimeOffset)
            || targetType == typeof(Guid)
            || targetType == typeof(TimeOnly)
            || targetType == typeof(DateOnly);
    }

    public static string Append(this string path, string segment) =>
        string.IsNullOrWhiteSpace(path) ? segment : $"{path}.{segment}";
}
