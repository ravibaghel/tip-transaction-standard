using System.Text.Json;
using System.Text.Json.Serialization;
using Tip.TransactionStandard.Contracts.Common;

namespace Tip.TransactionStandard.Serialization;

public sealed class DynamicOrDateJsonConverter : JsonConverter<DynamicOrDate>
{
    public override DynamicOrDate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return new DynamicOrDate
            {
                DateValue = reader.GetString(),
            };
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Unsupported token {reader.TokenType} for {nameof(DynamicOrDate)}.");
        }

        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        return new DynamicOrDate
        {
            OffsetType = root.TryGetProperty("offsetType", out var offsetType)
                ? JsonSerializer.Deserialize<Contracts.Common.DynamicDateOffsetType>(offsetType.GetRawText(), options)
                : null,
            Offset = root.TryGetProperty("offset", out var offset) && offset.ValueKind == JsonValueKind.Number
                ? offset.GetInt32()
                : null,
        };
    }

    public override void Write(Utf8JsonWriter writer, DynamicOrDate value, JsonSerializerOptions options)
    {
        if (!string.IsNullOrWhiteSpace(value.DateValue))
        {
            writer.WriteStringValue(value.DateValue);
            return;
        }

        writer.WriteStartObject();

        if (value.OffsetType is not null)
        {
            writer.WritePropertyName("offsetType");
            JsonSerializer.Serialize(writer, value.OffsetType, options);
        }

        if (value.Offset.HasValue)
        {
            writer.WriteNumber("offset", value.Offset.Value);
        }

        writer.WriteEndObject();
    }
}
