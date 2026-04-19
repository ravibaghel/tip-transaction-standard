using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tip.TransactionStandard.Contracts.Common;

public enum TransactionType
{
    [EnumMember(Value = "New")]
    [XmlEnum("New")]
    New,
    [EnumMember(Value = "Change")]
    [XmlEnum("Change")]
    Change,
    [EnumMember(Value = "Cancel")]
    [XmlEnum("Cancel")]
    Cancel,
    [EnumMember(Value = "Reject")]
    [XmlEnum("Reject")]
    Reject,
    [EnumMember(Value = "Recall")]
    [XmlEnum("Recall")]
    Recall,
    [EnumMember(Value = "Confirm")]
    [XmlEnum("Confirm")]
    Confirm,
}

public enum ReferenceType
{
    [EnumMember(Value = "RFP")]
    [XmlEnum("RFP")]
    Rfp,
    [EnumMember(Value = "Proposal")]
    [XmlEnum("Proposal")]
    Proposal,
    [EnumMember(Value = "Deal")]
    [XmlEnum("Deal")]
    Deal,
    [EnumMember(Value = "Order")]
    [XmlEnum("Order")]
    Order,
    [EnumMember(Value = "Invoice")]
    [XmlEnum("Invoice")]
    Invoice,
    [EnumMember(Value = "Subscription")]
    [XmlEnum("Subscription")]
    Subscription,
}

public enum SalesElementType
{
    [EnumMember(Value = "Time-specific")]
    [XmlEnum("Time-specific")]
    TimeSpecific,
    [EnumMember(Value = "Program")]
    [XmlEnum("Program")]
    Program,
    [EnumMember(Value = "Audience")]
    [XmlEnum("Audience")]
    Audience,
    [EnumMember(Value = "Package")]
    [XmlEnum("Package")]
    Package,
}

public enum CreativeStatus
{
    [EnumMember(Value = "Not Final")]
    [XmlEnum("Not Final")]
    NotFinal,
    [EnumMember(Value = "Final")]
    [XmlEnum("Final")]
    Final,
    [EnumMember(Value = "On-Hand")]
    [XmlEnum("On-Hand")]
    OnHand,
}

public enum UnitStatus
{
    [EnumMember(Value = "Aired")]
    [XmlEnum("Aired")]
    Aired,
    [EnumMember(Value = "Scheduled")]
    [XmlEnum("Scheduled")]
    Scheduled,
    [EnumMember(Value = "No Run")]
    [XmlEnum("No Run")]
    NoRun,
    [EnumMember(Value = "Finalized")]
    [XmlEnum("Finalized")]
    Finalized,
    [EnumMember(Value = "Not Scheduled")]
    [XmlEnum("Not Scheduled")]
    NotScheduled,
    [EnumMember(Value = "Preempted")]
    [XmlEnum("Preempted")]
    Preempted,
}

public enum LinkTypeCode
{
    [EnumMember(Value = "Billboard")]
    [XmlEnum("Billboard")]
    Billboard,
    [EnumMember(Value = "Piggyback")]
    [XmlEnum("Piggyback")]
    Piggyback,
    [EnumMember(Value = "Bookend")]
    [XmlEnum("Bookend")]
    Bookend,
    [EnumMember(Value = "Sandwich")]
    [XmlEnum("Sandwich")]
    Sandwich,
    [EnumMember(Value = "Donut")]
    [XmlEnum("Donut")]
    Donut,
    [EnumMember(Value = "Sponsorship")]
    [XmlEnum("Sponsorship")]
    Sponsorship,
    [EnumMember(Value = "Package")]
    [XmlEnum("Package")]
    Package,
}

public enum FrequencyEvery
{
    [EnumMember(Value = "When Available")]
    [XmlEnum("When Available")]
    WhenAvailable,
    [EnumMember(Value = "Hour")]
    [XmlEnum("Hour")]
    Hour,
    [EnumMember(Value = "Day")]
    [XmlEnum("Day")]
    Day,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
}

