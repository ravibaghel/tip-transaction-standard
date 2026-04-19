using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.Invoices;

[XmlRoot("SellerInvoices", Namespace = TipXml.Namespace)]
public sealed class SellerInvoicesRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlArray("referenceIds")]
    [XmlArrayItem("referenceId")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [Required]
    [JsonPropertyName("invoiceDate")]
    [XmlElement("invoiceDate")]
    public string? InvoiceDate { get; set; }

    [JsonPropertyName("invoiceRevisionDate")]
    [XmlElement("invoiceRevisionDate")]
    public string? InvoiceRevisionDate { get; set; }

    [JsonPropertyName("billingOption")]
    [XmlElement("billingOption")]
    public BillingOption? BillingOption { get; set; }

    [JsonPropertyName("dueDate")]
    [XmlElement("dueDate")]
    public string? DueDate { get; set; }

    [Required]
    [JsonPropertyName("dateWindow")]
    [XmlElement("dateWindow")]
    public DateWindow? DateWindow { get; set; }

    [JsonPropertyName("businessType")]
    [XmlElement("businessType")]
    public string? BusinessType { get; set; }

    [Required]
    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("localNational")]
    [XmlElement("localNational")]
    public MarketScope? LocalNational { get; set; }

    [Required]
    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [JsonPropertyName("contacts")]
    [XmlArray("contacts")]
    [XmlArrayItem("contact")]
    public List<Contact> Contacts { get; set; } = [];

    [Required]
    [JsonPropertyName("revenueType")]
    [XmlElement("revenueType")]
    public RevenueType? RevenueType { get; set; }

    [Required]
    [JsonPropertyName("grossAmount")]
    [XmlElement("grossAmount")]
    public decimal? GrossAmount { get; set; }

    [Required]
    [JsonPropertyName("commission")]
    [XmlElement("commission")]
    public decimal? Commission { get; set; }

    [JsonPropertyName("salesTaxes")]
    [XmlArray("salesTaxes")]
    [XmlArrayItem("itemDetail")]
    public List<ItemDetail> SalesTaxes { get; set; } = [];

    [JsonPropertyName("discounts")]
    [XmlArray("discounts")]
    [XmlArrayItem("itemDetail")]
    public List<ItemDetail> Discounts { get; set; } = [];

    [Required]
    [JsonPropertyName("netAmount")]
    [XmlElement("netAmount")]
    public decimal? NetAmount { get; set; }

    [JsonPropertyName("currency")]
    [XmlElement("currency")]
    public CurrencyCode? Currency { get; set; }

    [Required]
    [JsonPropertyName("remittanceInfo")]
    [XmlElement("remittanceInfo")]
    public RemittanceInfo? RemittanceInfo { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("mediaOutlets")]
    [XmlArray("mediaOutlets")]
    [XmlArrayItem("mediaOutlet")]
    public List<MediaOutlet> MediaOutlets { get; set; } = [];

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("lineDetails")]
    [XmlArray("lineDetails")]
    [XmlArrayItem("lineDetail")]
    public List<InvoiceLineDetail> LineDetails { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!TipDateTime.IsDateLike(InvoiceDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(InvoiceDate)), "invoiceDate must be a valid ISO date.");
        }

        if (!string.IsNullOrWhiteSpace(InvoiceRevisionDate) && !TipDateTime.IsDateLike(InvoiceRevisionDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(InvoiceRevisionDate)), "invoiceRevisionDate must be a valid ISO date.");
        }

        if (!string.IsNullOrWhiteSpace(DueDate) && !TipDateTime.IsDateLike(DueDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(DueDate)), "dueDate must be a valid ISO date.");
        }
    }
}
