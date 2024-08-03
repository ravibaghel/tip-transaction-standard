# Unit Documentation

## Table of Contents
- [Unit](#unit)
- [Table of Properties](#table-of-properties)

## Unit
Type definition for unit detail information.

## Table of Properties
| Property | Type | Required | Description |
| --- | --- | --- | --- |
| `UnitId` | string | required | Seller generated unique number for unit (ID will likely change if unit is moved to another week during recon process). |
| `ReferenceIds` | array of ReferenceId objects | required | Array of ReferenceId objects containing the order id references; may also contain originating RFP and Proposal id and source references. |
| `LineReferences` | array of Identifier objects | required | Array of identifier objects to identify a line id and system source; note- once the identifier object has been adopted the goal is to remove existing lineNum and lineReference. |
| `CpeCode` | CpeCode object | optional | CpeCode information. |
| `Buyer` | Buyer object | optional | Buyer information. |
| `Advertiser` | Advertiser object | required | Advertiser information. |
| `Brand` | Brand object | optional | Brand information. |
| `Product` | Product object | required | Product information. |
| `SalesElementHeader` | SalesElementHeader object | required | SalesElementHeader information. |
| `Program` | string | optional | This indicates the program the spot aired in - 'as-aired' information. |
| `Daypart` | string | optional | This indicates the daypart the spot aired in - 'as-aired' information. |
| `InventoryType` | string | optional | Type of advertising such as a commercial, billboard or other types of advertisement. |
| `LinkType` | LinkType object | optional | LinkType information. |
| `IsMakegood` | boolean | optional | Indicates if the spot is a makegood. |
| `IsAdu` | boolean | optional | Audience Deficiency Unit; Units of commercial advertising inventory made available to advertisers as fulfillment for the inventory the advertisers purchased that ran in programs that under-delivered on contracted audience demographic ratings. |
| `PreemptUnitIds` | array of strings | optional | ArrayList of the 'original' preempted unit being resolved when the isMakegood indicator is 'Y'; a makegood unit may be resolved by one too many preempt spots. |
| `IsBonus` | boolean | optional | $0 (i.e., free) ad impressions/pricing that a publisher includes with paid media to maximize the overall proposal/order. |
| `AiredLength` | integer | required | Length of commercial unit. |
| `BookedLength` | integer | optional | Actual length of commercial unit. |
| `Rate` | float | optional | Gross unit rate. |
| `Creative` | Creative object | optional | Creative information. |
| `Status` | enum | required | Indicated the airing status for the spot. Possible values: Aired, Scheduled, No Run, Finalized, Not Scheduled, Preempted. |
| `IsCredit` | boolean | optional | Indicate if the spot was issued a credit due to a discrepancy. |
| `TimePeriods` | array of TimePeriod objects | optional | Array of TimePeriod objects indicating SalesElement ordered day and time period constraints. |
| `DateTime` | DateTime object | optional | Not required when unit's status is "No Run". |
| `ChildUnits` | array of ChildUnit objects | optional | Array of ChildUnit objects. |
