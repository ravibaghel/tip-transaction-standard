using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Serialization;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class Identifier
{
    [Required]
    [JsonPropertyName("id")]
    [XmlElement("id")]
    public string? Id { get; set; }

    [JsonPropertyName("version")]
    [XmlElement("version")]
    public string? Version { get; set; }

    [JsonPropertyName("srcId")]
    [XmlElement("srcId")]
    public string? SourceId { get; set; }

    [Required]
    [JsonPropertyName("srcName")]
    [XmlElement("srcName")]
    public string? SourceName { get; set; }
}

public sealed class ReferenceId
{
    [Required]
    [JsonPropertyName("referenceSourceName")]
    [XmlElement("referenceSourceName")]
    public string? ReferenceSourceName { get; set; }

    [Required]
    [JsonPropertyName("referenceSourceId")]
    [XmlElement("referenceSourceId")]
    public string? ReferenceSourceId { get; set; }

    [JsonPropertyName("referenceSourceLookup")]
    [XmlElement("referenceSourceLookup")]
    public string? ReferenceSourceLookup { get; set; }

    [Required]
    [JsonPropertyName("referenceType")]
    [XmlElement("referenceType")]
    public ReferenceType? ReferenceType { get; set; }

    [JsonPropertyName("referenceId")]
    [XmlElement("referenceId")]
    [JsonConverter(typeof(FlexibleStringJsonConverter))]
    public string? Value { get; set; }

    [JsonPropertyName("referenceVersionId")]
    [XmlElement("referenceVersionId")]
    [JsonConverter(typeof(FlexibleStringJsonConverter))]
    public string? ReferenceVersionId { get; set; }

    [JsonPropertyName("referenceName")]
    [XmlElement("referenceName")]
    public string? ReferenceName { get; set; }
}
