using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class AudienceDetail : ITipValidatable
{
    [Required]
    [JsonPropertyName("detailType")]
    [XmlElement("detailType")]
    public string? DetailType { get; set; }

    [Required]
    [JsonPropertyName("dateType")]
    [XmlElement("dateType")]
    public string? DateType { get; set; }

    [Required]
    [JsonPropertyName("calendarType")]
    [XmlElement("calendarType")]
    public CalendarType? CalendarType { get; set; }

    [Required]
    [JsonPropertyName("dateWindow")]
    [XmlElement("dateWindow")]
    public DateWindow? DateWindow { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [Required]
    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("brand")]
    [XmlElement("brand")]
    public Brand? Brand { get; set; }

    [Required]
    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [Required]
    [JsonPropertyName("salesElementHeader")]
    [XmlElement("salesElementHeader")]
    public SalesElementHeader? SalesElementHeader { get; set; }

    [JsonPropertyName("daypart")]
    [XmlElement("daypart")]
    public string? Daypart { get; set; }

    [JsonPropertyName("inventoryType")]
    [XmlElement("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("length")]
    [XmlElement("length")]
    public int? Length { get; set; }

    [JsonPropertyName("pricingMetric")]
    [XmlElement("pricingMetric")]
    public PricingMetric? PricingMetric { get; set; }

    [JsonPropertyName("unitCount")]
    [XmlElement("unitCount")]
    public int? UnitCount { get; set; }

    [JsonPropertyName("audienceTargets")]
    [XmlArray("audienceTargets")]
    [XmlArrayItem("audienceTarget")]
    public List<AudienceTarget> AudienceTargets { get; set; } = [];

    [JsonPropertyName("audiencePricingMetrics")]
    [XmlArray("audiencePricingMetrics")]
    [XmlArrayItem("audiencePricingMetric")]
    public List<AudiencePricingMetric> AudiencePricingMetrics { get; set; } = [];

    [JsonPropertyName("unitDetails")]
    [XmlArray("unitDetails")]
    [XmlArrayItem("audienceUnitDetail")]
    public List<AudienceUnitDetail> UnitDetails { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Length is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Length)), "length must be zero or greater.");
        }

        if (UnitCount is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(UnitCount)), "unitCount must be zero or greater.");
        }
    }
}

public sealed class AudienceUnitDetail : ITipValidatable
{
    [Required]
    [JsonPropertyName("unitId")]
    [XmlElement("unitId")]
    public string? UnitId { get; set; }

    [Required]
    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [JsonPropertyName("dateTime")]
    [XmlElement("dateTime")]
    public TipDateTime? DateTime { get; set; }

    [JsonPropertyName("rate")]
    [XmlElement("rate")]
    public decimal? Rate { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("audiencePricingMetrics")]
    [XmlArray("audiencePricingMetrics")]
    [XmlArrayItem("audiencePricingMetric")]
    public List<AudiencePricingMetric> AudiencePricingMetrics { get; set; } = [];

    [JsonPropertyName("comment")]
    [XmlElement("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("childUnits")]
    [XmlArray("childUnits")]
    [XmlArrayItem("childUnit")]
    public List<AudienceChildUnitDetail> ChildUnits { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Rate < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Rate)), "rate cannot be negative.");
        }
    }
}

public sealed class AudienceChildUnitDetail : ITipValidatable
{
    [JsonPropertyName("unitId")]
    [XmlElement("unitId")]
    public string? UnitId { get; set; }

    [JsonPropertyName("mediaOutlet")]
    [XmlElement("mediaOutlet")]
    public MediaOutlet? MediaOutlet { get; set; }

    [Required]
    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [JsonPropertyName("dateTime")]
    [XmlElement("dateTime")]
    public TipDateTime? DateTime { get; set; }

    [JsonPropertyName("rate")]
    [XmlElement("rate")]
    public decimal? Rate { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("audiencePricingMetrics")]
    [XmlArray("audiencePricingMetrics")]
    [XmlArrayItem("audiencePricingMetric")]
    public List<AudiencePricingMetric> AudiencePricingMetrics { get; set; } = [];

    [JsonPropertyName("comment")]
    [XmlElement("comment")]
    public string? Comment { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Rate < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Rate)), "rate cannot be negative.");
        }
    }
}
