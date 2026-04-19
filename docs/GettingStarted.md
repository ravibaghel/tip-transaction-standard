# Getting Started

## Packages

- `Tip.TransactionStandard`
- `Tip.TransactionStandard.AspNetCore`

## JSON and XML

The library treats JSON and XML as first-class wire formats:

- `TipPayloadSerializer.SerializeJson` / `DeserializeJson`
- `TipPayloadSerializer.SerializeXml` / `DeserializeXml`
- `TipHttpContent.CreateJson` / `CreateXml`

## Validation

Validation is explicit and non-throwing:

```csharp
var issues = TipValidator.ValidateObject(payload);
if (issues.Count > 0)
{
    // return 400, log, or surface issues to the caller
}
```

This is safer for server and client integrations than setter-based validation because it supports:

- partial deserialization
- request inspection
- error aggregation
- model binding scenarios

## ASP.NET Core

```csharp
builder.Services
    .AddControllers()
    .AddTipTransactionStandard();
```

That enables:

- XML formatter registration
- JSON enum/value handling aligned with TIP payloads

## HttpClient

```csharp
using Tip.TransactionStandard.Http;

using var content = TipHttpContent.CreateXml(payload);
var response = await httpClient.PostAsync("/seller/logtimes", content);
```
