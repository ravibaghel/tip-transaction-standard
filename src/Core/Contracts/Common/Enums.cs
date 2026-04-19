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
