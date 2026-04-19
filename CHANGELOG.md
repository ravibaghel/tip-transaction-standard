# Changelog

All notable changes to this project will be documented in this file.

The project follows a practical pre-1.0 versioning model:

- `0.x.0` for feature releases and notable contract expansion
- `0.x.y` for fixes, docs, and packaging corrections with no intended breaking API changes
- breaking API changes are allowed before `1.0.0`, but they should be called out clearly in release notes

## [0.2.0] - 2026-04-19

### Added

- Full contract coverage for the currently tracked TIP endpoint catalog in `tip-initiative-apis/develop/endpoints`
- Buyer and seller support for `audiences`
- Seller support for `politicalCompetitive`
- Shared audience detail and company contract models
- JSON/XML/OpenAPI regression coverage for audiences and political competitive
- Shared dynamic-date contract reused by `inventoryAvails` and `impressionssub`

### Improved

- NuGet package scope now reflects the expanded endpoint surface
- Docs and endpoint roadmap now track implementation status and remaining hardening work
- Packaging guidance now includes versioning and release-note workflow

## [0.1.0] - 2026-04-19

### Added

- Initial contract-first package structure for `Tip.TransactionStandard` and `Tip.TransactionStandard.AspNetCore`
- Validation, JSON/XML serializers, HTTP helpers, and ASP.NET Core registration helpers
- TIP coverage for `logtimes`, `commercialInstructions`, `rfps`, `proposals`, `orders`, `inventoryAvails`, `invoice`, `makegoods`, `creativeAssets`, and `impressionssub`
- Fixture-backed unit and OpenAPI regression tests
