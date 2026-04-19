using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class TransactionHeader
{
    [Required]
    [JsonPropertyName("tipVersion")]
    [XmlElement("tipVersion")]
    public string? TipVersion { get; set; }

    [Required]
    [JsonPropertyName("transactionId")]
    [XmlElement("transactionId")]
    public TransactionIdentifier? TransactionId { get; set; }

    [JsonPropertyName("originalTransactionId")]
    [XmlElement("originalTransactionId")]
    public TransactionIdentifier? OriginalTransactionId { get; set; }

    [Required]
    [JsonPropertyName("timeStamp")]
    [XmlElement("timeStamp")]
    public string? TimeStamp { get; set; }
}

public sealed class TransactionIdentifier
{
    [Required]
    [JsonPropertyName("transactionId")]
    [XmlElement("transactionId")]
    public string? Id { get; set; }

    [Required]
    [JsonPropertyName("transactionType")]
    [XmlElement("transactionType")]
    public TransactionType? TransactionType { get; set; }

    [Required]
    [JsonPropertyName("sourceId")]
    [XmlElement("sourceId")]
    public string? SourceId { get; set; }

    [Required]
    [JsonPropertyName("sourceName")]
    [XmlElement("sourceName")]
    public string? SourceName { get; set; }
}