public enum SubscriptionDay
{
    [EnumMember(Value = "Mon")]
    [XmlEnum("Mon")]
    Mon,
    [EnumMember(Value = "Tue")]
    [XmlEnum("Tue")]
    Tue,
    [EnumMember(Value = "Wed")]
    [XmlEnum("Wed")]
    Wed,
    [EnumMember(Value = "Thu")]
    [XmlEnum("Thu")]
    Thu,
    [EnumMember(Value = "Fri")]
    [XmlEnum("Fri")]
    Fri,
    [EnumMember(Value = "Sat")]
    [XmlEnum("Sat")]
    Sat,
    [EnumMember(Value = "Sun")]
    [XmlEnum("Sun")]
    Sun,
}

public enum ContactType
{
    [EnumMember(Value = "Account Executive")]
    [XmlEnum("Account Executive")]
    AccountExecutive,
    [EnumMember(Value = "Planner")]
    [XmlEnum("Planner")]
    Planner,
    [EnumMember(Value = "Assistant")]
    [XmlEnum("Assistant")]
    Assistant,
    [EnumMember(Value = "Buyer")]
    [XmlEnum("Buyer")]
    Buyer,
    [EnumMember(Value = "Payee")]
    [XmlEnum("Payee")]
    Payee,
    [EnumMember(Value = "Creative")]
    [XmlEnum("Creative")]
    Creative,
    [EnumMember(Value = "Delivery Service")]
    [XmlEnum("Delivery Service")]
    DeliveryService,
}

public enum CommercialInstructionType
{
    [EnumMember(Value = "Rotation Share")]
    [XmlEnum("RotationShare")]
    RotationShare,
    [EnumMember(Value = "Pattern")]
    [XmlEnum("Pattern")]
    Pattern,
    [EnumMember(Value = "Unit Specific")]
    [XmlEnum("UnitSpecific")]
    UnitSpecific,
}

public enum InstructionActionType
{
    [EnumMember(Value = "New")]
    [XmlEnum("New")]
    New,
    [EnumMember(Value = "Change")]
    [XmlEnum("Change")]
    Change,
    [EnumMember(Value = "Cancel")]
    [XmlEnum("Cancel")]
    Cancel,
}

public enum CurrencyCode
{
    [EnumMember(Value = "USD")]
    [XmlEnum("USD")]
    Usd,
    [EnumMember(Value = "CAD")]
    [XmlEnum("CAD")]
    Cad,
    [EnumMember(Value = "EUR")]
    [XmlEnum("EUR")]
    Eur,
    [EnumMember(Value = "GBP")]
    [XmlEnum("GBP")]
    Gbp,
    [EnumMember(Value = "MXN")]
    [XmlEnum("MXN")]
    Mxn,
    [EnumMember(Value = "AUD")]
    [XmlEnum("AUD")]
    Aud,
}

public enum BudgetType
{
    [EnumMember(Value = "DMA")]
    [XmlEnum("DMA")]
    Dma,
    [EnumMember(Value = "MediaOutlet")]
    [XmlEnum("MediaOutlet")]
    MediaOutlet,
    [EnumMember(Value = "MediaType")]
    [XmlEnum("MediaType")]
    MediaType,
}

public enum AudienceRatingSource
{
    [EnumMember(Value = "Nielsen")]
    [XmlEnum("Nielsen")]
    Nielsen,
    [EnumMember(Value = "ComScore")]
    [XmlEnum("ComScore")]
    ComScore,
    [EnumMember(Value = "First-Party")]
    [XmlEnum("First-Party")]
    FirstParty,
    [EnumMember(Value = "Distributor")]
    [XmlEnum("Distributor")]
    Distributor,
    [EnumMember(Value = "Licensed")]
    [XmlEnum("Licensed")]
    Licensed,
}

