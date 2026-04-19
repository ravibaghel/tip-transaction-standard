using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class BillingOption
{
    [JsonPropertyName("billingCalendar")]
    [XmlElement("billingCalendar")]
    public BillingCalendarType? BillingCalendar { get; set; }

    [JsonPropertyName("billingCycle")]
    [XmlElement("billingCycle")]
    public BillingCycleType? BillingCycle { get; set; }

    [JsonPropertyName("billingGranularity")]
    [XmlElement("billingGranularity")]
    public BillingGranularityType? BillingGranularity { get; set; }
}

public sealed class CancellationTerm : ITipValidatable
{
    [JsonPropertyName("cancellationType")]
    [XmlElement("cancellationType")]
    public CancellationTermType? CancellationType { get; set; }

    [JsonPropertyName("cancellation")]
    [XmlElement("cancellation")]
    public string? Cancellation { get; set; }

    [JsonPropertyName("cancellationPriorDays")]
    [XmlElement("cancellationPriorDays")]
    public int? CancellationPriorDays { get; set; }

    [JsonPropertyName("cancellationPercentage")]
    [XmlElement("cancellationPercentage")]
    public decimal? CancellationPercentage { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(Cancellation)
            && CancellationType == CancellationTermType.BroadcastDate
            && !TipDateTime.IsDateLike(Cancellation))
        {
            yield return new TipValidationIssue(path.Append(nameof(Cancellation)), "cancellation must be a valid ISO date when cancellationType is 'Broadcast Date'.");
        }
    }
}

public sealed class TimeSeparation
{
    [JsonPropertyName("unitLength")]
    [XmlElement("unitLength")]
    public int? UnitLength { get; set; }

    [JsonPropertyName("timeSeparation")]
    [XmlElement("timeSeparation")]
    public int? SeparationInSeconds { get; set; }
}

public sealed class RateCard
{
    [Required]
    [JsonPropertyName("rateCardId")]
    [XmlElement("rateCardId")]
    public int? RateCardId { get; set; }

    [JsonPropertyName("rateCardName")]
    [XmlElement("rateCardName")]
    public string? RateCardName { get; set; }

    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public CurrencyCode? Currency { get; set; }
}

public sealed class Universe
{
    [JsonPropertyName("universeType")]
    [XmlElement("universeType")]
    public UniverseType? UniverseType { get; set; }

    [JsonPropertyName("universeTypeValue")]
    [XmlElement("universeTypeValue")]
    public int? UniverseTypeValue { get; set; }
}

public sealed class AudienceSegmentDetail
{
    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutletIds")]
    [XmlArray("mediaOutletIds")]
    [XmlArrayItem("identifier")]
    public List<Identifier?> MediaOutletIds { get; set; } = [];

    [Required]
    [JsonPropertyName("audienceSegment")]
    [XmlElement("audienceSegment")]
    public AudienceSegment? AudienceSegment { get; set; }

    [JsonPropertyName("universes")]
    [XmlArray("universes")]
    [XmlArrayItem("universe")]
    public List<Universe> Universes { get; set; } = [];
}

public sealed class AudienceMetric
{
    [Required]
    [JsonPropertyName("audienceMetric")]
    [XmlElement("audienceMetric")]
    public AudienceMetricType? Metric { get; set; }

    [Required]
    [JsonPropertyName("audienceMetricValue")]
    [XmlElement("audienceMetricValue")]
    public int? AudienceMetricValue { get; set; }
}

public sealed class PricingMetric
{
    [Required]
    [JsonPropertyName("PricingMetricOption")]
    [XmlElement("PricingMetricOption")]
    public PricingMetricOptionType? PricingMetricOption { get; set; }

    [Required]
    [JsonPropertyName("grossValue")]
    [XmlElement("grossValue")]
    public decimal? GrossValue { get; set; }

    [JsonPropertyName("netValue")]
    [XmlElement("netValue")]
    public decimal? NetValue { get; set; }
}

public sealed class AudiencePricingMetric
{
    [Required, MinLength(1)]
    [JsonPropertyName("audienceSegmentIds")]
    [XmlArray("audienceSegmentIds")]
    [XmlArrayItem("identifier")]
    public List<Identifier?> AudienceSegmentIds { get; set; } = [];

    [JsonPropertyName("type")]
    [XmlElement("type")]
    public AudiencePricingMetricType? Type { get; set; }

    [JsonPropertyName("audienceMetric")]
    [XmlElement("audienceMetric")]
    public AudienceMetric? AudienceMetric { get; set; }

    [Required]
    [JsonPropertyName("pricingMetric")]
    [XmlElement("pricingMetric")]
    public PricingMetric? PricingMetric { get; set; }
}

public sealed class AudienceTarget
{
    [Required]
    [JsonPropertyName("excludeOrInclude")]
    [XmlElement("excludeOrInclude")]
    public IncludeOrExclude? ExcludeOrInclude { get; set; }

    [JsonPropertyName("audienceTargetIds")]
    [XmlArray("audienceTargetIds")]
    [XmlArrayItem("identifier")]
    public List<Identifier?> AudienceTargetIds { get; set; } = [];

