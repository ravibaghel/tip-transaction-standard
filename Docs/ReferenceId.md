# Reference Identifier

Reference details for RFP, Proposal, Order and Invoice 

| Property              | Required | Type              | Example       | Description                                                                                           |
|-----------------------|----------|-------------------|---------------|-------------------------------------------------------------------------------------------------------|
| referenceSourceName   | Required | String            | "KHOU-TV"     | Name associated with the organization that is supplying the ids and version information              |
| referenceSourceId     | Required | String            | "REF-1234"    | ID associated with the organization sending the information                                          |
| referenceSourceLookup | Optional | String            |               | Reference source look up such as a URI to lookup information about the reference source name         |
| referenceType         | Required | Enum              | RFP, Proposal, Deal, Order, Invoice, Subscription | Indicates the type of data that is being provided |
| referenceId           | Required | Integer, String   | "REF-1234"    | Indicates the number or string ID associated with the reference type                                |
| referenceVersionId    | Optional | String            | "01"          | Version number associated with the reference id; this is used to track changes                      |
| referenceName         | Optional | String            | "Hyundai 1Q22" | Free form name used to further identify the type of entity such as the name associated to the RFP, Order, Proposal, or other types of references |
