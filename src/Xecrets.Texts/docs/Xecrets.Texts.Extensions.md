#### [Xecrets.Texts](index.md 'index')
### [Xecrets.Texts](Xecrets.Texts.md 'Xecrets.Texts')

## Extensions Class

Extensions and helpers for URL rewriting, string formatting and file name manipulation used across Xecrets assemblies.

```csharp
public static class Extensions
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → Extensions
### Properties

<a name='Xecrets.Texts.Extensions.EncryptedExtension'></a>

## Extensions.EncryptedExtension Property

The official extension used for encrypted files, including the leading dot.

```csharp
public static string EncryptedExtension { get; }
```

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')
### Methods

<a name='Xecrets.Texts.Extensions.AddEncryptedExtension(thisstring)'></a>

## Extensions.AddEncryptedExtension(this string) Method

Add the extension for an encrypted file

```csharp
public static string AddEncryptedExtension(this string file);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.AddEncryptedExtension(thisstring).file'></a>

`file` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

A file name, presumably without extension

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The file parameter with the extension for encrypted files concatenated.

<a name='Xecrets.Texts.Extensions.Encrypted(thisSystem.Collections.Generic.IEnumerable_string_)'></a>

## Extensions.Encrypted(this IEnumerable<string>) Method

Select the files that appear to be encrypted, according to their extension.

```csharp
public static string[] Encrypted(this System.Collections.Generic.IEnumerable<string> files);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.Encrypted(thisSystem.Collections.Generic.IEnumerable_string_).files'></a>

`files` [System.Collections.Generic.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')

File names to filter

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[[]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System.Array')  
An array of the files that match the pattern for encrypted files.

<a name='Xecrets.Texts.Extensions.FormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,object[])'></a>

## Extensions.FormatUi(this LocalizedString, object[]) Method

Formats a [Microsoft.Extensions.Localization.LocalizedString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.localization.localizedstring 'Microsoft.Extensions.Localization.LocalizedString') using [System.Globalization.CultureInfo.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System.Globalization.CultureInfo.CurrentCulture').

```csharp
public static string FormatUi(this Microsoft.Extensions.Localization.LocalizedString format, params object[] args);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.FormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,object[]).format'></a>

`format` [Microsoft.Extensions.Localization.LocalizedString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.localization.localizedstring 'Microsoft.Extensions.Localization.LocalizedString')

The raw localized menu string.

<a name='Xecrets.Texts.Extensions.FormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,object[]).args'></a>

`args` [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object')[[]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System.Array')

