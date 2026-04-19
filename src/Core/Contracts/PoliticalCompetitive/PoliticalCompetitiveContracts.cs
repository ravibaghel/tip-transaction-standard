using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.PoliticalCompetitive;

[XmlRoot("SellerPoliticalCompetitives", Namespace = TipXml.Namespace)]
public sealed class SellerPoliticalCompetitivesRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("politicalCompetitive")]
    [XmlArray("politicalCompetitive")]
    [XmlArrayItem("politicalCompetitive")]
    public List<PoliticalCompetitiveDetail> PoliticalCompetitive { get; set; } = [];
}

public sealed class PoliticalCompetitiveDetail : ITipValidatable
{
    [Required, MinLength(1)]
    [JsonPropertyName("ids")]
    [XmlArray("ids")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> Ids { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("lineNumber")]
    [XmlArray("lineNumber")]
    [XmlArrayItem("identifier")]
    public List<Identifier> LineNumber { get; set; } = [];

    [Required]
    [JsonPropertyName("flightStart")]
    [XmlElement("flightStart")]
    public string? FlightStart { get; set; }

    [Required]
    [JsonPropertyName("flightEnd")]
    [XmlElement("flightEnd")]
    public string? FlightEnd { get; set; }

    [Required]
    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Company? Advertiser { get; set; }

    [Required]
    [JsonPropertyName("agency")]
    [XmlElement("agency")]
    public Company? Agency { get; set; }

    [Required]
    [JsonPropertyName("airingMediaOutlet")]
    [XmlElement("airingMediaOutlet")]
    public MediaOutlet? AiringMediaOutlet { get; set; }

    [Required]
    [JsonPropertyName("adSeconds")]
    [XmlElement("adSeconds")]
    public int? AdSeconds { get; set; }

    [JsonPropertyName("totalAdSeconds")]
    [XmlElement("totalAdSeconds")]
    public int? TotalAdSeconds { get; set; }

    [Required]
    [JsonPropertyName("totalDollars")]
    [XmlElement("totalDollars")]
    public decimal? TotalDollars { get; set; }

    [Required]
    [JsonPropertyName("state")]
    [XmlElement("state")]
    public string? State { get; set; }

    [Required]
    [JsonPropertyName("repFirm")]
    [XmlElement("repFirm")]
    public Company? RepFirm { get; set; }

    [JsonPropertyName("partyTag")]
    [XmlElement("partyTag")]
    public string? PartyTag { get; set; }

    [JsonPropertyName("candidateTag")]
    [XmlElement("candidateTag")]
    public string? CandidateTag { get; set; }

    [JsonPropertyName("issueTag")]
    [XmlElement("issueTag")]
    public string? IssueTag { get; set; }

    [JsonPropertyName("electionTag")]
    [XmlElement("electionTag")]
    public string? ElectionTag { get; set; }

    [JsonPropertyName("raceTag")]
    [XmlElement("raceTag")]
    public string? RaceTag { get; set; }

    [JsonPropertyName("targetAudienceTag")]
    [XmlElement("targetAudienceTag")]
    public string? TargetAudienceTag { get; set; }

    [JsonPropertyName("geoTargetTag")]
    [XmlElement("geoTargetTag")]
    public string? GeoTargetTag { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TipDateTime.IsDateLike(FlightStart))
        {
            yield return new TipValidationIssue(path.Append(nameof(FlightStart)), "flightStart must be a valid ISO date.");
        }

        if (!TipDateTime.IsDateLike(FlightEnd))
        {
            yield return new TipValidationIssue(path.Append(nameof(FlightEnd)), "flightEnd must be a valid ISO date.");
        }

        if (AdSeconds is <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(AdSeconds)), "adSeconds must be greater than zero.");
        }

        if (TotalAdSeconds < 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(TotalAdSeconds)), "totalAdSeconds cannot be negative.");
        }

        if (TotalDollars is <= 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(TotalDollars)), "totalDollars must be greater than zero.");
        }
    }
}
