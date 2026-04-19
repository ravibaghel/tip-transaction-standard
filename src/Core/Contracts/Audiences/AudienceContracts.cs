using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Audiences;

[XmlRoot("BuyerAudiencesSubscription", Namespace = TipXml.Namespace)]
public sealed class BuyerAudiencesSubscriptionRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required]
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("buyers")]
    [XmlArray("buyers")]
    [XmlArrayItem("buyer")]
    public List<Buyer> Buyers { get; set; } = [];

    [JsonPropertyName("advertisers")]
    [XmlArray("advertisers")]
    [XmlArrayItem("advertiser")]
    public List<Advertiser> Advertisers { get; set; } = [];

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("audienceTargets")]
    [XmlArray("audienceTargets")]
    [XmlArrayItem("audienceTarget")]
    public List<AudienceTarget> AudienceTargets { get; set; } = [];

    [JsonPropertyName("audienceSegments")]
    [XmlArray("audienceSegments")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegment> AudienceSegments { get; set; } = [];

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [JsonPropertyName("frequency")]
    [XmlElement("frequency")]
    public Frequency? Frequency { get; set; }

    [JsonPropertyName("startDate")]
    [XmlElement("startDate")]
    public DynamicOrDate? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    [XmlElement("endDate")]
    public DynamicOrDate? EndDate { get; set; }

    [JsonPropertyName("buyer")]
    [XmlArray("buyer")]
    [XmlArrayItem("buyer")]
    public List<Buyer> BuyerAlias
    {
        get => Buyers;
        set => Buyers = value ?? [];
    }

    [JsonPropertyName("advertiser")]
    [XmlArray("advertiser")]
    [XmlArrayItem("advertiser")]
    public List<Advertiser> AdvertiserAlias
    {
        get => Advertisers;
        set => Advertisers = value ?? [];
    }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (ReferenceIds.Count > 0 && ReferenceIds.Any(x => x.ReferenceType is null))
        {
            yield return new TipValidationIssue(path.Append(nameof(ReferenceIds)), "referenceIds must include a referenceType when supplied.");
        }
    }
}

[XmlRoot("SellerAudiences", Namespace = TipXml.Namespace)]
public sealed class SellerAudiencesRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("audienceSegments")]
    [XmlArray("audienceSegments")]
    [XmlArrayItem("audienceSegment")]
    public List<AudienceSegmentDetail> AudienceSegments { get; set; } = [];

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("audienceDetails")]
    [XmlArray("audienceDetails")]
    [XmlArrayItem("audienceDetail")]
    public List<AudienceDetail> AudienceDetails { get; set; } = [];
}
