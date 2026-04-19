using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.InventoryAvails;

[XmlRoot("BuyerInventoryAvailsSubscription", Namespace = TipXml.Namespace)]
public sealed class BuyerInventoryAvailsSubscriptionRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("dayOfWeek")]
    [XmlElement("dayOfWeek")]
    public DayOfWeekSelection? DayOfWeek { get; set; }

    [JsonPropertyName("timeWindows")]
    [XmlArray("timeWindows")]
    [XmlArrayItem("timeWindow")]
    public List<TimeWindow> TimeWindows { get; set; } = [];

    [JsonPropertyName("guidelines")]
    [XmlArray("guidelines")]
    [XmlArrayItem("guideline")]
    public List<Guideline> Guidelines { get; set; } = [];

    [Required]
    [JsonPropertyName("isPolitical")]
    [XmlElement("isPolitical")]
    public bool? IsPolitical { get; set; }

    [JsonPropertyName("inventoryTypes")]
    [XmlArray("inventoryTypes")]
    [XmlArrayItem("item")]
    public List<string> InventoryTypes { get; set; } = [];

    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public CurrencyCode? Currency { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [JsonPropertyName("audienceSegments")]
    [XmlArray("audienceSegments")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegment> AudienceSegments { get; set; } = [];

    [JsonPropertyName("pricingMetricOptions")]
    [XmlArray("pricingMetricOptions")]
    [XmlArrayItem("item")]
    public List<PricingMetricOptionType> PricingMetricOptions { get; set; } = [];

    [JsonPropertyName("frequency")]
    [XmlElement("frequency")]
    public Frequency? Frequency { get; set; }

    [JsonPropertyName("startDate")]
    [XmlElement("startDate")]
    public DynamicOrDate? StartDate { get; set; }

    // The upstream TIP JSON example uses `stratDate`; keep a JSON-only alias for compatibility.
    [JsonPropertyName("stratDate")]
    [XmlIgnore]
    public DynamicOrDate? LegacyStratDate
    {
        get => StartDate;
        set => StartDate = value;
    }

    [JsonPropertyName("endDate")]
    [XmlElement("endDate")]
    public DynamicOrDate? EndDate { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (AudienceSegments.Count > 0 && AudienceSegments.Count < 1)
        {
            yield return new TipValidationIssue(path.Append(nameof(AudienceSegments)), "audienceSegments must contain at least one audience segment when supplied.");
        }
    }
}

[XmlRoot("SellerInventoryAvails", Namespace = TipXml.Namespace)]
public sealed class SellerInventoryAvailsRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required]
    [JsonPropertyName("dateSubmitted")]
    [XmlElement("dateSubmitted")]
    public string? DateSubmitted { get; set; }

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("rateCard")]
    [XmlElement("rateCard")]
    public RateCard? RateCard { get; set; }

    [Required]
    [JsonPropertyName("isPolitical")]
    [XmlElement("isPolitical")]
    public bool? IsPolitical { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("audienceSegments")]
    [XmlArray("audienceSegments")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegmentDetail> AudienceSegments { get; set; } = [];

    [Required]
    [JsonPropertyName("availWindow")]
    [XmlElement("availWindow")]
    public DateWindow? AvailWindow { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("salesElements")]
    [XmlArray("salesElements")]
    [XmlArrayItem("salesElement")]
    public List<SalesElement> SalesElements { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TipDateTime.IsDateLike(DateSubmitted))
        {
            yield return new TipValidationIssue(path.Append(nameof(DateSubmitted)), "dateSubmitted must be a valid ISO date.");
        }
    }
}

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
