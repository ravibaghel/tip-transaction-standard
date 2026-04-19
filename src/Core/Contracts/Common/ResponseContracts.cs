using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tip.TransactionStandard.Contracts.Common;

[XmlRoot("AcceptedResponse", Namespace = TipXml.Namespace)]
public sealed class AcceptedResponse
{
    [Required]
    [JsonPropertyName("transactionId")]
    [XmlElement("transactionId")]
    public string? TransactionId { get; set; }

    [Required]
    [JsonPropertyName("timeStamp")]
    [XmlElement("timeStamp")]
    public string? TimeStamp { get; set; }
}

[XmlRoot("Error", Namespace = TipXml.Namespace)]
public sealed class ErrorResponse
{
    [Required]
    [JsonPropertyName("errorCode")]
    [XmlElement("errorCode")]
    public int? ErrorCode { get; set; }

    [Required]
    [JsonPropertyName("errorMessage")]
    [XmlElement("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("errorList")]
    [XmlIgnore]
    public Dictionary<string, string> ErrorList { get; set; } = new(StringComparer.Ordinal);
}
