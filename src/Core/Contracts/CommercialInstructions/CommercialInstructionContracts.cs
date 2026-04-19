using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Validation;

namespace Tip.TransactionStandard.Contracts.CommercialInstructions;

[XmlRoot("BuyerCommercialInstructions", Namespace = TipXml.Namespace)]
public sealed class BuyerCommercialInstructionsRequest : ITipValidatable
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlElement("referenceIds")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("buyer")]
    [XmlElement("buyer")]
    public Buyer? Buyer { get; set; }

    [JsonPropertyName("contacts")]
    [XmlElement("contacts")]
    public List<Contact> Contacts { get; set; } = [];

    [Required]
    [JsonPropertyName("advertiser")]
    [XmlElement("advertiser")]
    public Advertiser? Advertiser { get; set; }

    [Required]
    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [Required]
    [JsonPropertyName("dateWindow")]
    [XmlElement("dateWindow")]
    public DateWindow? DateWindow { get; set; }

    [JsonPropertyName("cpeCode")]
    [XmlElement("cpeCode")]
    public CpeCode? CpeCode { get; set; }

    [JsonPropertyName("instructionComment")]
    [XmlElement("instructionComment")]
    public string? InstructionComment { get; set; }

    [JsonPropertyName("externalComment")]
    [XmlElement("externalComment")]
    public string? ExternalComment { get; set; }

    [Required]
    [JsonPropertyName("instructionType")]
    [XmlElement("instructionType")]
    public CommercialInstructionType? InstructionType { get; set; }

    [JsonPropertyName("instructionDetails")]
    [XmlElement("instructionDetails")]
    public List<InstructionDetail> InstructionDetails { get; set; } = [];

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (InstructionDetails.Count == 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(InstructionDetails)), "instructionDetails should contain at least one instruction detail for actionable requests.");
        }

        if (Contacts.Count == 0)
        {
            yield return new TipValidationIssue(path.Append(nameof(Contacts)), "contacts should contain at least one contact based on the current TIP commercial instructions guidance.");
        }

        if (InstructionType is not null)
        {
            for (var i = 0; i < InstructionDetails.Count; i++)
            {
                foreach (var issue in InstructionDetails[i].ValidateForInstructionType($"{path}.{nameof(InstructionDetails)}[{i}]", InstructionType.Value))
                {
                    yield return issue;
                }
            }
        }
    }
}

[XmlRoot("SellerCommercialInstructions", Namespace = TipXml.Namespace)]
public sealed class SellerCommercialInstructionsRequest
{
    [Required]
    [JsonPropertyName("transactionHeader")]
    [XmlElement("transactionHeader")]
    public TransactionHeader? TransactionHeader { get; set; }

    [Required, MinLength(1)]
    [JsonPropertyName("referenceIds")]
    [XmlElement("referenceIds")]
    public List<ReferenceId> ReferenceIds { get; set; } = [];

    [JsonPropertyName("comments")]
    [XmlElement("comments")]
    public string? Comments { get; set; }
}

public sealed class InstructionDetail : ITipValidatable
{
    [Required]
    [JsonPropertyName("actionType")]
    [XmlElement("actionType")]
    public InstructionActionType? ActionType { get; set; }

    [JsonPropertyName("inventoryTypes")]
    [XmlElement("inventoryTypes")]
    public List<string> InventoryTypes { get; set; } = [];

    [Required]
    [JsonPropertyName("mediaOutlet")]
    [XmlElement("mediaOutlet")]
    public MediaOutlet? MediaOutlet { get; set; }

    [Required]
    [JsonPropertyName("creative")]
    [XmlElement("creative")]
    public Creative? Creative { get; set; }

    [JsonPropertyName("brand")]
    [XmlElement("brand")]
    public Brand? Brand { get; set; }

    [JsonPropertyName("product")]
    [XmlElement("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("linkType")]
    [XmlElement("linkType")]
    public LinkType? LinkType { get; set; }

    [JsonPropertyName("deliveryDate")]
    [XmlElement("deliveryDate")]
    public string? DeliveryDate { get; set; }

    [Required]
    [JsonPropertyName("deliveryService")]
    [XmlElement("deliveryService")]
    public string? DeliveryService { get; set; }

    [JsonPropertyName("timePeriods")]
    [XmlElement("timePeriods")]
    public List<TimePeriod> TimePeriods { get; set; } = [];

    [JsonPropertyName("rotationShare")]
    [XmlElement("rotationShare")]
    public int? RotationShare { get; set; }

    [JsonPropertyName("patternInstruction")]
    [XmlElement("patternInstruction")]
    public string? PatternInstruction { get; set; }

    [JsonPropertyName("unitSpecificInstructions")]
    [XmlElement("unitSpecificInstructions")]
    public List<string> UnitSpecificInstructions { get; set; } = [];

    [JsonPropertyName("specialInstructions")]
    [XmlElement("specialInstructions")]
    public string? SpecialInstructions { get; set; }

    public IEnumerable<TipValidationIssue> Validate(string path)
    {
        if (!string.IsNullOrWhiteSpace(DeliveryDate) && !TipDateTime.IsDateLike(DeliveryDate))
        {
            yield return new TipValidationIssue(path.Append(nameof(DeliveryDate)), "deliveryDate must be a valid ISO date.");
        }
    }

    public IEnumerable<TipValidationIssue> ValidateForInstructionType(string path, CommercialInstructionType instructionType)
    {
        foreach (var issue in Validate(path))
        {
            yield return issue;
        }

        switch (instructionType)
        {
            case CommercialInstructionType.RotationShare when RotationShare is null:
                yield return new TipValidationIssue(path.Append(nameof(RotationShare)), "rotationShare is required when instructionType is 'Rotation Share'.");
                break;
            case CommercialInstructionType.Pattern when string.IsNullOrWhiteSpace(PatternInstruction):
                yield return new TipValidationIssue(path.Append(nameof(PatternInstruction)), "patternInstruction is required when instructionType is 'Pattern'.");
                break;
            case CommercialInstructionType.UnitSpecific when UnitSpecificInstructions.Count == 0:
                yield return new TipValidationIssue(path.Append(nameof(UnitSpecificInstructions)), "unitSpecificInstructions must contain at least one unit id when instructionType is 'Unit Specific'.");
                break;
        }
    }
}
