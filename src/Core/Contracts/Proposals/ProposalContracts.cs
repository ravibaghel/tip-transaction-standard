using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Proposals;

public class ProposalBase : ITipValidatable
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

    [JsonPropertyName("expirationDate")]
    [XmlElement("expirationDate")]
    public string? ExpirationDate { get; set; }

    [Required]
    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [Required]
    [JsonPropertyName("commission")]
    [XmlElement("commission")]
    public decimal? Commission { get; set; }

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("brand")]
    [XmlElement("brand")]
    public Brand? Brand { get; set; }

    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("budgets")]
    [XmlArray("budgets")]
    [XmlArrayItem("budget")]
    public List<Budget> Budgets { get; set; } = [];

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [Required]
    [JsonPropertyName("revenueType")]
    [XmlElement("revenueType")]
    public RevenueType? RevenueType { get; set; }

    [Required]
    [JsonPropertyName("businessType")]
    [XmlElement("businessType")]
    public string? BusinessType { get; set; }

    [JsonPropertyName("localNational")]
    [XmlElement("localNational")]
    public MarketScope? LocalNational { get; set; }

    [JsonPropertyName("dealYear")]
    [XmlElement("dealYear")]
    public string? DealYear { get; set; }

    [JsonPropertyName("billingOption")]
    [XmlElement("billingOption")]
    public BillingOption? BillingOption { get; set; }

    [Required]
    [JsonPropertyName("isEquivalized")]
    [XmlElement("isEquivalized")]
    public bool? IsEquivalized { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("dateWindows")]
    [XmlArray("dateWindows")]
    [XmlArrayItem("dateWindow")]
    public List<DateWindow> DateWindows { get; set; } = [];

    [JsonPropertyName("cancellationTerms")]
    [XmlArray("cancellationTerms")]
    [XmlArrayItem("cancellationTerm")]
    public List<CancellationTerm> CancellationTerms { get; set; } = [];

    [JsonPropertyName("timeSeparations")]
    [XmlArray("timeSeparations")]
    [XmlArrayItem("timeSeparation")]
    public List<TimeSeparation> TimeSeparations { get; set; } = [];

    [JsonPropertyName("fluidity")]
    [XmlElement("fluidity")]
    public decimal? Fluidity { get; set; }

    [JsonPropertyName("termsOfSales")]
    [XmlElement("termsOfSales")]
    public string? TermsOfSales { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [JsonPropertyName("rateCard")]
    [XmlElement("rateCard")]
    public RateCard? RateCard { get; set; }

    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public CurrencyCode? Currency { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("audienceSegments")]
    [XmlArray("audienceSegments")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegmentDetail> AudienceSegments { get; set; } = [];

    [JsonPropertyName("salesElements")]
    [XmlArray("salesElements")]
    [XmlArrayItem("salesElement")]
    public List<SalesElementTransaction> SalesElements { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(ExpirationDate) && !TipDateTime.IsDateLike(ExpirationDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(ExpirationDate)), "expirationDate must be a valid ISO date.");
        }
    }
}

[XmlRoot("SellerProposals", Namespace = TipXml.Namespace)]
public sealed class SellerProposalsRequest : ProposalBase
{
}

[XmlRoot("BuyerProposals", Namespace = TipXml.Namespace)]
public sealed class BuyerProposalsRequest : ProposalBase
{
}
