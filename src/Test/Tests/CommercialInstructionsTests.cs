using FluentAssertions;
using Tip.TransactionStandard.Contracts.CommercialInstructions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Serialization;
using Tip.TransactionStandard.Validation;
using Xunit;

namespace Test.Tests;

public sealed class CommercialInstructionsTests
{
    [Fact]
    public void Buyer_commercial_instructions_json_fixture_deserializes_and_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "BuyerCommercialInstructionsNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<BuyerCommercialInstructionsRequest>(payload);
        var xml = TipPayloadSerializer.SerializeXml(model);

        model.InstructionType.Should().Be(CommercialInstructionType.RotationShare);
        model.InstructionDetails.Should().ContainSingle();
        xml.Should().Contain("https://tip.schemas.org/v6.0.0");
        xml.Should().Contain("<BuyerCommercialInstructions");
    }

    [Fact]
    public void Commercial_instructions_validation_reports_instruction_specific_requirements()
    {
        var request = new BuyerCommercialInstructionsRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-05-06T18:54:24.221Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TransactionType = TransactionType.New,
                    SourceId = "EXT-123",
                    SourceName = "Creative Assets Company",
                },
            },
            ReferenceIds = [new ReferenceId { ReferenceSourceName = "KHOU-TV", ReferenceSourceId = "KHOU-5678", ReferenceType = ReferenceType.Order, Value = "ORD-0987" }],
            Contacts =
            [
                new Contact
                {
                    ContactIds = [new Identifier { Id = "BUYER-178", SourceName = "XVEN Buyer" }],
                    ContactType = ContactType.AccountExecutive,
                },
            ],
            Advertiser = new Advertiser
            {
                AdvertiserIds = [new Identifier { Id = "EXT-654", SourceName = "Creative Assets Company" }],
                AdvertiserName = "Hyundai",
            },
            Product = new Product
            {
                ProductIds = [new Identifier { Id = "EXT-0001", SourceName = "Creative Assets Company" }],
                ProductName = "Automobile",
            },
            DateWindow = new DateWindow { StartDate = "2021-05-06", EndDate = "2021-05-07" },
            InstructionType = CommercialInstructionType.Pattern,
            InstructionDetails =
            [
                new InstructionDetail
                {
                    ActionType = InstructionActionType.New,
                    MediaOutlet = new MediaOutlet
                    {
                        MediaOutletIds = [new Identifier { Id = "TV-124", SourceName = "XVEN Buyer" }],
                        MediaOutletName = "KHOU-TV",
                        MediaOutletType = "Local TV",
                    },
                    Creative = new Creative
                    {
                        Ids = [new Identifier { Id = "TYRN8899H", SourceName = "AdID.org" }],
                    },
                    DeliveryService = "Adstream",
                },
            ],
        };

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("PatternInstruction"));
    }
}
