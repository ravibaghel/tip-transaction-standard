using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tip.TransactionStandard.Contracts.Common;

public sealed class MediaOutlet
{
    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutletIds")]
    [XmlElement("mediaOutletIds")]
    public List<Identifier> MediaOutletIds { get; set; } = [];

    [Required]
    [JsonPropertyName("mediaOutletName")]
    [XmlElement("mediaOutletName")]
    public string? MediaOutletName { get; set; }

    [Required]
    [JsonPropertyName("mediaOutletType")]
    [XmlElement("mediaOutletType")]
    public string? MediaOutletType { get; set; }

    [JsonPropertyName("mediaOutletChannel")]
    [XmlElement("mediaOutletChannel")]
    public string? MediaOutletChannel { get; set; }

    [JsonPropertyName("mediaOutletMarketName")]
    [XmlElement("mediaOutletMarketName")]
    public string? MediaOutletMarketName { get; set; }

    [JsonPropertyName("mediaOutletReference")]
    [XmlElement("mediaOutletReference")]
    public string? MediaOutletReference { get; set; }
}

public sealed class Advertiser
{
    [Required, MinLength(1)]
    [JsonPropertyName("advertiserIds")]
    [XmlElement("advertiserIds")]
    public List<Identifier> AdvertiserIds { get; set; } = [];

    [Required]
    [JsonPropertyName("advertiserName")]
    [XmlElement("advertiserName")]
    public string? AdvertiserName { get; set; }

    [JsonPropertyName("advertiserReference")]
    [XmlElement("advertiserReference")]
    public string? AdvertiserReference { get; set; }
}

public sealed class Brand
{
    [Required, MinLength(1)]
    [JsonPropertyName("brandIds")]
    [XmlElement("brandIds")]
    public List<Identifier> BrandIds { get; set; } = [];

    [Required]
    [JsonPropertyName("brandName")]
    [XmlElement("brandName")]
    public string? BrandName { get; set; }

    [JsonPropertyName("brandReference")]
    [XmlElement("brandReference")]
    public string? BrandReference { get; set; }
}

public sealed class Buyer
{
    [Required, MinLength(1)]
    [JsonPropertyName("buyerIds")]
    [XmlElement("buyerIds")]
    public List<Identifier> BuyerIds { get; set; } = [];

    [Required]
    [JsonPropertyName("buyerName")]
    [XmlElement("buyerName")]
    public string? BuyerName { get; set; }

    [JsonPropertyName("buyerReference")]
    [XmlElement("buyerReference")]
    public string? BuyerReference { get; set; }
}

public sealed class Company
{
    [Required, MinLength(1)]
    [JsonPropertyName("ids")]
    [XmlArray("ids")]
    [XmlArrayItem("identifier")]
    public List<Identifier> Ids { get; set; } = [];

    [Required]
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reference")]
    [XmlElement("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("offices")]
    [XmlArray("offices")]
    [XmlArrayItem("item")]
    public List<string> Offices { get; set; } = [];
}

public sealed class Product
{
    [Required, MinLength(1)]
    [JsonPropertyName("productIds")]
    [XmlElement("productIds")]
    public List<Identifier> ProductIds { get; set; } = [];

    [Required]
    [JsonPropertyName("productName")]
    [XmlElement("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("productReference")]
    [XmlElement("productReference")]
    public string? ProductReference { get; set; }
}

public sealed class CpeCode
{
    [JsonPropertyName("clientCode")]
    [XmlElement("clientCode")]
    public string? ClientCode { get; set; }

    [JsonPropertyName("productCode")]
    [XmlElement("productCode")]
    public string? ProductCode { get; set; }

    [JsonPropertyName("estimateCode")]
    [XmlElement("estimateCode")]
    public string? EstimateCode { get; set; }
}
