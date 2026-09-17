#### [Xecrets.Texts](index.md 'index')
### [Xecrets.Texts](Xecrets.Texts.md 'Xecrets.Texts')

## Texts Class

Localized texts for the application. The texts are exposed as public string properties or methods when parameters are required.

```csharp
public class Texts
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → Texts

### Remarks

Although all members are static, this class is intentionally non-static so that XAML bindings can access static
members through an instance property — typically `public AllTexts Texts { get; } = new();` on the view-model
base. Avalonia binding syntax such as `{Binding Texts.MenuAbout}` reaches the static members via that
instance without any per-call allocation.

When a localizable text resource is renamed, added, or deleted, the corresponding property in this class must be
updated. Also, a new extraction of the resources must be done. Use 'extract-po-files.cmd' to extract the
resources to the .pot file and update the .po files.
The extraction is done with the tool POTools from https://github.com/xecrets/aspnetskeleton2.
To update the translations in the .po files, use any suitable .po editor, e.g., Poedit or the online editor at
https://localise.biz etc. When the translations are updated, the .po files must be updated here and the project
rebuilt.

Useful resources for translation can be found at:
https://learn.microsoft.com/en-us/globalization/reference/microsoft-style-guides
https://learn.microsoft.com/en-us/globalization/reference/microsoft-language-resources
ChatGPT and DeepL (or whatever AI rules in the future) may be of assistance for translations.
### Methods

<a name='Xecrets.Texts.Texts.Confirmation(string)'></a>

## Texts.Confirmation(string) Method

Appends the standard confirmation question to a message.

```csharp
public static string Confirmation(string m);
```
#### Parameters

<a name='Xecrets.Texts.Texts.Confirmation(string).m'></a>

`m` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The primary message text to confirm.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.DecryptionPasswordsAbout(int)'></a>

## Texts.DecryptionPasswordsAbout(int) Method

The about-text for the decryption passwords panel, parameterized on the password count.

```csharp
public static string DecryptionPasswordsAbout(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.DecryptionPasswordsAbout(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of decryption passwords currently loaded.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.DialogTextExpiresSoonInfo(string)'></a>

## Texts.DialogTextExpiresSoonInfo(string) Method

The information text shown when a license is expiring soon.

```csharp
public static string DialogTextExpiresSoonInfo(string expiresLocal);
```
#### Parameters

<a name='Xecrets.Texts.Texts.DialogTextExpiresSoonInfo(string).expiresLocal'></a>

`expiresLocal` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The expiry date and time, already formatted in the local timezone.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.DialogYubiKeyRedistributableMissing(string)'></a>

## Texts.DialogYubiKeyRedistributableMissing(string) Method

The message shown when the YubiKey CCID redistributable is missing, with a link to download it.

```csharp
public static string DialogYubiKeyRedistributableMissing(string link);
```
#### Parameters

<a name='Xecrets.Texts.Texts.DialogYubiKeyRedistributableMissing(string).link'></a>

`link` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The URL or display text of the download link.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.DropOrPasteToolTip(string)'></a>

## Texts.DropOrPasteToolTip(string) Method

The copy-key tooltip text, parameterized on the platform-specific copy key name since
Xecrets.Texts has no dependency on the platform abstractions in Xecrets.Ez.Models.

```csharp
public static string DropOrPasteToolTip(string copyKeyName);
```
#### Parameters

<a name='Xecrets.Texts.Texts.DropOrPasteToolTip(string).copyKeyName'></a>

`copyKeyName` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The platform-specific name of the copy key, e.g. "Ctrl" or "Option".

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.EzTitle(System.Version,bool,string)'></a>

## Texts.EzTitle(Version, bool, string) Method

The title of the application, parameterized on the version and signed-in email since Xecrets.Texts
has no dependency on the DI-resolved IEzVersion/IUsers abstractions in Xecrets.Ez.Models.

```csharp
public static string EzTitle(System.Version version, bool isSignedIn, string email);
```
#### Parameters

<a name='Xecrets.Texts.Texts.EzTitle(System.Version,bool,string).version'></a>

`version` [System.Version](https://learn.microsoft.com/en-us/dotnet/api/system.version 'System.Version')

The application version.

<a name='Xecrets.Texts.Texts.EzTitle(System.Version,bool,string).isSignedIn'></a>

`isSignedIn` [System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')

True if a user is currently signed in.

<a name='Xecrets.Texts.Texts.EzTitle(System.Version,bool,string).email'></a>

`email` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The signed-in user's email, ignored if [isSignedIn](Xecrets.Texts.Texts.md#Xecrets.Texts.Texts.EzTitle(System.Version,bool,string).isSignedIn 'Xecrets.Texts.Texts.EzTitle(System.Version, bool, string).isSignedIn') is false.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.FilesOpen(int)'></a>

## Texts.FilesOpen(int) Method

The command bar label showing the number of currently open files.

```csharp
public static string FilesOpen(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.FilesOpen(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of open files; selects the appropriate plural form.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.FilesProcessedMessage(int)'></a>

## Texts.FilesProcessedMessage(int) Method

The status message shown after a batch file operation completes.

```csharp
public static string FilesProcessedMessage(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.FilesProcessedMessage(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of files processed; selects the appropriate plural form.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.LabelClearPasswords(int)'></a>

## Texts.LabelClearPasswords(int) Method

The label for the decryption password clear button, showing the current count.

```csharp
public static string LabelClearPasswords(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.LabelClearPasswords(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of loaded decryption passwords; selects the appropriate plural form.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.MessageTextConfirmManyFiles(int)'></a>

## Texts.MessageTextConfirmManyFiles(int) Method

The confirmation message shown before acting on a large number of files.

```csharp
public static string MessageTextConfirmManyFiles(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.MessageTextConfirmManyFiles(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of files to be processed.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.PrivateKeysAbout(int,int)'></a>

## Texts.PrivateKeysAbout(int, int) Method

The about-text for the private keys panel, parameterized on the counts of user-specific and total keys.

```csharp
public static string PrivateKeysAbout(int u, int t);
```
#### Parameters

<a name='Xecrets.Texts.Texts.PrivateKeysAbout(int,int).u'></a>

`u` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of private keys for the current user.

<a name='Xecrets.Texts.Texts.PrivateKeysAbout(int,int).t'></a>

`t` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The total number of private keys loaded.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string)'></a>

## Texts.Splash(string, Version, string, string, bool, string) Method

The about-dialog splash text, parameterized on the version, runtime, build time and license blurb,
since Xecrets.Texts has no dependency on the DI-resolved abstractions in Xecrets.Ez.Models, and since
the splash file resource itself stays in Xecrets.Ez.Models.

```csharp
public static string Splash(string splashTemplate, System.Version version, string runtime, string buildUtcTextLocal, bool isInDesignMode, string blurb);
```
#### Parameters

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).splashTemplate'></a>

`splashTemplate` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The splash text template, with {version}/{runtime}/{buildutc}/{blurb} placeholders.

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).version'></a>

`version` [System.Version](https://learn.microsoft.com/en-us/dotnet/api/system.version 'System.Version')

The application version.

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).runtime'></a>

`runtime` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The runtime description.

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).buildUtcTextLocal'></a>

`buildUtcTextLocal` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The build time, already converted to local time and formatted as text.

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).isInDesignMode'></a>

`isInDesignMode` [System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')

True if running in the Avalonia designer, in which case the license blurb is not shown.

<a name='Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).blurb'></a>

`blurb` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The license blurb, ignored if [isInDesignMode](Xecrets.Texts.Texts.md#Xecrets.Texts.Texts.Splash(string,System.Version,string,string,bool,string).isInDesignMode 'Xecrets.Texts.Texts.Splash(string, System.Version, string, string, bool, string).isInDesignMode') is true.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.ViewSharesDescriptionFormat(int)'></a>

## Texts.ViewSharesDescriptionFormat(int) Method

The description for the share-viewer panel, showing the number of shares currently loaded.

```csharp
public static string ViewSharesDescriptionFormat(int n);
```
#### Parameters

<a name='Xecrets.Texts.Texts.ViewSharesDescriptionFormat(int).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The number of shares loaded; selects the appropriate plural form.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Texts.XecretsHelpUrl(string)'></a>

## Texts.XecretsHelpUrl(string) Method

The help site URL for Xecrets Ez, optionally with a named fragment anchor.

```csharp
public static string XecretsHelpUrl(string fragment="");
```
#### Parameters

<a name='Xecrets.Texts.Texts.XecretsHelpUrl(string).fragment'></a>

`fragment` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

An optional URL fragment, e.g. `"#sandbox"`. Defaults to an empty string.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')