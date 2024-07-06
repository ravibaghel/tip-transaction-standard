﻿# Transaction Header

General transaction header information. The transaction header is an object that contains the metadata for a transaction. It is used to store information about the transaction, such as the transaction ID, the transaction type, the transaction timestamp, and the transaction status.

| Model / Property Name |	Required, Optional | Data Type | Description |
| --- | --- | --- | --- |
|tipVersion|	Required	|String	|Indicates the version of the TIP specification that the transaction is compliant with. The version number is in the format of Major.Minor.Patch. For example, 1.0.0.|
|transactionId |	Required | [TransactionId](./TransactionId.md)	|	Global unique identifier (GUID) |
|originalTransactionId | Optional	| [TransactionId](./TransactionId.md)	|  |
|timeStamp	| Required	|	Date-Time	| {"example": "2021-07-21T17:32:28Z"}	Date and time the transaction was created - date-time represent UTC of the server|