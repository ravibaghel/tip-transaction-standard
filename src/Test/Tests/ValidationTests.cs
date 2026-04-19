using FluentAssertions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Contracts.CreativeAssets;
using Tip.TransactionStandard.Contracts.Impressions;
using Tip.TransactionStandard.Contracts.InventoryAvails;
using Tip.TransactionStandard.Contracts.Invoices;
using Tip.TransactionStandard.Contracts.LogTimes;
using Tip.TransactionStandard.Contracts.Makegoods;
using Tip.TransactionStandard.Contracts.Orders;
using Tip.TransactionStandard.Contracts.Proposals;
using Tip.TransactionStandard.Contracts.Rfps;
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

    [Fact]
    public void Invalid_rfps_payload_reports_paths()
    {
        var request = CreateValidRfpsRequest();
        request.DateSubmitted = "not-a-date";
        request.Budgets[0].BudgetAmount = 0;
        request.CampaignGoals[0].DistributionName = null;

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("DateSubmitted") && issue.Message.Contains("valid ISO date"));
        issues.Should().Contain(issue => issue.Path.Contains("Budgets[0].BudgetAmount") && issue.Message.Contains("greater than zero"));
        issues.Should().Contain(issue => issue.Path.Contains("CampaignGoals[0].DistributionName"));
    }

    [Fact]
    public void Invalid_proposal_payload_reports_paths()
    {
        var request = CreateValidProposalRequest();
        request.ExpirationDate = "not-a-date";
        request.SalesElements[0].SalesElementTransactionInventorys[0].InventoryLength = -1;
        request.SalesElements[0].SalesElementTransactionInventorys[0].SalesElementTransactionDates[0].UnitCount = -3;

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("ExpirationDate") && issue.Message.Contains("valid ISO date"));
        issues.Should().Contain(issue => issue.Path.Contains("InventoryLength") && issue.Message.Contains("zero or greater"));
        issues.Should().Contain(issue => issue.Path.Contains("UnitCount") && issue.Message.Contains("zero or greater"));
    }

    [Fact]
    public void Invalid_order_payload_reports_paths()
    {
        var request = CreateValidOrderRequest();
        request.OrderBookedDate = "bad-date";

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("OrderBookedDate") && issue.Message.Contains("valid ISO date"));
    }

    [Fact]
    public void Invalid_inventory_avails_payload_reports_paths()
    {
        var request = CreateValidSellerInventoryAvailsRequest();
        request.DateSubmitted = "bad-date";
        request.SalesElements[0].SalesElementInventorys[0].SalesElementInventoryDates[0].InventoryAvails = -1;

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("DateSubmitted") && issue.Message.Contains("valid ISO date"));
        issues.Should().Contain(issue => issue.Path.Contains("InventoryAvails") && issue.Message.Contains("zero or greater"));
    }

    [Fact]
    public void Invalid_invoice_payload_reports_paths()
    {
        var request = CreateValidInvoiceRequest();
        request.InvoiceDate = "bad-date";

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("InvoiceDate") && issue.Message.Contains("valid ISO date"));
    }

    [Fact]
    public void Invalid_makegood_payload_reports_paths()
    {
        var request = new SellerMakegoodGuidelinesRequest
        {
            DateSubmitted = "bad-date",
            Buyer = new Buyer { BuyerIds = [new Identifier { Id = "BUY-123", SourceId = "ABC-1234", SourceName = "TIPApi", Version = "0" }], BuyerName = "Canvas Worldwide. LLC" },
            MakegoodType = MakegoodType.ResolvePreemption,
        };

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("DateSubmitted") && issue.Message.Contains("valid ISO date"));
    }

    [Fact]
    public void Invalid_creative_assets_payload_reports_paths()
    {
        var request = new BuyerCreativeAssetsRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-08-05T12:00:00Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "8fcb5ae9-3038-49dc-8614-b2db302c808f",
                    TransactionType = TransactionType.New,
                    SourceId = "BUY-1234",
                    SourceName = "TIP Buyer",
                },
            },
            Creative = "Fall Promo Spot A",
            TimePeriods =
            [
                new TimePeriod
                {
                    DateWindow = new DateWindow
                    {
                        StartDate = "2021-09-01",
                        EndDate = "2021-09-30",
                    },
                },
            ],
            DeliveryDate = "bad-date",
            DeliveryService = "Extreme Reach",
            Buyer = new Buyer
            {
                BuyerIds = [new Identifier { Id = "BUY-1234", SourceId = "BUY-1234", SourceName = "TIP Buyer", Version = "0" }],
                BuyerName = "Canvas Worldwide. LLC",
            },
            Product = new Product
            {
                ProductIds = [new Identifier { Id = "PROD-1234", SourceId = "BUY-1234", SourceName = "TIP Buyer", Version = "0" }],
                ProductName = "Automobile",
            },
        };

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("DeliveryDate") && issue.Message.Contains("valid ISO date"));
    }

    [Fact]
    public void Invalid_impressions_payload_reports_paths()
    {
        var request = new SellerImpressionsNotificationRequest
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-07-21T17:32:28Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "1c237fdd-940d-499e-aa20-df3b9ce0908e",
                    TransactionType = TransactionType.New,
                    SourceId = "ABC-1234",
                    SourceName = "TIPApi",
                },
            },
            MediaOutlets =
            [
                new MediaOutlet
                {
                    MediaOutletIds = [new Identifier { Id = "string", SourceId = "string", SourceName = "string", Version = "string" }],
                    MediaOutletName = "MBLTV - My Best Local TV Station",
                    MediaOutletType = "Local TV",
                },
            ],
            SalesElementHeaders =
            [
                new SalesElementHeader
                {
                    MediaOutletId = "string",
                    SalesElementName = "Primetime",
                    SalesElementId = "string",
                    SalesElementType = SalesElementType.TimeSpecific,
                },
            ],
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
            Creatives =
            [
                new Creative
                {
                    Ids = [new Identifier { Id = "string", SourceId = "string", SourceName = "string", Version = "string" }],
                    Name = "string",
                    Status = CreativeStatus.NotFinal,
                    Length = 0,
                },
            ],
            ReportDate = new DateWindow
            {
                StartDate = "bad-date",
                EndDate = "2021-07-14",
            },
            StatSource = "internal",
            FilePrefix = "ORD-0009123",
            Chunks = 0,
        };

        var issues = TipValidator.ValidateObject(request);

        issues.Should().Contain(issue => issue.Path.Contains("ReportDate.StartDate") && issue.Message.Contains("valid ISO date"));
        issues.Should().Contain(issue => issue.Path.Contains("Chunks") && issue.Message.Contains("greater than zero"));
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

    private static BuyerRFPSRequest CreateValidRfpsRequest() =>
        new()
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
                    ReferenceVersionId = "1",
                    ReferenceName = "Hyundai 1Q22",
                },
            ],
            DateSubmitted = "2021-05-20",
            DueDate = "2021-05-25",
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
                    ContactFirstName = "John",
                    ContactLastName = "Doe",
                    Email = "john.doe@example.com",
                    EffectiveDate = "2021-05-20",
                },
            ],
            Currency = CurrencyCode.Usd,
            Budgets =
            [
                new Budget
                {
                    BudgetAmount = 120000m,
                    BudgetAllocation = new BudgetAllocation
                    {
                        BudgetType = BudgetType.Dma,
                        BudgetName = "Houston",
                        BudgetAmount = 12000m,
                        BudgetSharePercent = 10m,
                    },
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
                        IsTuesday = true,
                        IsWednesday = true,
                        IsThursday = true,
                        IsFriday = true,
                    },
                    TimeWindow = new TimeWindow
                    {
                        StartTime = "07:00:00",
                        EndTime = "12:00:00",
                    },
                },
            ],
            CampaignGoals =
            [
                new CampaignGoal
                {
                    DistributionType = CampaignGoalDistributionType.MediaOutletType,
                    DistributionMethod = CampaignGoalDistributionMethod.Impressions,
                    DistributionName = "Local Broadcast TV",
                    Distribution = CampaignGoalDistribution.Percentage,
                    DistributionValue = 60m,
                    DistributionOrder = 0,
                    DistributionOrderParent = 0,
                },
            ],
        };

    private static SellerProposalsRequest CreateValidProposalRequest() =>
        new()
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
                    ReferenceType = ReferenceType.Rfp,
                    Value = "REF-1234",
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
            SalesElements =
            [
                new SalesElementTransaction
                {
                    SalesElementHeader = new SalesElementHeader
                    {
                        MediaOutletId = "KHOU-TV",
                        SalesElementId = "SL-1234",
                        SalesElementName = "Primetime",
                        SalesElementType = SalesElementType.TimeSpecific,
                    },
                    TimePeriods =
                    [
                        new TimePeriod
                        {
                            DateWindow = new DateWindow
                            {
                                StartDate = "2021-07-01",
                                EndDate = "2021-09-21",
                            },
                            DOW = new DayOfWeekSelection { IsMonday = true },
                        },
                    ],
                    SalesElementTransactionInventorys =
                    [
                        new SalesElementTransactionInventory
                        {
                            LineNum = "1",
                            InventoryType = "Commercial",
                            InventoryLength = 30,
                            SalesElementTransactionDates =
                            [
                                new SalesElementTransactionDate
                                {
                                    DateType = DateType.Day,
                                    CalendarType = CalendarType.Broadcast,
                                    DateWindow = new DateWindow
                                    {
                                        StartDate = "2021-07-01",
                                        EndDate = "2021-09-21",
                                    },
                                    UnitCount = 10,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

    private static BuyerOrdersRequest CreateValidOrderRequest() =>
        new()
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-07-21T17:32:28Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "1C237FDD-940D-499E-AA20-DF3B9CE0908E",
                    TransactionType = TransactionType.New,
                    SourceId = "Buy-6789",
                    SourceName = "TIP Buyer",
                },
            },
            ReferenceIds =
            [
                new ReferenceId
                {
                    ReferenceSourceName = "Buy-6789",
                    ReferenceSourceId = "TIP Buyer",
                    ReferenceType = ReferenceType.Order,
                    Value = "ORD-56789",
                },
            ],
            OrderBookedDate = "2021-05-24",
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

    private static SellerInventoryAvailsRequest CreateValidSellerInventoryAvailsRequest() =>
        new()
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-05-06T18:32:44.757Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TransactionType = TransactionType.New,
                    SourceId = "YSELL-1234",
                    SourceName = "YSELL Seller",
                },
            },
            DateSubmitted = "2021-05-06",
            IsPolitical = false,
            MediaOutlets =
            [
                new MediaOutlet
                {
                    MediaOutletIds = [new Identifier { Id = "KHOU-TV", SourceId = "XVEN-1234", SourceName = "XVEN Buyer", Version = "0" }],
                    MediaOutletName = "KHOU-TV",
                    MediaOutletType = "Local TV",
                },
            ],
            AvailWindow = new DateWindow
            {
                StartDate = "2021-08-06",
                EndDate = "2021-08-20",
            },
            SalesElements =
            [
                new SalesElement
                {
                    SalesElementHeader = new SalesElementHeader
                    {
                        MediaOutletId = "YSELL-1234",
                        SalesElementId = "string",
                        SalesElementName = "Primetime",
                        SalesElementType = SalesElementType.TimeSpecific,
                    },
                    SalesElementInventorys =
                    [
                        new SalesElementInventory
                        {
                            InventoryType = "Commercial",
                            SalesElementInventoryDates =
                            [
                                new SalesElementInventoryDate
                                {
                                    DateType = DateType.Day,
                                    CalendarType = CalendarType.Broadcast,
                                    DateWindow = new DateWindow
                                    {
                                        StartDate = "2021-08-06",
                                        EndDate = "2021-08-20",
                                    },
                                    InventoryAvails = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

    private static SellerInvoicesRequest CreateValidInvoiceRequest() =>
        new()
        {
            TransactionHeader = new TransactionHeader
            {
                TipVersion = "6.0.0",
                TimeStamp = "2021-05-06T19:53:04.885Z",
                TransactionId = new TransactionIdentifier
                {
                    Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    TransactionType = TransactionType.New,
                    SourceId = "YSELL-1234",
                    SourceName = "YSELL Seller",
                },
            },
            ReferenceIds =
            [
                new ReferenceId
                {
                    ReferenceSourceName = "YSELL Seller",
                    ReferenceSourceId = "YSELL-1234",
                    ReferenceType = ReferenceType.Invoice,
                    Value = "ORD-5678-1",
                },
            ],
            InvoiceDate = "2021-08-25",
            DateWindow = new DateWindow
            {
                StartDate = "2021-07-01",
                EndDate = "2021-07-31",
            },
            Buyer = new Buyer
            {
                BuyerIds = [new Identifier { Id = "YSELL-7890", SourceId = "YSELL-1234", SourceName = "YSELL Seller", Version = "0" }],
                BuyerName = "Canvas Worldwide. LLC",
            },
            Advertiser = new Advertiser
            {
                AdvertiserIds = [new Identifier { Id = "YSELL-0980", SourceId = "YSELL-1234", SourceName = "YSELL Seller", Version = "0" }],
                AdvertiserName = "Hyundai",
            },
            RevenueType = RevenueType.Cash,
            GrossAmount = 10000m,
            Commission = 8m,
            NetAmount = 10845.55m,
            RemittanceInfo = new RemittanceInfo
            {
                ReferenceSourceIds = [new Identifier { Id = "RMT-1234", SourceId = "XVEN-1234", SourceName = "XVEN Buyer", Version = "0" }],
            },
            MediaOutlets =
            [
                new MediaOutlet
                {
                    MediaOutletIds = [new Identifier { Id = "KHOU-TV", SourceId = "XVEN-1234", SourceName = "XVEN Buyer", Version = "0" }],
                    MediaOutletName = "KHOU-TV",
                    MediaOutletType = "Local TV",
                },
            ],
            LineDetails =
            [
                new InvoiceLineDetail
                {
                    LineNum = "1",
                    Type = InvoiceLineType.Spot,
                    Product = new Product
                    {
                        ProductIds = [new Identifier { Id = "PRO-1234", SourceId = "YSELL-1234", SourceName = "YSELL Seller", Version = "0" }],
                        ProductName = "Automobile",
                    },
                    SalesElementHeader = new SalesElementHeader
                    {
                        MediaOutletId = "KHOU-TV",
                        SalesElementId = "YSELL-9999",
                        SalesElementName = "Primetime",
                        SalesElementType = SalesElementType.TimeSpecific,
                    },
                    Length = 30,
                    GrossCost = 150m,
                    NetCost = 127.5m,
                },
            ],
        };
}
