namespace Tip.TransactionStandard.Validation;

public interface ITipValidatable
{
    IEnumerable<TipValidationIssue> Validate(string path);
}
