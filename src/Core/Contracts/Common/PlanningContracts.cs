using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class Budget : ITipValidatable
{
    [Required]
    [JsonPropertyName("budgetAmount")]
    [XmlElement("budgetAmount")]
    public decimal? BudgetAmount { get; set; }

    [JsonPropertyName("budgetAllocation")]
    [XmlElement("budgetAllocation")]
    public BudgetAllocation? BudgetAllocation { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (BudgetAmount is <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(BudgetAmount)), "budgetAmount must be greater than zero.");
        }
    }
}

public sealed class BudgetAllocation : ITipValidatable
{
    [Required]
    [JsonPropertyName("budgetType")]
    [XmlElement("budgetType")]
    public BudgetType? BudgetType { get; set; }

    [Required]
    [JsonPropertyName("budgetName")]
    [XmlElement("budgetName")]
    public string? BudgetName { get; set; }

    [JsonPropertyName("budgetAmount")]
    [XmlElement("budgetAmount")]
    public decimal? BudgetAmount { get; set; }

    [JsonPropertyName("budgetSharePercent")]
    [XmlElement("budgetSharePercent")]
    public decimal? BudgetSharePercent { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (BudgetAmount.HasValue && BudgetAmount.Value <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(BudgetAmount)), "budgetAmount must be greater than zero when supplied.");
        }

        if (BudgetSharePercent.HasValue && BudgetSharePercent.Value <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(BudgetSharePercent)), "budgetSharePercent must be greater than zero when supplied.");
        }
    }
}

public sealed class AudienceSegment
{
    [Required, MinLength(1)]
    [JsonPropertyName("audienceSegmentIds")]
    [XmlElement("audienceSegmentIds")]
    public List<Identifier?> AudienceSegmentIds { get; set; } = [];

    [Required]
    [JsonPropertyName("audienceSegmentName")]
    [XmlElement("audienceSegmentName")]
    public string? AudienceSegmentName { get; set; }

    [JsonPropertyName("audienceSegmentReference")]
    [XmlElement("audienceSegmentReference")]
    public string? AudienceSegmentReference { get; set; }

    [JsonPropertyName("audienceMethodology")]
    [XmlElement("audienceMethodology")]
    public string? AudienceMethodology { get; set; }

    [JsonPropertyName("isPrimary")]
    [XmlElement("isPrimary")]
    public bool? IsPrimary { get; set; }

    [JsonPropertyName("isGuarantee")]
    [XmlElement("isGuarantee")]
    public bool? IsGuarantee { get; set; }

    [JsonPropertyName("ratingSource")]
    [XmlElement("ratingSource")]
    public AudienceRatingSource? RatingSource { get; set; }

    [JsonPropertyName("ratingStream")]
    [XmlElement("ratingStream")]
    public AudienceRatingStream? RatingStream { get; set; }
}

public sealed class FrequencyCapping
{
    [Required]
    [JsonPropertyName("period")]
    [XmlElement("period")]
    public FrequencyCappingPeriod? Period { get; set; }

    [JsonPropertyName("perPeriod")]
    [XmlElement("perPeriod")]
    public int? PerPeriod { get; set; }

    [Required]
    [JsonPropertyName("value")]
    [XmlElement("value")]
    public int? Value { get; set; }
}

public sealed class Guideline
{
    [Required]
    [JsonPropertyName("guidelineType")]
    [XmlElement("guidelineType")]
    public GuidelineType? GuidelineType { get; set; }

    [Required]
    [JsonPropertyName("excludeOrInclude")]
    [XmlElement("excludeOrInclude")]
    public IncludeOrExclude? ExcludeOrInclude { get; set; }

    [JsonPropertyName("guidelines")]
    [XmlArray("guidelines")]
    [XmlArrayItem("item")]
    public List<string> Guidelines { get; set; } = [];
}
