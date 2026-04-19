using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Makegoods;

[XmlRoot("SellerMakegoodGuidelines", Namespace = TipXml.Namespace)]
public sealed class SellerMakegoodGuidelinesRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required]
    [JsonPropertyName("dateSubmitted")]
    [XmlElement("dateSubmitted")]
    public string? DateSubmitted { get; set; }

    [JsonPropertyName("dueDate")]
    [XmlElement("dueDate")]
    public string? DueDate { get; set; }

    [JsonPropertyName("mediaOutlet")]
    [XmlElement("mediaOutlet")]
    public MediaOutlet? MediaOutlet { get; set; }

    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [Required]
    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [Required]
    [JsonPropertyName("makegoodType")]
    [XmlElement("makegoodType")]
    public MakegoodType? MakegoodType { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TipDateTime.IsDateLike(DateSubmitted))
        {
            yield return new TipValidationIssue(path.Append(nameof(DateSubmitted)), "dateSubmitted must be a valid ISO date.");
        }

        if (!string.IsNullOrWhiteSpace(DueDate) && !TipDateTime.IsDateLike(DueDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(DueDate)), "dueDate must be a valid ISO date.");
        }
    }
}

[XmlRoot("BuyerMakegoodGuidelines", Namespace = TipXml.Namespace)]
public sealed class BuyerMakegoodGuidelinesRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("mediaOutlet")]
    [XmlElement("mediaOutlet")]
    public MediaOutlet? MediaOutlet { get; set; }

    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [Required]
    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("makegoodGuidelines")]
    [XmlArray("makegoodGuidelines")]
    [XmlArrayItem("makegoodGuideline")]
    public List<MakegoodGuideline> MakegoodGuidelines { get; set; } = [];
}

public sealed class MakegoodGuideline
{
    [Required]
    [JsonPropertyName("makegoodType")]
    [XmlElement("makegoodType")]
    public MakegoodType? MakegoodType { get; set; }

    [JsonPropertyName("salesElementOriginal")]
    [XmlElement("salesElementOriginal")]
    public SalesElementHeader? SalesElementOriginal { get; set; }

    [Required]
    [JsonPropertyName("salesElementEquivalent")]
    [XmlElement("salesElementEquivalent")]
    public SalesElementEquivalentType? SalesElementEquivalent { get; set; }

    [JsonPropertyName("makegoodTargetAudienceLimit")]
    [XmlElement("makegoodTargetAudienceLimit")]
    public decimal? MakegoodTargetAudienceLimit { get; set; }

    [JsonPropertyName("makegoodRatio")]
    [XmlElement("makegoodRatio")]
    public int? MakegoodRatio { get; set; }

    [JsonPropertyName("makegoodWindow")]
    [XmlElement("makegoodWindow")]
    public MakegoodWindowType? MakegoodWindow { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }
}

[XmlRoot("SellerMakegoodOffers", Namespace = TipXml.Namespace)]
public sealed class SellerMakegoodOffersRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [Required]
    [JsonPropertyName("makegoodType")]
    [XmlElement("makegoodType")]
    public MakegoodType? MakegoodType { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [JsonPropertyName("preemptDetails")]
    [XmlArray("preemptDetails")]
    [XmlArrayItem("preemptDetail")]
    public List<PreemptDetail> PreemptDetails { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("makegoodDetails")]
    [XmlArray("makegoodDetails")]
    [XmlArrayItem("makegoodOfferDetail")]
    public List<MakegoodOfferDetail> MakegoodDetails { get; set; } = [];
}

public sealed class PreemptDetail
{
    [Required]
    [JsonPropertyName("preemptNum")]
    [XmlElement("preemptNum")]
    public string? PreemptNum { get; set; }

    [JsonPropertyName("salesElement")]
    [XmlElement("salesElement")]
    public SalesElementTransaction? SalesElement { get; set; }

    [JsonPropertyName("preemptReason")]
    [XmlElement("preemptReason")]
    public string? PreemptReason { get; set; }

    [JsonPropertyName("makegoodNumLinks")]
    [XmlArray("makegoodNumLinks")]
    [XmlArrayItem("item")]
    public List<int> MakegoodNumLinks { get; set; } = [];
}

public sealed class MakegoodOfferDetail
{
    [Required]
    [JsonPropertyName("makegoodNum")]
    [XmlElement("makegoodNum")]
    public int? MakegoodNum { get; set; }

    [Required]
    [JsonPropertyName("salesElement")]
    [XmlElement("salesElement")]
    public SalesElementTransaction? SalesElement { get; set; }

    [JsonPropertyName("makegoodReason")]
    [XmlElement("makegoodReason")]
    public string? MakegoodReason { get; set; }

    [JsonPropertyName("makegoodAssumedConfirm")]
    [XmlElement("makegoodAssumedConfirm")]
    public MakegoodAssumedConfirmType? MakegoodAssumedConfirm { get; set; }

    [JsonPropertyName("preemptNumLinks")]
    [XmlArray("preemptNumLinks")]
    [XmlArrayItem("item")]
    public List<int> PreemptNumLinks { get; set; } = [];
}
