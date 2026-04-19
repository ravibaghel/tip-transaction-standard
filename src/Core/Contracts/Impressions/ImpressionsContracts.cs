using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Impressions;

[XmlRoot("BuyerImpressionsSubscriptionRequest", Namespace = TipXml.Namespace)]
public sealed class BuyerImpressionsSubscriptionRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required]
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("salesElementHeaders")]
    [XmlArray("salesElementHeaders")]
    [XmlArrayItem("salesElementHeader")]
    public List<SalesElementHeader> SalesElementHeaders { get; set; } = [];

    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("frequency")]
    [XmlElement("frequency")]
    public Frequency? Frequency { get; set; }

    [JsonPropertyName("startDate")]
    [XmlElement("startDate")]
    public DynamicOrDate? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    [XmlElement("endDate")]
    public DynamicOrDate? EndDate { get; set; }

    [JsonPropertyName("statSource")]
    [XmlElement("statSource")]
    public string? StatSource { get; set; }

    [JsonPropertyName("maxChunkSize")]
    [XmlElement("maxChunkSize")]
    public int? MaxChunkSize { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (MaxChunkSize is <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(MaxChunkSize)), "maxChunkSize must be greater than zero when supplied.");
        }
    }
}

[XmlRoot("SellerImpressionsNotificationRequest", Namespace = TipXml.Namespace)]
public sealed class SellerImpressionsNotificationRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("salesElementHeaders")]
    [XmlArray("salesElementHeaders")]
    [XmlArrayItem("salesElementHeader")]
    public List<SalesElementHeader> SalesElementHeaders { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("creatives")]
    [XmlArray("creatives")]
    [XmlArrayItem("creative")]
    public List<Creative> Creatives { get; set; } = [];

    [Required]
    [JsonPropertyName("reportDate")]
    [XmlElement("reportDate")]
    public DateWindow? ReportDate { get; set; }

    [Required]
    [JsonPropertyName("statSource")]
    [XmlElement("statSource")]
    public string? StatSource { get; set; }

    [Required]
    [JsonPropertyName("filePrefix")]
    [XmlElement("filePrefix")]
    public string? FilePrefix { get; set; }

    [Required]
    [JsonPropertyName("chunks")]
    [XmlElement("chunks")]
    public int? Chunks { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Chunks is <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Chunks)), "chunks must be greater than zero.");
        }
    }
}
