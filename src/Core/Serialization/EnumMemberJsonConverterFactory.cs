using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tip.TransactionStandard.Serialization;

public sealed class EnumMemberJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        var enumType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
        return enumType.IsEnum;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var underlyingType = Nullable.GetUnderlyingType(typeToConvert);
        var enumType = underlyingType ?? typeToConvert;
        var converterType = underlyingType is null
            ? typeof(EnumMemberJsonConverter<>).MakeGenericType(enumType)
            : typeof(NullableEnumMemberJsonConverter<>).MakeGenericType(enumType);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }

    private sealed class EnumMemberJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        private readonly Dictionary<string, TEnum> _readMap;
        private readonly Dictionary<TEnum, string> _writeMap;

        public EnumMemberJsonConverter()
        {
            _readMap = new Dictionary<string, TEnum>(StringComparer.OrdinalIgnoreCase);
            _writeMap = new Dictionary<TEnum, string>();

            foreach (var value in Enum.GetValues<TEnum>())
            {
                var member = typeof(TEnum).GetMember(value.ToString())[0];
                var enumMemberValue = member.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
                _readMap[enumMemberValue] = value;
                _writeMap[value] = enumMemberValue;
            }
        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var raw = reader.GetString();
            if (raw is not null && _readMap.TryGetValue(raw, out var parsed))
            {
                return parsed;
            }

            if (raw is not null && Enum.TryParse<TEnum>(raw, ignoreCase: true, out parsed))
            {
                return parsed;
            }

            throw new JsonException($"Unable to convert '{raw}' to {typeof(TEnum).Name}.");
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
            writer.WriteStringValue(_writeMap.TryGetValue(value, out var raw) ? raw : value.ToString());
    }

    private sealed class NullableEnumMemberJsonConverter<TEnum> : JsonConverter<TEnum?> where TEnum : struct, Enum
    {
        private readonly EnumMemberJsonConverter<TEnum> _inner = new();

        public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            return _inner.Read(ref reader, typeof(TEnum), options);
        }

        public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }

            _inner.Write(writer, value.Value, options);
        }
    }
}