    [Required]
    [JsonPropertyName("targetAttribute")]
    [XmlElement("targetAttribute")]
    public string? TargetAttribute { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("value")]
    [XmlArray("value")]
    [XmlArrayItem("item")]
    public List<string> Value { get; set; } = [];
}

public sealed class PacingRule
{
    [Required]
    [JsonPropertyName("type")]
    [XmlElement("type")]
    public PacingRuleType? Type { get; set; }

    [JsonPropertyName("rateType")]
    [XmlElement("rateType")]
    public PacingRateType? RateType { get; set; }
}

public sealed class DailyUnitDistribution
{
    [JsonPropertyName("pacingRule")]
    [XmlElement("pacingRule")]
    public PacingRule? PacingRule { get; set; }

    [JsonPropertyName("monday")]
    [XmlElement("monday")]
    public int? Monday { get; set; }

    [JsonPropertyName("tuesday")]
    [XmlElement("tuesday")]
    public int? Tuesday { get; set; }

    [JsonPropertyName("wednesday")]
    [XmlElement("wednesday")]
    public int? Wednesday { get; set; }

    [JsonPropertyName("thursday")]
    [XmlElement("thursday")]
    public int? Thursday { get; set; }

    [JsonPropertyName("friday")]
    [XmlElement("friday")]
    public int? Friday { get; set; }

    [JsonPropertyName("saturday")]
    [XmlElement("saturday")]
    public int? Saturday { get; set; }

    [JsonPropertyName("sunday")]
    [XmlElement("sunday")]
    public int? Sunday { get; set; }
}

public sealed class SalesElementTransactionDate : ITipValidatable
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

    [JsonPropertyName("unitCount")]
    [XmlElement("unitCount")]
    public int? UnitCount { get; set; }

    [JsonPropertyName("dailyUnitDistribution")]
    [XmlElement("dailyUnitDistribution")]
    public DailyUnitDistribution? DailyUnitDistribution { get; set; }

    [JsonPropertyName("frequencyCappings")]
    [XmlArray("frequencyCappings")]
    [XmlArrayItem("frequencyCapping")]
    public List<FrequencyCapping> FrequencyCappings { get; set; } = [];

    [JsonPropertyName("pricingMetric")]
    [XmlElement("pricingMetric")]
    public PricingMetric? PricingMetric { get; set; }

    [JsonPropertyName("grossCost")]
    [XmlElement("grossCost")]
    public decimal? GrossCost { get; set; }

    [JsonPropertyName("netCost")]
    [XmlElement("netCost")]
    public decimal? NetCost { get; set; }

    [JsonPropertyName("audienceTargets")]
    [XmlArray("audienceTargets")]
    [XmlArrayItem("audienceTarget")]
    public List<AudienceTarget> AudienceTargets { get; set; } = [];

    [JsonPropertyName("audiencesPricingMetrics")]
    [XmlArray("audiencesPricingMetrics")]
    [XmlArrayItem("audiencePricingMetric")]
    public List<AudiencePricingMetric> AudiencesPricingMetrics { get; set; } = [];

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (UnitCount is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(UnitCount)), "unitCount must be zero or greater.");
        }
    }
}

public sealed class SalesElementTransactionInventory : ITipValidatable
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
    public List<Identifier?> LineReferences { get; set; } = [];

    [Required]
    [JsonPropertyName("inventoryType")]
    [XmlElement("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("companionTypeIds")]
    [XmlArray("companionTypeIds")]
    [XmlArrayItem("item")]
    public List<string> CompanionTypeIds { get; set; } = [];

    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkType? LinkType { get; set; }

    [JsonPropertyName("inventoryPosition")]
    [XmlElement("inventoryPosition")]
    public InventoryPositionType? InventoryPosition { get; set; }

    [JsonPropertyName("inventoryLength")]
    [XmlElement("inventoryLength")]
    public int? InventoryLength { get; set; }

    [JsonPropertyName("isAdu")]
    [XmlElement("isAdu")]
    public bool? IsAdu { get; set; }

    [JsonPropertyName("isBonus")]
    [XmlElement("isBonus")]
    public bool? IsBonus { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("salesElementTransactionDates")]
    [XmlArray("salesElementTransactionDates")]
    [XmlArrayItem("salesElementTransactionDate")]
    public List<SalesElementTransactionDate> SalesElementTransactionDates { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (InventoryLength is < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InventoryLength)), "inventoryLength must be zero or greater when supplied.");
        }
    }
}

public sealed class SalesElementTransaction
{
    [Required]
    [JsonPropertyName("salesElementHeader")]
    [XmlElement("salesElementHeader")]
    public SalesElementHeader? SalesElementHeader { get; set; }

    [Required, MinLength(1)]
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

    [Required, MinLength(1)]
    [JsonPropertyName("salesElementTransactionInventorys")]
    [XmlArray("salesElementTransactionInventorys")]
    [XmlArrayItem("salesElementTransactionInventory")]
    public List<SalesElementTransactionInventory> SalesElementTransactionInventorys { get; set; } = [];
}
