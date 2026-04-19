using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class Contact : ITipValidatable
{
    [JsonPropertyName("contactType")]
    [XmlElement("contactType")]
    public ContactType? ContactType { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("contactIds")]
    [XmlElement("contactIds")]
    public List<Identifier> ContactIds { get; set; } = [];

    [JsonPropertyName("organizationIds")]
    [XmlElement("organizationIds")]
    public List<Identifier> OrganizationIds { get; set; } = [];

    [JsonPropertyName("salesOffices")]
    [XmlElement("salesOffices")]
    public List<string> SalesOffices { get; set; } = [];

    [JsonPropertyName("contactFirstName")]
    [XmlElement("contactFirstName")]
    public string? ContactFirstName { get; set; }

    [JsonPropertyName("contactLastName")]
    [XmlElement("contactLastName")]
    public string? ContactLastName { get; set; }

    [JsonPropertyName("addressLine1")]
    [XmlElement("addressLine1")]
    public string? AddressLine1 { get; set; }

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

    [JsonPropertyName("email")]
    [XmlElement("email")]
    public string? Email { get; set; }

    [JsonPropertyName("effectiveDate")]
    [XmlElement("effectiveDate")]
    public string? EffectiveDate { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(EffectiveDate) && !TipDateTime.IsDateLike(EffectiveDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(EffectiveDate)), "effectiveDate must be a valid ISO date.");
        }
    }
}

public sealed class Frequency : ITipValidatable
{
    [JsonPropertyName("effectiveOn")]
    [XmlElement("effectiveOn")]
    public string? EffectiveOn { get; set; }

    [JsonPropertyName("every")]
    [XmlElement("every")]
    public FrequencyEvery? Every { get; set; }

    [JsonPropertyName("onDay")]
    [XmlElement("onDay")]
    public List<SubscriptionDay> OnDay { get; set; } = [];

    [JsonPropertyName("onDate")]
    [XmlElement("onDate")]
    public List<int> OnDate { get; set; } = [];

    [JsonPropertyName("isEndNever")]
    [XmlElement("isEndNever")]
    public bool? IsEndNever { get; set; }

    [JsonPropertyName("endOn")]
    [XmlElement("endOn")]
    public string? EndOn { get; set; }

    [JsonPropertyName("endOccurAfter")]
    [XmlElement("endOccurAfter")]
    public int? EndOccurAfter { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(EffectiveOn) && !DateTimeOffset.TryParse(EffectiveOn, out _))
        {
            yield return new TipValidationIssue(path.Append(nameof(EffectiveOn)), "effectiveOn must be a valid ISO date or date-time.");
        }

        if (!string.IsNullOrWhiteSpace(EndOn) && !TipDateTime.IsDateLike(EndOn))
        {
            yield return new TipValidationIssue(path.Append(nameof(EndOn)), "endOn must be a valid ISO date.");
        }
    }
}

public sealed class CancelConfirmRecallReject
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlElement("referenceIds")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("comments")]
    [XmlElement("comments")]
    public string? Comments { get; set; }
}