public enum AudienceRatingStream
{
    [EnumMember(Value = "Program Live")]
    [XmlEnum("ProgramLive")]
    ProgramLive,
    [EnumMember(Value = "Commercial Ratings Live")]
    [XmlEnum("CommercialRatingsLive")]
    CommercialRatingsLive,
    [EnumMember(Value = "Commercial Rating Live+3")]
    [XmlEnum("CommercialRatingLive+3")]
    CommercialRatingLivePlus3,
    [EnumMember(Value = "Commercial Rating Live+7")]
    [XmlEnum("CommercialRatingLive+7")]
    CommercialRatingLivePlus7,
}

public enum FrequencyCappingPeriod
{
    [EnumMember(Value = "Minute")]
    [XmlEnum("Minute")]
    Minute,
    [EnumMember(Value = "Day")]
    [XmlEnum("Day")]
    Day,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
    [EnumMember(Value = "Hour")]
    [XmlEnum("Hour")]
    Hour,
    [EnumMember(Value = "Site Session")]
    [XmlEnum("SiteSession")]
    SiteSession,
    [EnumMember(Value = "Order")]
    [XmlEnum("Order")]
    Order,
    [EnumMember(Value = "Asset")]
    [XmlEnum("Asset")]
    Asset,
}

public enum GuidelineType
{
    [EnumMember(Value = "Content")]
    [XmlEnum("Content")]
    Content,
    [EnumMember(Value = "Program")]
    [XmlEnum("Program")]
    Program,
    [EnumMember(Value = "MPAA")]
    [XmlEnum("MPAA")]
    Mpaa,
    [EnumMember(Value = "Rating")]
    [XmlEnum("Rating")]
    Rating,
    [EnumMember(Value = "Site Category")]
    [XmlEnum("SiteCategory")]
    SiteCategory,
    [EnumMember(Value = "Genre")]
    [XmlEnum("Genre")]
    Genre,
    [EnumMember(Value = "Media Outlet Type")]
    [XmlEnum("MediaOutletType")]
    MediaOutletType,
}

public enum IncludeOrExclude
{
    [EnumMember(Value = "Include")]
    [XmlEnum("Include")]
    Include,
    [EnumMember(Value = "Exclude")]
    [XmlEnum("Exclude")]
    Exclude,
}

public enum CampaignGoalDistributionType
{
    [EnumMember(Value = "Media Outlet Type")]
    [XmlEnum("MediaOutletType")]
    MediaOutletType,
    [EnumMember(Value = "Daypart")]
    [XmlEnum("Daypart")]
    Daypart,
    [EnumMember(Value = "Market")]
    [XmlEnum("Market")]
    Market,
    [EnumMember(Value = "Unit Length")]
    [XmlEnum("UnitLength")]
    UnitLength,
    [EnumMember(Value = "AddedValue")]
    [XmlEnum("AddedValue")]
    AddedValue,
    [EnumMember(Value = "Quarter")]
    [XmlEnum("Quarter")]
    Quarter,
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
}

public enum CampaignGoalDistributionMethod
{
    [EnumMember(Value = "Impressions")]
    [XmlEnum("Impressions")]
    Impressions,
    [EnumMember(Value = "GRPs")]
    [XmlEnum("GRPs")]
    Grps,
    [EnumMember(Value = "Units")]
    [XmlEnum("Units")]
    Units,
    [EnumMember(Value = "Budget")]
    [XmlEnum("Budget")]
    Budget,
}

public enum CampaignGoalDistribution
{
    [EnumMember(Value = "Percentage")]
    [XmlEnum("Percentage")]
    Percentage,
    [EnumMember(Value = "Exact Value")]
    [XmlEnum("ExactValue")]
    ExactValue,
}

public enum RevenueType
{
    [EnumMember(Value = "Cash")]
    [XmlEnum("Cash")]
    Cash,
    [EnumMember(Value = "Barter")]
    [XmlEnum("Barter")]
    Barter,
    [EnumMember(Value = "Trade")]
    [XmlEnum("Trade")]
    Trade,
}

