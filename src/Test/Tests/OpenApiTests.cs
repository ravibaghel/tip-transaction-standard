using FluentAssertions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Xunit;

namespace Test.Tests;

public sealed class OpenApiTests
{
    [Fact]
    public void Logtimes_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "logTimes.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var seller = document.Paths["/seller/logtimes"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerLogtimes");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);

        var buyer = document.Paths["/buyer/logtimes/subscription"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerLogTimesSubscription");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Rfps_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "rfps.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var buyer = document.Paths["/buyer/rfps"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerRFPS");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }
}
