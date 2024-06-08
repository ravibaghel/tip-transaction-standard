# Transaction Header
General transaction header information. The transaction header is an object that contains the metadata for a transaction. It is used to store information about the transaction, such as the transaction ID, the transaction type, the transaction timestamp, and the transaction status.

| Model / Property Name |	Required, Optional | Data Type | Description |
| --- | --- | --- | --- |
| transactionId |	Required | String		Global unique identifier (GUID) |
|transactionType | Required	| Enum	| New, Change, Cancel, Reject, Recall, Confirm Indicates the transaction type |
|sourceId	| Required	|	String	| Indicates the unique identifier of the source of information from an external system |
|sourceName |	Required	|	String	| Indicates the name of the source of information from an external system |
