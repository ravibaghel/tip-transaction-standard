using FluentAssertions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Contracts.LogTimes;
using Tip.TransactionStandard.Validation;
using Xunit;

namespace Test.Tests;

public sealed class ValidationTests
{
    [Fact]
    public void Valid_seller_payload_passes_validation()
    {
        var request = CreateValidRequest();

        var issues = TipValidator.ValidateObject(request);

        issues.Should().BeEmpty();
    }

    [Fact]
    public void Invalid_seller_payload_reports_paths()
    {
        var request = CreateValidRequest();
        request.Units[0].AiredLength = 0;
        request.Units[0].DateTime = null;

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("AiredLength") && issue.Message.Contains("greater than zero"));
        issues.Should().Contain(issue => issue.Path.Contains("DateTime") && issue.Message.Contains("required unless status is 'No Run'"));
    }

    private static SellerLogtimesRequest CreateValidRequest() =>
        new()
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
            MediaOutlets =
            [
                new MediaOutlet
                {
                    MediaOutletIds = [new Identifier { Id = "490", SourceId = "490", SourceName = "KHOU-TV", Version = "0" }],
                    MediaOutletName = "KHOU-TV",
                    MediaOutletType = "Local TV",
                },
            ],
            Units =
            [
                new LogTimeUnit
                {
                    UnitId = "15555",
                    ReferenceIds = [new ReferenceId { ReferenceSourceName = "KHOU-TV", ReferenceSourceId = "490", ReferenceType = ReferenceType.Order, Value = "A2CAF9C7-C64F-44CA-84E1-DCD51D790E3E" }],
                    LineReferences =
                    [
                        new Identifier { Id = "Hyn-2554-1", SourceId = "XVEN-1234", SourceName = "XVEN Buyer", Version = "0" },
                    ],
                    Advertiser = new Advertiser
                    {
                        AdvertiserIds = [new Identifier { Id = "34", SourceId = "490", SourceName = "KHOU-TV", Version = "0" }],
                        AdvertiserName = "Hyundai",
                    },
                    Product = new Product
                    {
                        ProductIds = [new Identifier { Id = "89", SourceId = "490", SourceName = "KHOU-TV", Version = "0" }],
                        ProductName = "Automobile",
                    },
                    SalesElementHeader = new SalesElementHeader
                    {
                        MediaOutletId = "490",
                        SalesElementId = "56",
                        SalesElementName = "CBS This Morning",
                        SalesElementType = SalesElementType.Program,
                    },
                    AiredLength = 30,
                    Status = UnitStatus.Aired,
                    DateTime = new TipDateTime
                    {
                        BroadcastDate = "2021-08-06",
                        CalendarDateTime = "2021-08-06T19:49:23.706Z",
                    },
                },
            ],
        };
}
