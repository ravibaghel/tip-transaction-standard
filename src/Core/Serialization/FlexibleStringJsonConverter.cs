using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tip.TransactionStandard.Serialization;

public sealed class FlexibleStringJsonConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => reader.TryGetInt64(out var i) ? i.ToString() : reader.GetDouble().ToString(System.Globalization.CultureInfo.InvariantCulture),
            JsonTokenType.True => bool.TrueString.ToLowerInvariant(),
            JsonTokenType.False => bool.FalseString.ToLowerInvariant(),
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Unsupported token '{reader.TokenType}' for string conversion."),
        };

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value);
}
