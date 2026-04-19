# Versioning

## Current strategy

The packages use pre-1.0 semantic-style versioning:

- `0.x.0` means a feature release
- `0.x.y` means a patch release
- breaking API changes are possible before `1.0.0`, but they must be called out in the changelog and package release notes

Current release line:

- `0.2.1` is the current public-preview candidate for the full endpoint surface currently implemented in this repo

## Package version sources

Version metadata is centralized in [Version.props](/C:/Users/ravib/source/repos/tip-transaction-standard/Version.props).

That file controls:

- `VersionPrefix`
- `AssemblyVersion`
- `FileVersion`
- `InformationalVersion`

## Release notes workflow

For every release:

1. Update [CHANGELOG.md](/C:/Users/ravib/source/repos/tip-transaction-standard/CHANGELOG.md) with the new version entry.
2. Update package `PackageReleaseNotes` summaries in the `.csproj` files if the package-specific notes changed materially.
3. Run `dotnet build src\TIPSolution.sln`.
4. Run `dotnet test src\Test\Test.csproj`.
5. Run `dotnet pack` for both packages and verify the generated `.nupkg` files.
6. Tag the release in git after the publish is complete.

## When to move to 1.0

The packages should stay on `0.x` until these are true:

- the public contract model naming is stable
- response-model coverage is broader
- ASP.NET Core integration examples are documented end-to-end
- publish/install guidance is validated by at least one external consumer workflow