public enum MarketScope
{
    [EnumMember(Value = "Local")]
    [XmlEnum("Local")]
    Local,
    [EnumMember(Value = "National")]
    [XmlEnum("National")]
    National,
}

public enum BillingCalendarType
{
    [EnumMember(Value = "Broadcast")]
    [XmlEnum("Broadcast")]
    Broadcast,
    [EnumMember(Value = "Calendar")]
    [XmlEnum("Calendar")]
    Calendar,
    [EnumMember(Value = "Nielsen")]
    [XmlEnum("Nielsen")]
    Nielsen,
}

public enum BillingCycleType
{
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
    [EnumMember(Value = "Quarter")]
    [XmlEnum("Quarter")]
    Quarter,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
}

public enum BillingGranularityType
{
    [EnumMember(Value = "Order")]
    [XmlEnum("Order")]
    Order,
    [EnumMember(Value = "Line")]
    [XmlEnum("Line")]
    Line,
    [EnumMember(Value = "Unit")]
    [XmlEnum("Unit")]
    Unit,
}

public enum CancellationTermType
{
    [EnumMember(Value = "Quarterly")]
    [XmlEnum("Quarterly")]
    Quarterly,
    [EnumMember(Value = "Broadcast Date")]
    [XmlEnum("BroadcastDate")]
    BroadcastDate,
}

public enum PacingRuleType
{
    [EnumMember(Value = "Frontload")]
    [XmlEnum("Frontload")]
    Frontload,
    [EnumMember(Value = "Even")]
    [XmlEnum("Even")]
    Even,
    [EnumMember(Value = "Daily Fast ASAP")]
    [XmlEnum("DailyFastASAP")]
    DailyFastAsap,
    [EnumMember(Value = "Daily Even")]
    [XmlEnum("DailyEven")]
    DailyEven,
    [EnumMember(Value = "Flight ASAP")]
    [XmlEnum("FlightASAP")]
    FlightAsap,
    [EnumMember(Value = "Flight Even")]
    [XmlEnum("FlightEven")]
    FlightEven,
    [EnumMember(Value = "Flight Ahead")]
    [XmlEnum("FlightAhead")]
    FlightAhead,
}

public enum PacingRateType
{
    [EnumMember(Value = "Absolute")]
    [XmlEnum("Absolute")]
    Absolute,
    [EnumMember(Value = "Percent")]
    [XmlEnum("Percent")]
    Percent,
}

public enum UniverseType
{
    [EnumMember(Value = "Market")]
    [XmlEnum("Market")]
    Market,
    [EnumMember(Value = "Total US")]
    [XmlEnum("TotalUS")]
    TotalUs,
    [EnumMember(Value = "Coverage")]
    [XmlEnum("Coverage")]
    Coverage,
    [EnumMember(Value = "Addressable")]
    [XmlEnum("Addressable")]
    Addressable,
}

public enum AudienceMetricType
{
    [EnumMember(Value = "Impressions")]
    [XmlEnum("Impressions")]
    Impressions,
    [EnumMember(Value = "Rating")]
    [XmlEnum("Rating")]
    Rating,
    [EnumMember(Value = "GRPs")]
    [XmlEnum("GRPs")]
    Grps,
    [EnumMember(Value = "VPVH")]
    [XmlEnum("VPVH")]
    Vpvh,
    [EnumMember(Value = "Composition")]
    [XmlEnum("Composition")]
    Composition,
}

public enum PricingMetricOptionType
{
    [EnumMember(Value = "CPM")]
    [XmlEnum("CPM")]
    Cpm,
    [EnumMember(Value = "CPP")]
    [XmlEnum("CPP")]
    Cpp,
    [EnumMember(Value = "CPE")]
    [XmlEnum("CPE")]
    Cpe,
    [EnumMember(Value = "CPA")]
    [XmlEnum("CPA")]
    Cpa,
    [EnumMember(Value = "SPOT")]
    [XmlEnum("SPOT")]
    Spot,
}

