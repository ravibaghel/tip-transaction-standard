using FluentAssertions;
using Tip.TransactionStandard.Contracts.Common;
using Tip.TransactionStandard.Contracts.LogTimes;
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
}
