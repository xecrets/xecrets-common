#### [Xecrets.Texts](index.md 'index')
### [Xecrets.Texts](Xecrets.Texts.md 'Xecrets.Texts')

## Cultures Class

Provides the application cultures supported by the translated texts and applies the selected UI culture.

```csharp
public sealed class Cultures
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → Cultures
### Constructors

<a name='Xecrets.Texts.Cultures.Cultures(System.Func_string_)'></a>

## Cultures(Func<string>) Constructor

Initializes a new instance using the culture that should continue to format dates and numbers.

```csharp
public Cultures(System.Func<string> formattingCultureName);
```
#### Parameters

<a name='Xecrets.Texts.Cultures.Cultures(System.Func_string_).formattingCultureName'></a>

`formattingCultureName` [System.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System.Func`1')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System.Func`1')

Gets the platform's formatting culture name.
### Properties

<a name='Xecrets.Texts.Cultures.DisplayNames'></a>

## Cultures.DisplayNames Property

Gets the invariant display names corresponding to [Names](Xecrets.Texts.Cultures.md#Xecrets.Texts.Cultures.Names 'Xecrets.Texts.Cultures.Names').

```csharp
public string[] DisplayNames { get; }
```

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[[]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System.Array')

<a name='Xecrets.Texts.Cultures.Names'></a>

## Cultures.Names Property

Gets the supported culture names.

```csharp
public string[] Names { get; }
```

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[[]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System.Array')

<a name='Xecrets.Texts.Cultures.this[int]'></a>

## Cultures.this[int] Property

Gets the supported culture name at an index.

```csharp
public string this[int index] { get; }
```
#### Parameters

<a name='Xecrets.Texts.Cultures.this[int].index'></a>

`index` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Texts.Cultures.this[string]'></a>

## Cultures.this[string] Property

Gets the display name for a supported culture name.

```csharp
public string this[string name] { get; }
```
#### Parameters

<a name='Xecrets.Texts.Cultures.this[string].name'></a>

`name` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')
### Methods

<a name='Xecrets.Texts.Cultures.IndexOf(string)'></a>

## Cultures.IndexOf(string) Method

Gets the index of a supported culture name, or -1 when it is not supported.

```csharp
public int IndexOf(string name);
```
#### Parameters

<a name='Xecrets.Texts.Cultures.IndexOf(string).name'></a>

`name` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

#### Returns
[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

<a name='Xecrets.Texts.Cultures.SetBestCurrent(string)'></a>

## Cultures.SetBestCurrent(string) Method

Selects the closest supported UI culture and restores the platform formatting culture.

```csharp
public string SetBestCurrent(string name);
```
#### Parameters

<a name='Xecrets.Texts.Cultures.SetBestCurrent(string).name'></a>

`name` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

A preferred culture name, or an empty string to use the current UI culture.

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
The canonical selected supported culture name.