Format arguments passed to [System.String.Format(System.IFormatProvider,System.String,System.Object[])](https://learn.microsoft.com/en-us/dotnet/api/system.string.format#system-string-format(system-iformatprovider-system-string-system-object[]) 'System.String.Format(System.IFormatProvider,System.String,System.Object[])').

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The formatted string.

<a name='Xecrets.Texts.Extensions.IsEncrypted(thisstring)'></a>

## Extensions.IsEncrypted(this string) Method

A predicate determining of the name of a file has the suggested encrypted extension, i.e. ".axx".

```csharp
public static bool IsEncrypted(this string file);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.IsEncrypted(thisstring).file'></a>

`file` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

A file name, presumably without extension

#### Returns
[System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the name ends with the encrypted extension.

<a name='Xecrets.Texts.Extensions.NotEncrypted(thisSystem.Collections.Generic.IEnumerable_string_)'></a>

## Extensions.NotEncrypted(this IEnumerable<string>) Method

Select the files that appear not to be encrypted, according to their extension.

```csharp
public static System.Collections.Generic.IEnumerable<string> NotEncrypted(this System.Collections.Generic.IEnumerable<string> files);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.NotEncrypted(thisSystem.Collections.Generic.IEnumerable_string_).files'></a>

`files` [System.Collections.Generic.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')

File names to filter

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System.Collections.Generic.IEnumerable`1')  
An enumeration of the files that do not match the pattern for encrypted files.

<a name='Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[])'></a>

## Extensions.PluralFormatUi(this LocalizedString, int, object[]) Method

Formats a pipe-delimited plural [Microsoft.Extensions.Localization.LocalizedString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.localization.localizedstring 'Microsoft.Extensions.Localization.LocalizedString') by selecting the segment matching [n](Xecrets.Texts.Extensions.md#Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[]).n 'Xecrets.Texts.Extensions.PluralFormatUi(this Microsoft.Extensions.Localization.LocalizedString, int, object[]).n')/>.

```csharp
public static string PluralFormatUi(this Microsoft.Extensions.Localization.LocalizedString format, int n, params object[] args);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[]).format'></a>

`format` [Microsoft.Extensions.Localization.LocalizedString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.localization.localizedstring 'Microsoft.Extensions.Localization.LocalizedString')

The raw localized menu string.

<a name='Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[]).n'></a>

`n` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The count that selects the plural form. Negative values return an empty string.

<a name='Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[]).args'></a>

`args` [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object')[[]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System.Array')

Additional format arguments.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The formatted plural string, or [System.String.Empty](https://learn.microsoft.com/en-us/dotnet/api/system.string.empty 'System.String.Empty') when [n](Xecrets.Texts.Extensions.md#Xecrets.Texts.Extensions.PluralFormatUi(thisMicrosoft.Extensions.Localization.LocalizedString,int,object[]).n 'Xecrets.Texts.Extensions.PluralFormatUi(this Microsoft.Extensions.Localization.LocalizedString, int, object[]).n') is negative.

<a name='Xecrets.Texts.Extensions.StripAccelerator(thisMicrosoft.Extensions.Localization.LocalizedString)'></a>

## Extensions.StripAccelerator(this LocalizedString) Method

Strips accelerator underscores from a localized menu string, keeping any ellipsis. Use for text that is
displayed outside of a menu, but still triggers a dialog or a further selection, such as a tool bar button.

```csharp
public static string StripAccelerator(this Microsoft.Extensions.Localization.LocalizedString format);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.StripAccelerator(thisMicrosoft.Extensions.Localization.LocalizedString).format'></a>

`format` [Microsoft.Extensions.Localization.LocalizedString](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.localization.localizedstring 'Microsoft.Extensions.Localization.LocalizedString')

The raw localized menu string.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The text without accelerator underscores.

### Remarks
Chain with [StripEllipsis(this string)](Xecrets.Texts.Extensions.md#Xecrets.Texts.Extensions.StripEllipsis(thisstring) 'Xecrets.Texts.Extensions.StripEllipsis(this string)') when the text is used as a title, a heading or for an action
that is carried out immediately, i.e. where nothing further follows.

<a name='Xecrets.Texts.Extensions.StripEllipsis(thisstring)'></a>

## Extensions.StripEllipsis(this string) Method

Strips ellipsis, both the single character and the three period variant, from a text. Use for text that is
used as a title or a heading, or for an action that is taken immediately, since an ellipsis indicates that a
dialog or a further selection follows.

```csharp
public static string StripEllipsis(this string text);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.StripEllipsis(thisstring).text'></a>

`text` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The text to strip the ellipsis from, typically the result of [StripAccelerator(this LocalizedString)](Xecrets.Texts.Extensions.md#Xecrets.Texts.Extensions.StripAccelerator(thisMicrosoft.Extensions.Localization.LocalizedString) 'Xecrets.Texts.Extensions.StripAccelerator(this Microsoft.Extensions.Localization.LocalizedString)').

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The text without any ellipsis.

<a name='Xecrets.Texts.Extensions.ToEncryptedName(thisstring,string)'></a>

## Extensions.ToEncryptedName(this string, string) Method

Build an encrypted file name from the original file name, i.e. according to the pattern: filename.ext =>
filename-ext.axx

```csharp
public static string ToEncryptedName(this string file, string destinationFileFullFolder);
```
#### Parameters

<a name='Xecrets.Texts.Extensions.ToEncryptedName(thisstring,string).file'></a>

`file` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

A file name, presumably without extension

<a name='Xecrets.Texts.Extensions.ToEncryptedName(thisstring,string).destinationFileFullFolder'></a>

`destinationFileFullFolder` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The full path to an optional destination folder. Set to empty string if same as source.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The suggested name for it when encrypted.