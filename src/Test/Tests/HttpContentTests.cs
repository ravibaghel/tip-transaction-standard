using System.Net.Http;
using FluentAssertions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Contracts.LogTimes;
using Tip.TransactionStandard.Http;
using Xunit;

namespace Test.Tests;

public sealed class HttpContentTests
{
    [Fact]
    public async Task Tip_http_content_reads_json_payload()
    {
        var request = new SellerLogtimesRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2020-07-01T19:17:28Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "6A61B212-4DBD-431E-A953-8873561AF781",
                    TransactionType = TransactionType.New,
                    SourceId = "490",
                    SourceName = "KHOU-TV",
                },
            },
            MediaOutlets = [new MediaOutlet { MediaOutletIds = [new Identifier { Id = "490", SourceName = "KHOU-TV" }], MediaOutletName = "KHOU-TV", MediaOutletType = "Local TV" }],
            Units = [new LogTimeUnit { UnitId = "1", ReferenceIds = [new ReferenceId { ReferenceSourceName = "KHOU-TV", ReferenceSourceId = "490", ReferenceType = ReferenceType.Order }], LineReferences = [new Identifier { Id = "LN1", SourceName = "KHOU-TV" }], Advertiser = new Advertiser { AdvertiserIds = [new Identifier { Id = "ADV1", SourceName = "KHOU-TV" }], AdvertiserName = "Hyundai" }, Product = new Product { ProductIds = [new Identifier { Id = "PRD1", SourceName = "KHOU-TV" }], ProductName = "Automobile" }, SalesElementHeader = new SalesElementHeader { MediaOutletId = "490", SalesElementId = "56", SalesElementName = "CBS This Morning", SalesElementType = SalesElementType.Program }, AiredLength = 30, Status = UnitStatus.NoRun } ],
        };

        using var content = TipHttpContent.CreateJson(request);
        var roundtrip = await TipHttpContent.ReadAsync<SellerLogtimesRequest>(content);

        roundtrip.TransactionHeader!.TipVersion.Should().Be("6.0.0");
        roundtrip.Units.Single().Status.Should().Be(UnitStatus.NoRun);
    }
}
