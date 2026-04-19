using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

[JsonConverter(typeof(DynamicOrDateJsonConverter))]
public sealed class DynamicOrDate : ITipValidatable
{
    [JsonPropertyName("offsetType")]
    [XmlElement("offsetType")]
    public DynamicDateOffsetType? OffsetType { get; set; }

    [JsonPropertyName("offset")]
    [XmlElement("offset")]
    public int? Offset { get; set; }

    [JsonIgnore]
    [XmlText]
    public string? DateValue { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(DateValue) && !TipDateTime.IsDateLike(DateValue))
        {
            yield return new TipValidationIssue(path, "date value must be a valid ISO date.");
        }
    }
}
