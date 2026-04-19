using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Rfps;

[XmlRoot("BuyerRFPS", Namespace = TipXml.Namespace)]
public sealed class BuyerRFPSRequest : ITipValidatable
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
    [JsonPropertyName("dateSubmitted")]
    [XmlElement("dateSubmitted")]
    public string? DateSubmitted { get; set; }

    [JsonPropertyName("dueDate")]
    [XmlElement("dueDate")]
    public string? DueDate { get; set; }

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("commission")]
    [XmlElement("commission")]
    public decimal? Commission { get; set; }

    [Required]
    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("brand")]
    [XmlElement("brand")]
    public Brand? Brand { get; set; }

    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public CurrencyCode? Currency { get; set; }

    [JsonPropertyName("budgets")]
    [XmlArray("budgets")]
    [XmlArrayItem("budget")]
    public List<Budget> Budgets { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("timePeriodPreferences")]
    [XmlArray("timePeriodPreferences")]
    [XmlArrayItem("timePeriod")]
    public List<TimePeriod> TimePeriodPreferences { get; set; } = [];

    [JsonPropertyName("marketPreferences")]
    [XmlArray("marketPreferences")]
    [XmlArrayItem("item")]
    public List<string> MarketPreferences { get; set; } = [];

    [JsonPropertyName("audiencePreferences")]
    [XmlArray("audiencePreferences")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegment> AudiencePreferences { get; set; } = [];

    [JsonPropertyName("targetingPreferences")]
    [XmlArray("targetingPreferences")]
    [XmlArrayItem("item")]
    public List<string> TargetingPreferences { get; set; } = [];

    [JsonPropertyName("frequencyPreferences")]
    [XmlArray("frequencyPreferences")]
    [XmlArrayItem("frequencyCapping")]
    public List<FrequencyCapping> FrequencyPreferences { get; set; } = [];

    [JsonPropertyName("unitLengthPreferences")]
    [XmlArray("unitLengthPreferences")]
    [XmlArrayItem("item")]
    public List<int> UnitLengthPreferences { get; set; } = [];

    [JsonPropertyName("fluidityPreference")]
    [XmlElement("fluidityPreference")]
    public decimal? FluidityPreference { get; set; }

    [JsonPropertyName("guidelines")]
    [XmlArray("guidelines")]
    [XmlArrayItem("guideline")]
    public List<Guideline> Guidelines { get; set; } = [];

    [JsonPropertyName("objective")]
    [XmlElement("objective")]
    public string? Objective { get; set; }

    [JsonPropertyName("comments")]
    [XmlElement("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("campaignGoals")]
    [XmlArray("campaignGoals")]
    [XmlArrayItem("campaignGoal")]
    public List<CampaignGoal> CampaignGoals { get; set; } = [];

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

public sealed class CampaignGoal
{
    [Required]
    [JsonPropertyName("distributionType")]
    [XmlElement("distributionType")]
    public CampaignGoalDistributionType? DistributionType { get; set; }

    [Required]
    [JsonPropertyName("distributionMethod")]
    [XmlElement("distributionMethod")]
    public CampaignGoalDistributionMethod? DistributionMethod { get; set; }

    [Required]
    [JsonPropertyName("distributionName")]
    [XmlElement("distributionName")]
    public string? DistributionName { get; set; }

    [Required]
    [JsonPropertyName("distribution")]
    [XmlElement("distribution")]
    public CampaignGoalDistribution? Distribution { get; set; }

    [Required]
    [JsonPropertyName("distributionValue")]
    [XmlElement("distributionValue")]
    public decimal? DistributionValue { get; set; }

    [Required]
    [JsonPropertyName("distributionOrder")]
    [XmlElement("distributionOrder")]
    public int? DistributionOrder { get; set; }

    [Required]
    [JsonPropertyName("distributionOrderParent")]
    [XmlElement("distributionOrderParent")]
    public int? DistributionOrderParent { get; set; }
}
