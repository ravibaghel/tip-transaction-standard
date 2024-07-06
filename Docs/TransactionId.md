# Transaction identifier details

| Model / Property Name |	Required, Optional | Data Type | Description |
| --- | --- | --- | --- |
|transactionId |	Required | String	| Global unique identifier (GUID) |
|transactionType | Required | Enum | The type of transaction. New, Change, Cancel, Reject, Recall, Confirm 	Indicates the transaction type |
|sourceId | Required | String | Indicates the unique identifier of the source of information from an external system  |
|sourceName | Required | String | Indicates the name of the source of information from an external system   |