# AGENTS.md

## Project Overview

This repository contains `Tip.TransactionStandard`, a contract-first .NET library for the Television Interface Practices Initiative (TIP) APIs. The packages target `net8.0` and are designed for NuGet consumption in both client and server applications.

The implementation is organized around TIP OpenAPI wire contracts. Preserve compatibility with the TIP JSON/XML payload shape whenever changing public models, serializers, validators, or fixtures.

The package split is:

- `Baghel.Tip.TransactionStandard`: core TIP contracts, validation, JSON/XML serialization, and HTTP content helpers.
- `Baghel.Tip.TransactionStandard.AspNetCore`: ASP.NET Core formatter and MVC registration helpers.

## Repository Map

- `src/Core`: core library source for contracts, serializers, validators, and HTTP helpers.
- `src/AspNetCore`: ASP.NET Core integration package.
- `src/Test`: xUnit test project.
- `src/Test/Fixtures`: JSON, XML, and OpenAPI fixtures used by contract tests.
- `docs`: package design, versioning, publishing, and domain notes.
- `.github/workflows`: CI and release automation.
- `Version.props`: central package and assembly version metadata.
- `CHANGELOG.md`: release history and user-facing change notes.

## Development Rules

- Treat the TIP OpenAPI definitions and existing fixtures as the source of truth for wire behavior.
- Keep public contract property names, JSON property names, XML element names, enum values, and namespaces stable unless a TIP contract change requires an intentional breaking change.
- Prefer explicit validation through data annotations, `ITipValidatable`, and `TipValidator` over throwing from constructors or property setters.
- Keep JSON and XML behavior consistent for the same contract whenever the TIP standard supports both formats.
- Use nullable reference types intentionally. Required wire fields are generally nullable CLR properties with validation attributes so deserialization can succeed before validation reports missing data.
- Do not broaden dependencies casually. This library should stay easy to consume from supported .NET runtimes.
- The project files use explicit compile includes. When adding source or test files outside existing included globs, update the relevant `.csproj` file deliberately.
- Keep changes scoped. Avoid unrelated refactors, namespace churn, or cosmetic rewrites in generated-looking contract areas.

## Build And Test

Run these commands from the repository root:

```powershell
dotnet restore src\TIPSolution.sln
dotnet build src\TIPSolution.sln -c Release
dotnet test src\Test\Test.csproj -c Release
```

CI uses the same restore/build/test flow with `--no-restore` and `--no-build` optimizations after restore/build. Before release-oriented changes, also verify package creation:

```powershell
dotnet pack src\Core\Core.csproj -c Release --no-build -o .artifacts\packages
dotnet pack src\AspNetCore\Tip.TransactionStandard.AspNetCore.csproj -c Release --no-build -o .artifacts\packages
```

## Contract And Fixture Guidance

- Add or update fixtures in `src/Test/Fixtures` when changing contract coverage or wire behavior.
- Follow the existing xUnit and FluentAssertions patterns in `src/Test/Tests`.
- Serialization changes should cover round-tripping and important wire names for JSON and, where supported, XML.
- Validation changes should assert returned `TipValidationIssue` paths and messages instead of relying on thrown exceptions.
- OpenAPI compatibility changes should use the existing OpenAPI fixture test style rather than ad hoc schema checks.
- HTTP helper changes should verify content type, payload encoding, and serializer behavior.
- ASP.NET Core changes should verify MVC formatter/options registration without requiring a sample app unless the change truly needs end-to-end coverage.

## Release Guidance

- Version metadata is centralized in `Version.props`.
- User-facing release notes belong in `CHANGELOG.md`.
- Package-specific release note summaries live in the `.csproj` files when they materially change.
- CI builds, tests, packs, and uploads NuGet package artifacts for pushes to `main` and pull requests.
- The release workflow runs on `v*.*.*` tags or manual dispatch, publishes packages to NuGet, and creates a GitHub release.
- For release changes, update version metadata and changelog together, then run build, test, and pack verification before tagging.

## Agent Safety Notes

- This file is for any coding agent. Do not assume a specific agent runtime, plugin, editor, or shell beyond the repository's documented commands.
- Prefer reading existing contracts, fixtures, docs, and tests before designing changes.
- If the TIP standard and existing implementation disagree, call out the discrepancy and preserve current behavior until the intended contract change is explicit.
- Do not delete fixtures or reduce test coverage to make a change pass.
- Do not change package IDs, target framework, public namespaces, or release automation unless the task explicitly requires it.
