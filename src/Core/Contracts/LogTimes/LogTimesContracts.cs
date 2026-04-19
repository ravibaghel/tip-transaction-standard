using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.LogTimes;

[XmlRoot("SellerLogtimesRequest", Namespace = TipXml.Namespace)]
public sealed class SellerLogtimesRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlElement("mediaOutlets")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("units")]
    [XmlElement("units")]
    public List<LogTimeUnit> Units { get; set; } = [];
}

[XmlRoot("BuyerLogTimesSubscriptionRequest", Namespace = TipXml.Namespace)]
public sealed class BuyerLogTimesSubscriptionRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlElement("referenceIds")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("mediaOutlets")]
    [XmlElement("mediaOutlets")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public List<Buyer> Buyer { get; set; } = [];

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public List<Advertiser> Advertiser { get; set; } = [];

    [JsonPropertyName("contacts")]
    [XmlElement("contacts")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("inventoryTypes")]
    [XmlElement("inventoryTypes")]
    public List<string> InventoryTypes { get; set; } = [];

    [JsonPropertyName("statuses")]
    [XmlElement("statuses")]
    public List<UnitStatus> Statuses { get; set; } = [];

    [JsonPropertyName("frequency")]
    [XmlElement("frequency")]
    public Frequency? Frequency { get; set; }
}

public sealed class LogTimeUnit : ITipValidatable
{
    [Required]
    [JsonPropertyName("unitId")]
    [XmlElement("unitId")]
    public string? UnitId { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlElement("referenceIds")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("lineReferences")]
    [XmlElement("lineReferences")]
    public List<Identifier> LineReferences { get; set; } = [];

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

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

    [JsonPropertyName("program")]
    [XmlElement("program")]
    public string? Program { get; set; }

    [JsonPropertyName("daypart")]
    [XmlElement("daypart")]
    public string? Daypart { get; set; }

    [JsonPropertyName("inventoryType")]
    [XmlElement("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkType? LinkType { get; set; }

    [JsonPropertyName("isMakegood")]
    [XmlElement("isMakegood")]
    public bool? IsMakegood { get; set; }

    [JsonPropertyName("isAdu")]
    [XmlElement("isAdu")]
    public bool? IsAdu { get; set; }

    [JsonPropertyName("preemptUnitIds")]
    [XmlElement("preemptUnitIds")]
    public List<string> PreemptUnitIds { get; set; } = [];

    [JsonPropertyName("isBonus")]
    [XmlElement("isBonus")]
    public bool? IsBonus { get; set; }

    [Required]
    [JsonPropertyName("airedLength")]
    [XmlElement("airedLength")]
    public int? AiredLength { get; set; }

    [JsonPropertyName("bookedLength")]
    [XmlElement("bookedLength")]
    public int? BookedLength { get; set; }

    [JsonPropertyName("rate")]
    [XmlElement("rate")]
    public decimal? Rate { get; set; }

    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [Required]
    [JsonPropertyName("status")]
    [XmlElement("status")]
    public UnitStatus? Status { get; set; }

    [JsonPropertyName("isCredit")]
    [XmlElement("isCredit")]
    public bool? IsCredit { get; set; }

    [JsonPropertyName("timePeriods")]
    [XmlElement("timePeriods")]
    public List<TimePeriod> TimePeriods { get; set; } = [];

    [JsonPropertyName("dateTime")]
    [XmlElement("dateTime")]
    public TipDateTime? DateTime { get; set; }

    [JsonPropertyName("childUnits")]
    [XmlElement("childUnits")]
    public List<ChildUnit> ChildUnits { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (AiredLength <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(AiredLength)), "airedLength must be greater than zero.");
        }

        if (Rate < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Rate)), "rate cannot be negative.");
        }

        if (BookedLength < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(BookedLength)), "bookedLength cannot be negative.");
        }

        if (Status is not UnitStatus.NoRun && DateTime is null)
        {
            yield return new TipValidationIssue(path.Append(nameof(DateTime)), "dateTime is required unless status is 'No Run'.");
        }
    }
}

public sealed class ChildUnit : ITipValidatable
{
    [Required]
    [JsonPropertyName("unitId")]
    [XmlElement("unitId")]
    public string? UnitId { get; set; }

    [Required]
    [JsonPropertyName("salesElementHeader")]
    [XmlElement("salesElementHeader")]
    public SalesElementHeader? SalesElementHeader { get; set; }

    [JsonPropertyName("rate")]
    [XmlElement("rate")]
    public decimal? Rate { get; set; }

    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [JsonPropertyName("status")]
    [XmlElement("status")]
    public UnitStatus? Status { get; set; }

    [JsonPropertyName("dateTime")]
    [XmlElement("dateTime")]
    public TipDateTime? DateTime { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Rate < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Rate)), "rate cannot be negative.");
        }

        if (Status is UnitStatus.Aired && DateTime is null)
        {
            yield return new TipValidationIssue(path.Append(nameof(DateTime)), "dateTime is required when child unit status is 'Aired'.");
        }

        if ((Status is UnitStatus.Aired or UnitStatus.Finalized) && (Creative?.Ids.Count ?? 0) == 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Creative)), "creative.ids must contain at least one identifier when status is 'Aired' or 'Finalized'.");
        }
    }
}
