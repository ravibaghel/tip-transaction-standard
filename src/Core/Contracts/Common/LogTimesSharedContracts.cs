using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class SalesElementHeader
{
    [Required]
    [JsonPropertyName("mediaOutletId")]
    [XmlElement("mediaOutletId")]
    public string? MediaOutletId { get; set; }

    [Required]
    [JsonPropertyName("salesElementName")]
    [XmlElement("salesElementName")]
    public string? SalesElementName { get; set; }

    [Required]
    [JsonPropertyName("salesElementId")]
    [XmlElement("salesElementId")]
    public string? SalesElementId { get; set; }

    [Required]
    [JsonPropertyName("salesElementType")]
    [XmlElement("salesElementType")]
    public SalesElementType? SalesElementType { get; set; }
}

public sealed class Creative
{
    [Required, MinLength(1)]
    [JsonPropertyName("ids")]
    [XmlElement("ids")]
    public List<Identifier> Ids { get; set; } = [];

    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    [XmlElement("status")]
    public CreativeStatus? Status { get; set; }

    [JsonPropertyName("length")]
    [XmlElement("length")]
    public int? Length { get; set; }
}

public sealed class TipDateTime : ITipValidatable
{
    [JsonPropertyName("broadcastDate")]
    [XmlElement("broadcastDate")]
    public string? BroadcastDate { get; set; }

    [JsonPropertyName("calendarDateTime")]
    [XmlElement("calendarDateTime")]
    public string? CalendarDateTime { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(BroadcastDate) && !DateOnly.TryParse(BroadcastDate, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(BroadcastDate)), "broadcastDate must be a valid ISO date.");
        }

        if (!string.IsNullOrWhiteSpace(CalendarDateTime) && !DateTimeOffset.TryParse(CalendarDateTime, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(CalendarDateTime)), "calendarDateTime must be a valid ISO date-time.");
        }
    }
}

public sealed class DateWindow : ITipValidatable
{
    [Required]
    [JsonPropertyName("startDate")]
    [XmlElement("startDate")]
    public string? StartDate { get; set; }

    [Required]
    [JsonPropertyName("endDate")]
    [XmlElement("endDate")]
    public string? EndDate { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(StartDate) && !DateOnly.TryParse(StartDate, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(StartDate)), "startDate must be a valid ISO date.");
        }

        if (!string.IsNullOrWhiteSpace(EndDate) && !DateOnly.TryParse(EndDate, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(EndDate)), "endDate must be a valid ISO date.");
        }
    }
}

public sealed class DayOfWeekSelection
{
    [JsonPropertyName("isMonday")]
    [XmlElement("isMonday")]
    public bool IsMonday { get; set; }

    [JsonPropertyName("isTuesday")]
    [XmlElement("isTuesday")]
    public bool IsTuesday { get; set; }

    [JsonPropertyName("isWednesday")]
    [XmlElement("isWednesday")]
    public bool IsWednesday { get; set; }

    [JsonPropertyName("isThursday")]
    [XmlElement("isThursday")]
    public bool IsThursday { get; set; }

    [JsonPropertyName("isFriday")]
    [XmlElement("isFriday")]
    public bool IsFriday { get; set; }

    [JsonPropertyName("isSaturday")]
    [XmlElement("isSaturday")]
    public bool IsSaturday { get; set; }

    [JsonPropertyName("isSunday")]
    [XmlElement("isSunday")]
    public bool IsSunday { get; set; }
}

public sealed class TimeWindow : ITipValidatable
{
    [Required]
    [JsonPropertyName("startTime")]
    [XmlElement("startTime")]
    public string? StartTime { get; set; }

    [Required]
    [JsonPropertyName("endTime")]
    [XmlElement("endTime")]
    public string? EndTime { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TimeOnly.TryParse(StartTime, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(StartTime)), "startTime must be a valid HH:mm:ss value.");
        }

        if (!TimeOnly.TryParse(EndTime, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(EndTime)), "endTime must be a valid HH:mm:ss value.");
        }
    }
}

public sealed class TimePeriod
{
    [Required]
    [JsonPropertyName("dateWindow")]
    [XmlElement("dateWindow")]
    public DateWindow? DateWindow { get; set; }

    [Required]
    [JsonPropertyName("DOW")]
    [XmlElement("DOW")]
    public DayOfWeekSelection? DOW { get; set; }

    [JsonPropertyName("timeWindow")]
    [XmlElement("timeWindow")]
    public TimeWindow? TimeWindow { get; set; }
}

public sealed class LinkType
{
    [Required]
    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkTypeCode? Type { get; set; }

    [JsonPropertyName("linkNum")]
    [XmlElement("linkNum")]
    public int? LinkNumber { get; set; }
}
