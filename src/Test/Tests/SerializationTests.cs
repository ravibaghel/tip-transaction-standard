using FluentAssertions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Contracts.LogTimes;
using Tip.TransactionStandard.Contracts.Orders;
using Tip.TransactionStandard.Contracts.Proposals;
using Tip.TransactionStandard.Contracts.Rfps;
using Tip.TransactionStandard.Serialization;
using Xunit;

namespace Test.Tests;

public sealed class SerializationTests
{
    [Fact]
    public void SellerLogtimes_json_fixture_deserializes_and_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "SellerLogtimesNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<SellerLogtimesRequest>(payload);
        var serialized = TipPayloadSerializer.SerializeJson(model);

        model.TransactionHeader!.TipVersion.Should().Be("6.0.0");
        model.Units.Should().HaveCount(1);
        serialized.Should().Contain("\"tipVersion\": \"6.0.0\"");
    }

    [Fact]
    public void SellerLogtimes_xml_fixture_deserializes_and_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "SellerLogtimesNew.xml"));

        var model = TipPayloadSerializer.DeserializeXml<SellerLogtimesRequest>(payload);
        var serialized = TipPayloadSerializer.SerializeXml(model);

        model.TransactionHeader!.TransactionId!.TransactionType.Should().Be(Tip.TransactionStandard.Contracts.Common.TransactionType.New);
        serialized.Should().Contain("<SellerLogtimesRequest");
        serialized.Should().Contain("<transactionType>New</transactionType>");
    }

    [Fact]
    public void Buyer_subscription_fixture_deserializes()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "BuyerLogtimesSubscriptionNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<BuyerLogTimesSubscriptionRequest>(payload);

        model.Frequency!.Every.Should().Be(Tip.TransactionStandard.Contracts.Common.FrequencyEvery.WhenAvailable);
        model.Statuses.Should().Contain(Tip.TransactionStandard.Contracts.Common.UnitStatus.Aired);
        model.ReferenceIds.Single().ReferenceVersionId.Should().Be("0");
    }

    [Fact]
    public void Buyer_rfps_json_fixture_deserializes_and_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "BuyerRFPSNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<BuyerRFPSRequest>(payload);
        var serialized = TipPayloadSerializer.SerializeJson(model);

        model.Currency.Should().Be(Tip.TransactionStandard.Contracts.Common.CurrencyCode.Usd);
        model.TimePeriodPreferences.Should().HaveCount(1);
        model.CampaignGoals.Single().DistributionType.Should().Be(Tip.TransactionStandard.Contracts.Common.CampaignGoalDistributionType.MediaOutletType);
        serialized.Should().Contain("\"currency\": \"USD\"");
    }

    [Fact]
    public void Buyer_rfps_xml_serialization_uses_tip_namespace()
    {
        var model = new BuyerRFPSRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-07-21T17:32:28Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "1C237FDD-940D-499E-AA20-DF3B9CE0908E",
                    TransactionType = TransactionType.New,
                    SourceId = "ABC-1234",
                    SourceName = "TIPApi",
                },
            },
            ReferenceIds =
            [
                new ReferenceId
                {
                    ReferenceSourceName = "KHOU-TV",
                    ReferenceSourceId = "string",
                    ReferenceType = ReferenceType.Rfp,
                    Value = "REF-1234",
                },
            ],
            DateSubmitted = "2021-05-20",
            Advertiser = new Advertiser
            {
                AdvertiserIds = [new Identifier { Id = "ADV-143", SourceId = "XBuy-1234", SourceName = "XVEN Buyer", Version = "0" }],
                AdvertiserName = "Hyundai",
            },
            Contacts =
            [
                new Contact
                {
                    ContactIds = [new Identifier { Id = "CNT-1234", SourceId = "ABC-1234", SourceName = "TIPApi", Version = "0" }],
                    Email = "john.doe@example.com",
                },
            ],
            TimePeriodPreferences =
            [
                new TimePeriod
                {
                    DateWindow = new DateWindow
                    {
                        StartDate = "2021-05-20",
                        EndDate = "2021-07-20",
                    },
                    DOW = new DayOfWeekSelection
                    {
                        IsMonday = true,
                    },
                },
            ],
        };

        var serialized = TipPayloadSerializer.SerializeXml(model);

        serialized.Should().Contain("<BuyerRFPS");
        serialized.Should().Contain("https://tip.schemas.org/v6.0.0");
        serialized.Should().Contain("<dateSubmitted>2021-05-20</dateSubmitted>");
    }

    [Fact]
    public void Seller_proposals_json_fixture_deserializes_and_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "SellerProposalsNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<SellerProposalsRequest>(payload);
        var serialized = TipPayloadSerializer.SerializeJson(model);

        model.RevenueType.Should().Be(RevenueType.Cash);
        model.MediaOutlets.Should().HaveCount(1);
        model.SalesElements.Single().SalesElementTransactionInventorys.Single().SalesElementTransactionDates.Single().PricingMetric!.PricingMetricOption
            .Should().Be(PricingMetricOptionType.Cpm);
        serialized.Should().Contain("\"revenueType\": \"Cash\"");
    }

    [Fact]
    public void Seller_proposals_xml_serialization_uses_tip_namespace()
    {
        var model = new SellerProposalsRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-07-21T17:32:28Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "1C237FDD-940D-499E-AA20-DF3B9CE0908E",
                    TransactionType = TransactionType.New,
                    SourceId = "ABC-1234",
                    SourceName = "TIPApi",
                },
            },
            ReferenceIds =
            [
                new ReferenceId
                {
                    ReferenceSourceName = "TIPApi",
                    ReferenceSourceId = "ABC-1234",
                    ReferenceType = ReferenceType.Proposal,
                    Value = "PRP-1234",
                },
            ],
            ExpirationDate = "2021-06-30",
            Buyer = new Buyer
            {
                BuyerIds = [new Identifier { Id = "Buy-12345", SourceId = "KHOU-TV", SourceName = "KHOU-TV", Version = "0" }],
                BuyerName = "Canvas Worldwide. LLC",
            },
            Commission = 10m,
            Contacts =
            [
                new Contact
                {
                    ContactIds = [new Identifier { Id = "CNT-12345", SourceId = "KHOU-TV", SourceName = "KHOU-TV", Version = "0" }],
                    Email = "user@example.com",
                },
            ],
            RevenueType = RevenueType.Cash,
            BusinessType = "Linear",
            IsEquivalized = true,
            DateWindows =
            [
                new DateWindow
                {
                    StartDate = "2021-07-01",
                    EndDate = "2021-09-21",
                },
            ],
            MediaOutlets =
            [
                new MediaOutlet
                {
                    MediaOutletIds = [new Identifier { Id = "KHOU-TV", SourceId = "KHOU-TV", SourceName = "KHOU-TV", Version = "0" }],
                    MediaOutletName = "MBLTV - My Best Local TV Station",
                    MediaOutletType = "Local TV",
                },
            ],
        };

        var serialized = TipPayloadSerializer.SerializeXml(model);

        serialized.Should().Contain("<SellerProposals");
        serialized.Should().Contain("https://tip.schemas.org/v6.0.0");
        serialized.Should().Contain("<revenueType>Cash</revenueType>");
    }

    [Fact]
    public void Buyer_proposals_json_fixture_deserializes()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "BuyerProposalsChange.json"));

        var model = TipPayloadSerializer.DeserializeJson<BuyerProposalsRequest>(payload);

        model.TransactionHeader!.TransactionId!.TransactionType.Should().Be(TransactionType.Change);
        model.ReferenceIds.Should().HaveCount(3);
        model.ExternalComment.Should().Contain("negotiations");
    }

    [Fact]
    public void Buyer_orders_json_fixture_deserializes()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "BuyerOrdersNew.json"));

        var model = TipPayloadSerializer.DeserializeJson<BuyerOrdersRequest>(payload);

        model.TransactionHeader!.TransactionId!.TransactionType.Should().Be(TransactionType.New);
        model.OrderBookedDate.Should().Be("2021-05-24");
        model.ReferenceIds.Should().Contain(x => x.ReferenceType == ReferenceType.Order);
    }

    [Fact]
    public void Seller_orders_json_fixture_deserializes_and_xml_roundtrips()
    {
        var payload = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", "SellerOrdersConfirm.json"));

        var model = TipPayloadSerializer.DeserializeJson<SellerOrdersRequest>(payload);
        var xml = TipPayloadSerializer.SerializeXml(model);

        model.TransactionHeader!.TransactionId!.TransactionType.Should().Be(TransactionType.Confirm);
        model.Comments.Should().Be("Appreciate your business");
        xml.Should().Contain("<SellerOrders");
        xml.Should().Contain("https://tip.schemas.org/v6.0.0");
    }
}
