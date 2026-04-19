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

    [Fact]
    public void Proposal_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "proposal.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var seller = document.Paths["/seller/proposals"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerProposals");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);

        var buyer = document.Paths["/buyer/proposals"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerProposals");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Orders_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "orders.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var buyer = document.Paths["/buyer/orders"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerOrders");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);

        var seller = document.Paths["/seller/orders"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerOrders");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Inventory_avails_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "inventoryAvails.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var buyer = document.Paths["/buyer/inventoryAvails/subscription"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerInventoryAvailsSubscription");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);

        var seller = document.Paths["/seller/inventoryAvails"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerInventoryAvails");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Invoice_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "invoice.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var seller = document.Paths["/seller/invoices"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerInvoices");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Makegoods_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "makegoods.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        document.Paths["/seller/makegood/guidelines"].Operations[OperationType.Post].OperationId.Should().Be("SellerMakegoodGuidelines");
        document.Paths["/buyer/makegood/guidelines"].Operations[OperationType.Post].OperationId.Should().Be("BuyerMakegoodGuidelines");
        document.Paths["/seller/makegood/offers"].Operations[OperationType.Post].OperationId.Should().Be("SellerMakegoodOffers");
        document.Paths["/buyer/makegood/offers"].Operations[OperationType.Post].OperationId.Should().Be("BuyerMakegoodOffers");
    }

    [Fact]
    public void Creative_assets_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "creativeAssets.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var buyer = document.Paths["/buyer/creativeAssets"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerCreativeAssets");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }

    [Fact]
    public void Impressions_openapi_fixture_exposes_json_and_xml_request_bodies()
    {
        using var stream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "Fixtures", "impressionssub.openapi.yaml"));
        var document = new OpenApiStreamReader().Read(stream, out var diagnostic);

        diagnostic.Errors.Should().BeEmpty();

        var buyer = document.Paths["/buyer/impressions/subscription"].Operations[OperationType.Post];
        buyer.OperationId.Should().Be("BuyerImpressionsSubscription");
        buyer.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);

        var seller = document.Paths["/seller/impressions/notification"].Operations[OperationType.Post];
        seller.OperationId.Should().Be("SellerImpressionNotification");
        seller.RequestBody.Content.Keys.Should().Contain(["application/json", "application/xml"]);
    }
}
