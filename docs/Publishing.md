# Publishing

## NuGet packages

- `Baghel.Tip.TransactionStandard`
- `Baghel.Tip.TransactionStandard.AspNetCore`

## Pre-publish checklist

- Confirm the version in [Version.props](/C:/Users/ravib/source/repos/tip-transaction-standard/Version.props)
- Update [CHANGELOG.md](/C:/Users/ravib/source/repos/tip-transaction-standard/CHANGELOG.md)
- Build the solution
- Run the test suite
- Pack both NuGet packages
- Review README and release notes for accuracy

## GitHub Actions setup

Recommended repository setup:

- add a repository secret named `NUGET_API_KEY`
- push normal commits to `main` to run CI
- push a version tag like `v0.2.2` after updating [Version.props](/C:/Users/ravib/source/repos/tip-transaction-standard/Version.props) and [CHANGELOG.md](/C:/Users/ravib/source/repos/tip-transaction-standard/CHANGELOG.md)

The repo now includes:

- `.github/workflows/ci.yml` for restore, build, test, and pack validation
- `.github/workflows/release.yml` for tag-based NuGet publish and GitHub Release creation

## Commands

```powershell
dotnet build src\TIPSolution.sln -c Release
dotnet test src\Test\Test.csproj -c Release
dotnet pack src\Core\Core.csproj -c Release -o .artifacts\packages
dotnet pack src\AspNetCore\Tip.TransactionStandard.AspNetCore.csproj -c Release -o .artifacts\packages
```

## Publish example

```powershell
dotnet nuget push .artifacts\packages\Baghel.Tip.TransactionStandard.0.2.1.nupkg --source https://api.nuget.org/v3/index.json --api-key $env:NUGET_API_KEY
dotnet nuget push .artifacts\packages\Baghel.Tip.TransactionStandard.AspNetCore.0.2.1.nupkg --source https://api.nuget.org/v3/index.json --api-key $env:NUGET_API_KEY
```

## GitHub Packages

GitHub Packages is optional for this project.

Use `nuget.org` as the primary public distribution channel because it is the default and most convenient source for .NET users. GitHub Packages is more useful when you want:

- private/internal package distribution
- organization-scoped access control
- pre-release feeds tied to GitHub authentication

## Current publish recommendation

Recommended now:

- publish as `0.2.1`
- treat it as the first public preview with broad endpoint coverage
- avoid `1.0.0` until response coverage and integration guidance are more mature
