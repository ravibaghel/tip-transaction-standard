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
