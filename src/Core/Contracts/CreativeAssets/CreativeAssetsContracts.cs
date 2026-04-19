using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.CreativeAssets;

[XmlRoot("BuyerCreativeAssets", Namespace = TipXml.Namespace)]
public sealed class BuyerCreativeAssetsRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required]
    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public string? Creative { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("timePeriods")]
    [XmlArray("timePeriods")]
    [XmlArrayItem("timePeriod")]
    public List<TimePeriod> TimePeriods { get; set; } = [];

    [JsonPropertyName("formats")]
    [XmlArray("formats")]
    [XmlArrayItem("format")]
    public List<Format> Formats { get; set; } = [];

    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [Required]
    [JsonPropertyName("deliveryDate")]
    [XmlElement("deliveryDate")]
    public string? DeliveryDate { get; set; }

    [Required]
    [JsonPropertyName("deliveryService")]
    [XmlElement("deliveryService")]
    public string? DeliveryService { get; set; }

    [Required]
    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("brand")]
    [XmlElement("brand")]
    public Brand? Brand { get; set; }

    [Required]
    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("guideLines")]
    [XmlArray("guideLines")]
    [XmlArrayItem("guideline")]
    public List<Guideline> Guidelines { get; set; } = [];

    [JsonPropertyName("comment")]
    [XmlElement("comment")]
    public string? Comment { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TipDateTime.IsDateLike(DeliveryDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(DeliveryDate)), "deliveryDate must be a valid ISO date.");
        }
    }
}