public enum AudiencePricingMetricType
{
    [EnumMember(Value = "Selling")]
    [XmlEnum("Selling")]
    Selling,
    [EnumMember(Value = "Actual")]
    [XmlEnum("Actual")]
    Actual,
    [EnumMember(Value = "Projection")]
    [XmlEnum("Projection")]
    Projection,
}

public enum InventoryPositionType
{
    [EnumMember(Value = "First")]
    [XmlEnum("First")]
    First,
    [EnumMember(Value = "Last")]
    [XmlEnum("Last")]
    Last,
    [EnumMember(Value = "Middle")]
    [XmlEnum("Middle")]
    Middle,
}

public enum DateType
{
    [EnumMember(Value = "Day")]
    [XmlEnum("Day")]
    Day,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
    [EnumMember(Value = "Quarter")]
    [XmlEnum("Quarter")]
    Quarter,
}

public enum CalendarType
{
    [EnumMember(Value = "Broadcast")]
    [XmlEnum("Broadcast")]
    Broadcast,
    [EnumMember(Value = "Calendar")]
    [XmlEnum("Calendar")]
    Calendar,
}

public enum DynamicDateOffsetType
{
    [EnumMember(Value = "Hour")]
    [XmlEnum("Hour")]
    Hour,
    [EnumMember(Value = "Day")]
    [XmlEnum("Day")]
    Day,
    [EnumMember(Value = "Week")]
    [XmlEnum("Week")]
    Week,
    [EnumMember(Value = "Month")]
    [XmlEnum("Month")]
    Month,
    [EnumMember(Value = "Quarter")]
    [XmlEnum("Quarter")]
    Quarter,
    [EnumMember(Value = "Year")]
    [XmlEnum("Year")]
    Year,
}

public enum InvoiceLineType
{
    [EnumMember(Value = "Spot")]
    [XmlEnum("Spot")]
    Spot,
    [EnumMember(Value = "Audience")]
    [XmlEnum("Audience")]
    Audience,
    [EnumMember(Value = "Flat Rate")]
    [XmlEnum("FlatRate")]
    FlatRate,
}

public enum BillableCostsType
{
    [EnumMember(Value = "Booked")]
    [XmlEnum("Booked")]
    Booked,
    [EnumMember(Value = "Actuals")]
    [XmlEnum("Actuals")]
    Actuals,
}

public enum MakegoodType
{
    [EnumMember(Value = "Resolve preemption")]
    [XmlEnum("ResolvePreemption")]
    ResolvePreemption,
    [EnumMember(Value = "Audience Underdelivery")]
    [XmlEnum("AudienceUnderdelivery")]
    AudienceUnderdelivery,
}

public enum SalesElementEquivalentType
{
    [EnumMember(Value = "Same Sales Element")]
    [XmlEnum("SameSalesElement")]
    SameSalesElement,
    [EnumMember(Value = "Alternate Sales Element")]
    [XmlEnum("AlternateSalesElement")]
    AlternateSalesElement,
}

public enum MakegoodWindowType
{
    [EnumMember(Value = "Original Broadcast Week")]
    [XmlEnum("OriginalBroadcastWeek")]
    OriginalBroadcastWeek,
    [EnumMember(Value = "Original Broadcast Month")]
    [XmlEnum("OriginalBroadcastMonth")]
    OriginalBroadcastMonth,
    [EnumMember(Value = "Within Flight Dates")]
    [XmlEnum("WithinFlightDates")]
    WithinFlightDates,
}

public enum MakegoodAssumedConfirmType
{
    [EnumMember(Value = "Booked")]
    [XmlEnum("Booked")]
    Booked,
    [EnumMember(Value = "Not Booked")]
    [XmlEnum("NotBooked")]
    NotBooked,
}
