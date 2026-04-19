using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class ItemDetail
{
    [Required]
    [JsonPropertyName("itemType")]
    [XmlElement("itemType")]
    public string? ItemType { get; set; }

    [Required]
    [JsonPropertyName("value")]
    [XmlElement("value")]
    public decimal? Value { get; set; }
}

public sealed class RemittanceInfo
{
    [Required, MinLength(1)]
    [JsonPropertyName("referenceSourceIds")]
    [XmlArray("referenceSourceIds")]
    [XmlArrayItem("identifier")]
    public List<Identifier> ReferenceSourceIds { get; set; } = [];

    [JsonPropertyName("referenceName")]
    [XmlElement("referenceName")]
    public string? ReferenceName { get; set; }

    [JsonPropertyName("contactFirstName")]
    [XmlElement("contactFirstName")]
    public string? ContactFirstName { get; set; }

    [JsonPropertyName("contactLastName")]
    [XmlElement("contactLastName")]
    public string? ContactLastName { get; set; }

    [JsonPropertyName("addressLine1")]
    [XmlElement("addressLine1")]
    public string? AddressLine1 { get; set; }

    [JsonPropertyName("addressLine2")]
    [XmlElement("addressLine2")]
    public string? AddressLine2 { get; set; }

    [JsonPropertyName("city")]
    [XmlElement("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    [XmlElement("state")]
    public string? State { get; set; }

    [JsonPropertyName("postalCode")]
    [XmlElement("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("country")]
    [XmlElement("country")]
    public string? Country { get; set; }

    [JsonPropertyName("phoneNumber")]
    [XmlElement("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("contactEmail")]
    [XmlElement("contactEmail")]
    public string? ContactEmail { get; set; }

    [JsonPropertyName("portalInformation")]
    [XmlElement("portalInformation")]
    public string? PortalInformation { get; set; }

    [JsonPropertyName("paymentLink")]
    [XmlElement("paymentLink")]
    public string? PaymentLink { get; set; }

    [JsonPropertyName("comments")]
    [XmlElement("comments")]
    public string? Comments { get; set; }
}

public sealed class InvoiceChildUnitDetail
{
    [JsonPropertyName("unitId")]
    [XmlElement("unitId")]
    public string? UnitId { get; set; }

    [Required]
    [JsonPropertyName("salesElementHeader")]
    [XmlElement("salesElementHeader")]
    public SalesElementHeader? SalesElementHeader { get; set; }

    [JsonPropertyName("grossRate")]
    [XmlElement("grossRate")]
    public decimal? GrossRate { get; set; }

    [Required]
    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [JsonPropertyName("isPreempt")]
    [XmlElement("isPreempt")]
    public bool? IsPreempt { get; set; }

    [JsonPropertyName("isMakegood")]
    [XmlElement("isMakegood")]
    public bool? IsMakegood { get; set; }

    [JsonPropertyName("isAdu")]
    [XmlElement("isAdu")]
    public bool? IsAdu { get; set; }

    [JsonPropertyName("isCredit")]
    [XmlElement("isCredit")]
    public bool? IsCredit { get; set; }

    [JsonPropertyName("adjustmentReason")]
    [XmlElement("adjustmentReason")]
    public string? AdjustmentReason { get; set; }

    [JsonPropertyName("dateTime")]
    [XmlElement("dateTime")]
    public TipDateTime? DateTime { get; set; }
}

public sealed class InvoiceUnitDetail
{
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

    [JsonPropertyName("podPosition")]
    [XmlElement("podPosition")]
    public InventoryPositionType? PodPosition { get; set; }

    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkType? LinkType { get; set; }

    [JsonPropertyName("isPreempt")]
    [XmlElement("isPreempt")]
    public bool? IsPreempt { get; set; }

    [JsonPropertyName("isMakegood")]
    [XmlElement("isMakegood")]
    public bool? IsMakegood { get; set; }

    [JsonPropertyName("isAdu")]
    [XmlElement("isAdu")]
    public bool? IsAdu { get; set; }

    [JsonPropertyName("isBonus")]
    [XmlElement("isBonus")]
    public bool? IsBonus { get; set; }

    [JsonPropertyName("grossRate")]
    [XmlElement("grossRate")]
    public decimal? GrossRate { get; set; }

    [JsonPropertyName("isCredit")]
    [XmlElement("isCredit")]
    public bool? IsCredit { get; set; }

    [JsonPropertyName("adjustmentReason")]
    [XmlElement("adjustmentReason")]
    public string? AdjustmentReason { get; set; }

    [JsonPropertyName("comment")]
    [XmlElement("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("childUnitDetails")]
    [XmlArray("childUnitDetails")]
    [XmlArrayItem("childUnitDetail")]
    public List<InvoiceChildUnitDetail> ChildUnitDetails { get; set; } = [];
}

public sealed class InvoiceLineDetail
{
    [Required]
    [JsonPropertyName("lineNum")]
    [XmlElement("lineNum")]
    public string? LineNum { get; set; }

    [JsonPropertyName("lineReference")]
    [XmlElement("lineReference")]
    public string? LineReference { get; set; }

    [JsonPropertyName("lineReferences")]
    [XmlArray("lineReferences")]
    [XmlArrayItem("identifier")]
    public List<Identifier> LineReferences { get; set; } = [];

    [Required]
    [JsonPropertyName("type")]
    [XmlElement("type")]
    public InvoiceLineType? Type { get; set; }

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

    [JsonPropertyName("inventoryType")]
    [XmlElement("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("timePeriod")]
    [XmlArray("timePeriod")]
    [XmlArrayItem("timePeriod")]
    public List<TimePeriod> TimePeriod { get; set; } = [];

    [Required]
    [JsonPropertyName("length")]
    [XmlElement("length")]
    public int? Length { get; set; }

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [JsonPropertyName("billableCosts")]
    [XmlElement("billableCosts")]
    public string? BillableCosts { get; set; }

    [JsonPropertyName("pricingMetric")]
    [XmlElement("pricingMetric")]
    public PricingMetric? PricingMetric { get; set; }

    [Required]
    [JsonPropertyName("grossCost")]
    [XmlElement("grossCost")]
    public decimal? GrossCost { get; set; }

    [Required]
    [JsonPropertyName("netCost")]
    [XmlElement("netCost")]
    public decimal? NetCost { get; set; }

    [JsonPropertyName("audienceTargets")]
    [XmlArray("audienceTargets")]
    [XmlArrayItem("audienceTarget")]
    public List<AudienceTarget> AudienceTargets { get; set; } = [];

    [JsonPropertyName("invoiceUnits")]
    [XmlElement("invoiceUnits")]
    public decimal? InvoiceUnits { get; set; }

    [JsonPropertyName("deliveredTargetUnits")]
    [XmlElement("deliveredTargetUnits")]
    public decimal? DeliveredTargetUnits { get; set; }

    [JsonPropertyName("deliveredThirdPartyUnits")]
    [XmlElement("deliveredThirdPartyUnits")]
    public decimal? DeliveredThirdPartyUnits { get; set; }

    [JsonPropertyName("unitCount")]
    [XmlElement("unitCount")]
    public int? UnitCount { get; set; }

    [JsonPropertyName("unitDetails")]
    [XmlArray("unitDetails")]
    [XmlArrayItem("unitDetail")]
    public List<InvoiceUnitDetail> UnitDetails { get; set; } = [];
}
