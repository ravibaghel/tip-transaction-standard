# Package Design

## Design goals

- Match the TIP OpenAPI wire contract closely
- Keep the NuGet package easy to consume from supported .NET runtimes
- Support both client and server development
- Prefer explicit validation over constructor or setter exceptions
- Keep JSON and XML behavior consistent

## Project split

## `Tip.TransactionStandard`

Contains:

- contracts
- validation
- serialization
- HTTP helpers

## `Tip.TransactionStandard.AspNetCore`

Contains:

- ASP.NET Core registration helpers
- formatter configuration

## Target framework choice

The package targets `net8.0` to align with the minimum actively supported modern .NET version while remaining consumable from newer supported runtimes.

As of April 19, 2026, Microsoft lists `.NET 8`, `.NET 9`, and `.NET 10` as supported in the official support policy:

- `.NET 8` active through November 10, 2026
- `.NET 9` active through November 10, 2026
- `.NET 10` active through November 14, 2028

Source: [official .NET support policy](https://dotnet.microsoft.com/platform/support-policy)

## Current implementation slice

Included:

- shared common TIP contracts needed by `logtimes`
- shared common TIP contracts needed by `commercialInstructions`
- seller logtimes request contract
- buyer logtimes subscription request contract
- buyer commercial instructions request contract
- seller commercial instructions request contract
- accepted response and error response contracts
- JSON/XML serialization helpers
- validation rules for required fields and selected conditional requirements

Not yet included:

- the full TIP endpoint catalog
- advanced schema generation
- end-to-end sample applications
