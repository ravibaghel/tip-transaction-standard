# Tip.TransactionStandard

`Tip.TransactionStandard` is a contract-first .NET library for the Television Interface Practices Initiative (TIP) APIs, designed for NuGet consumption in both client and server applications.

This rewrite aligns with the TIP OpenAPI definitions from [`tip-initiative/tip-initiative-apis`](https://github.com/tip-initiative/tip-initiative-apis), with the current implementation focused on the `logtimes`, `commercialInstructions`, `rfps`, `proposals`, `orders`, and `inventoryAvails` workflows plus the shared common contracts they depend on.

## What the package includes

- Strongly typed TIP contracts for shared objects, `logtimes`, `commercialInstructions`, `rfps`, `proposals`, `orders`, and `inventoryAvails`
- JSON serialization helpers for `application/json`
- XML serialization helpers for `application/xml`
- Recursive validation without throwing in property setters
- `HttpContent` helpers for TIP client integrations
- ASP.NET Core registration helpers for server-side content negotiation
- Contract tests against TIP-style JSON, XML, and OpenAPI fixtures

## Supported .NET versions

The package targets `net8.0`.

That is intentional: on April 19, 2026, the actively supported modern .NET trains from Microsoft are `.NET 8`, `.NET 9`, and `.NET 10`, and a `net8.0` package is consumable from those supported runtimes while keeping the dependency surface as broad as possible. Source: [official .NET support policy](https://dotnet.microsoft.com/platform/support-policy).

## Current scope

Implemented now:

- Shared TIP common contracts required by `logtimes`
- Seller `POST /seller/logtimes`
- Buyer `POST /buyer/logtimes/subscription`
- Buyer `POST /buyer/commercialInstructions`
- Seller `POST /seller/commercialInstructions`
- Buyer `POST /buyer/rfps`
- Seller `POST /seller/proposals`
- Buyer `POST /buyer/proposals`
- Buyer `POST /buyer/orders`
- Seller `POST /seller/orders`
- Buyer `POST /buyer/inventoryAvails/subscription`
- Seller `POST /seller/inventoryAvails`
- Shared responses, validation, JSON/XML serializers, ASP.NET Core integration

Planned next:

- Additional TIP endpoint families beyond `logtimes`, `commercialInstructions`, `rfps`, `proposals`, `orders`, and `inventoryAvails`
- More schema fixtures and response coverage
- More package-level compatibility and integration tests

## Quick start

```csharp
using Tip.TransactionStandard.Contracts.LogTimes;
using Tip.TransactionStandard.Serialization;
using Tip.TransactionStandard.Validation;

var request = TipPayloadSerializer.DeserializeJson<SellerLogtimesRequest>(json);
var issues = TipValidator.ValidateObject(request);

if (issues.Count == 0)
{
    var xml = TipPayloadSerializer.SerializeXml(request);
}
```

ASP.NET Core:

```csharp
builder.Services
    .AddControllers()
    .AddTipTransactionStandard();
```

Client usage:

```csharp
using Tip.TransactionStandard.Http;

var content = TipHttpContent.CreateJson(request);
```

## Repository layout

- [src/Core/Core.csproj](/C:/Users/ravib/source/repos/tip-transaction-standard/src/Core/Core.csproj)
- [src/AspNetCore/Tip.TransactionStandard.AspNetCore.csproj](/C:/Users/ravib/source/repos/tip-transaction-standard/src/AspNetCore/Tip.TransactionStandard.AspNetCore.csproj)
- [src/Test/Test.csproj](/C:/Users/ravib/source/repos/tip-transaction-standard/src/Test/Test.csproj)
- [docs/GettingStarted.md](/C:/Users/ravib/source/repos/tip-transaction-standard/docs/GettingStarted.md)
- [docs/PackageDesign.md](/C:/Users/ravib/source/repos/tip-transaction-standard/docs/PackageDesign.md)

## Build and test

```powershell
dotnet build src\TIPSolution.sln
dotnet test src\Test\Test.csproj
```

## Reference

- TIP API repository: [tip-initiative/tip-initiative-apis](https://github.com/tip-initiative/tip-initiative-apis)
- TIP `v6.0.0` `logtimes`, `commercialInstructions`, `rfps`, `proposals`, `orders`, and `inventoryAvails` examples and schemas were used as the baseline for the current contract rewrite
