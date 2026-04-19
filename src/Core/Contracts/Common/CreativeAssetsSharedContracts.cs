using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class Format : ITipValidatable
{
    [Required]
    [JsonPropertyName("container")]
    [XmlElement("container")]
    public string? Container { get; set; }

    [Required]
    [JsonPropertyName("video")]
    [XmlElement("video")]
    public string? Video { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("audio")]
    [XmlArray("audio")]
    [XmlArrayItem("item")]
    public List<string> Audio { get; set; } = [];

    [JsonPropertyName("aspect")]
    [XmlElement("aspect")]
    public string? Aspect { get; set; }

    [JsonPropertyName("resolution")]
    [XmlElement("resolution")]
    public string? Resolution { get; set; }

    [JsonPropertyName("screen")]
    [XmlElement("screen")]
    public string? Screen { get; set; }

    [JsonPropertyName("bitRate")]
    [XmlElement("bitRate")]
    public string? BitRate { get; set; }

    [Required]
    [JsonPropertyName("duration")]
    [XmlElement("duration")]
    public string? Duration { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (Audio.Count > 0 && Audio.Any(string.IsNullOrWhiteSpace))
        {
            yield return new TipValidationIssue(path.Append(nameof(Audio)), "audio entries must not be empty.");
        }
    }
}
