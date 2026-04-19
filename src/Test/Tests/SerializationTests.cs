using FluentAssertions;
using Tip.TransactionStandard.Contracts.LogTimes;
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
}
