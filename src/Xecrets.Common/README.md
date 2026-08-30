# Xecrets Common

Common data models and storage/protection abstractions shared by the Xecrets family of apps.

Xecrets Common does not implement any of these on its own - it only defines the shapes and
contracts that the Xecrets apps agree on, so that application data can be created, read and
migrated the same way regardless of which app or platform it runs on. It targets .NET 10, and has
no dependencies beyond the framework itself.

## Data stores

[IXecretsDataStore](Abstractions/IXecretsDataStore.cs) gives top-level access to an application's
persisted state: its application-wide `ApplicationSettings`, a summary of every known user, and
the ability to create or open a per-user store, as well as export and import the whole
application configuration.

[IUserDataStore](Abstractions/IUserDataStore.cs) is that per-user store. It's where a single
user's `UserSettings`, `ExtraCredentials`, `PrivateKeyData`, `OpenFiles`, `RecentFiles`,
`LicenseData` and `WorkFolders` live.

## The edit-scope pattern

Every piece of data behind these stores is exposed as an `IPersistentData<T>`, which is edited
through an `IEditScope<T>`. The scope only writes the value back to its underlying store if it
actually changed since it was loaded, so read-only access never causes a spurious save:

```csharp
IUserDataStore user = await dataStore.OpenUserAsync(userId);
IPersistentData<UserSettings> settingsData = await user.LoadSettingsAsync();

await using IEditScope<UserSettings> scope = settingsData.BeginEdit();
scope.Value.LastWriteUtc = DateTime.UtcNow;
// Saved automatically on disposal - or call scope.SaveAsync(force: true) explicitly.
```

## Protecting sensitive data

[IXecretsProtection](Abstractions/IXecretsProtection.cs) protects and unprotects arbitrary bytes
at rest, independent of any particular storage or platform mechanism. Built on top of it,
[IProtectedPayload](Abstractions/IProtectedPayload.cs) protects and unprotects whole objects -
serializing to and from JSON via the source-generated `CommonJsonContext` - falling back to
sensible defaults for missing or malformed payloads.

## Models

The `Xecrets.Common.Models` namespace contains the data transfer objects persisted through the
above, such as `ApplicationSettings`, `UserSettings`, `PrivateKeyData`, `RecentFiles`,
`WorkFolders` and `LicenseData`. These are the types an app actually reads and writes; the
abstractions above only describe how they get loaded, edited and saved.
