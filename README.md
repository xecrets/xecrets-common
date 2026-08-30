# Xecrets Common

This repository holds code and localized texts that are shared across the Xecrets desktop and
mobile apps. Anything that more than one Xecrets app needs - a data model, a storage or
protection abstraction, a piece of user-facing text - belongs here rather than being duplicated
in each app.

Because it is shared this widely, code in this repository is kept free of dependencies beyond the
.NET framework itself, so that it can safely be referenced from any Xecrets app on any platform
without dragging in anything an app doesn't already need.

The repository contains two NuGet packages, each documented in its own README:

- **[Xecrets.Common](src/Xecrets.Common/README.md)** - common data models and the
  storage/protection abstractions (`IXecretsDataStore`, `IUserDataStore`, `IPersistentData<T>`,
  `IXecretsProtection`) shared by the apps.
- **[Xecrets.Texts](src/Xecrets.Texts/README.md)** - user interface texts and gettext-based
  localization for the apps.

## How To Build?

Open the solution in `src` in Visual Studio, or the workspace in Visual Studio Code, and build.
There are no external dependencies that are not resolved with NuGet.

## How to Contribute

Talk to us. Due to the nature of the application, pull requests are audited very carefully.
Before requesting a pull it's best if we discuss things.

Minimum requirement is that there are no compiler warnings and no failed tests.

## Contact

Contact us via our [support](https://www.axantum.com/support "Xecrets Support Site") or through
github.
