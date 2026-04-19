using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class DynamicDate
{
    [Required]
    [JsonPropertyName("offsetType")]
    [XmlElement("offsetType")]
    public DynamicDateOffsetType? OffsetType { get; set; }

    [Required]
    [JsonPropertyName("offset")]
    [XmlElement("offset")]
    public int? Offset { get; set; }
}

public sealed class SalesElementInventoryDate : ITipValidatable
{
    [JsonPropertyName("dateType")]
    [XmlElement("dateType")]
    public DateType? DateType { get; set; }

    [JsonPropertyName("calendarType")]
    [XmlElement("calendarType")]
    public CalendarType? CalendarType { get; set; }

    [Required]
    [JsonPropertyName("dateWindow")]
    [XmlElement("dateWindow")]
    public DateWindow? DateWindow { get; set; }

    [JsonPropertyName("inventoryCapacity")]
    [XmlElement("inventoryCapacity")]
    public decimal? InventoryCapacity { get; set; }

    [JsonPropertyName("inventoryAvails")]
    [XmlElement("inventoryAvails")]
    public decimal? InventoryAvails { get; set; }

    [JsonPropertyName("inventoryMax")]
    [XmlElement("inventoryMax")]
    public decimal? InventoryMax { get; set; }

    [JsonPropertyName("audiencesPricingMetrics")]
    [XmlArray("audiencesPricingMetrics")]
    [XmlArrayItem("audiencePricingMetric")]
    public List<AudiencePricingMetric> AudiencesPricingMetrics { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (InventoryCapacity is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InventoryCapacity)), "inventoryCapacity must be zero or greater.");
        }

        if (InventoryAvails is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InventoryAvails)), "inventoryAvails must be zero or greater.");
        }

        if (InventoryMax is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InventoryMax)), "inventoryMax must be zero or greater.");
        }
    }
}

public sealed class SalesElementInventory : ITipValidatable
{
    [Required]
    [JsonPropertyName("inventoryType")]
    [XmlElement("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkType? LinkType { get; set; }

    [JsonPropertyName("companionTypeIds")]
    [XmlArray("companionTypeIds")]
    [XmlArrayItem("item")]
    public List<string> CompanionTypeIds { get; set; } = [];

    [JsonPropertyName("inventoryPosition")]
    [XmlElement("inventoryPosition")]
    public InventoryPositionType? InventoryPosition { get; set; }

    [JsonPropertyName("inventoryLength")]
    [XmlElement("inventoryLength")]
    public int? InventoryLength { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("salesElementInventoryDates")]
    [XmlArray("salesElementInventoryDates")]
    [XmlArrayItem("salesElementInventoryDate")]
    public List<SalesElementInventoryDate> SalesElementInventoryDates { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (InventoryLength is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InventoryLength)), "inventoryLength must be zero or greater when supplied.");
        }
    }
}

public sealed class SalesElement
{
    [Required]
    [JsonPropertyName("salesElementHeader")]
    [XmlElement("salesElementHeader")]
    public SalesElementHeader? SalesElementHeader { get; set; }

    [JsonPropertyName("timePeriods")]
    [XmlArray("timePeriods")]
    [XmlArrayItem("timePeriod")]
    public List<TimePeriod> TimePeriods { get; set; } = [];

    [JsonPropertyName("devices")]
    [XmlArray("devices")]
    [XmlArrayItem("device")]
    public List<string> Devices { get; set; } = [];

    [JsonPropertyName("programs")]
    [XmlArray("programs")]
    [XmlArrayItem("item")]
    public List<string> Programs { get; set; } = [];

    [JsonPropertyName("salesElementInventorys")]
    [XmlArray("salesElementInventorys")]
    [XmlArrayItem("salesElementInventory")]
    public List<SalesElementInventory> SalesElementInventorys { get; set; } = [];
}
