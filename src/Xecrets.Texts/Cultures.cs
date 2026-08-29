#region Copyright and License

/*
 * Xecrets Texts - Copyright © 2022-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Texts
 *
 * Xecrets Texts is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Texts is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Texts.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-common please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Globalization;

namespace Xecrets.Texts;

/// <summary>
/// Provides the application cultures supported by the translated texts and applies the selected UI culture.
/// </summary>
public sealed class Cultures
{
    private readonly Dictionary<string, string> _cultures = new()
    {
        ["en-US"] = Texts.MenuEnglish,
        ["de-DE"] = Texts.MenuGerman,
        ["es-ES"] = Texts.MenuSpanish,
        ["fr-FR"] = Texts.MenuFrench,
        ["it-IT"] = Texts.MenuItalian,
        ["pl-PL"] = Texts.MenuPolish,
        ["pt-BR"] = Texts.MenuPortugueseBrasil,
        ["sv-SE"] = Texts.MenuSwedish,
        ["zh-CN"] = Texts.MenuSimplifiedChinese,
    };

    private readonly Func<string> _formattingCultureName;

    /// <summary>
    /// Gets the supported culture names.
    /// </summary>
    public string[] Names { get; }

    /// <summary>
    /// Gets the invariant display names corresponding to <see cref="Names"/>.
    /// </summary>
    public string[] DisplayNames { get; }

    /// <summary>
    /// Initializes a new instance using the culture that should continue to format dates and numbers.
    /// </summary>
    /// <param name="formattingCultureName">Gets the platform's formatting culture name.</param>
    public Cultures(Func<string> formattingCultureName)
    {
        _formattingCultureName = formattingCultureName;

        Names = [.. _cultures.Keys];
        DisplayNames = [.. _cultures.Values];
    }

    /// <summary>
    /// Gets the index of a supported culture name, or -1 when it is not supported.
    /// </summary>
    public int IndexOf(string name) => Array.IndexOf(Names, name);

    /// <summary>
    /// Gets the display name for a supported culture name.
    /// </summary>
    public string this[string name] => _cultures[name];

    /// <summary>
    /// Gets the supported culture name at an index.
    /// </summary>
    public string this[int index] => Names[index];

    /// <summary>
    /// Selects the closest supported UI culture and restores the platform formatting culture.
    /// </summary>
    /// <param name="name">A preferred culture name, or an empty string to use the current UI culture.</param>
    /// <returns>The canonical selected supported culture name.</returns>
    public string SetBestCurrent(string name)
    {
        string current = FindBest(name);
        CultureInfo.CurrentUICulture = new CultureInfo(current);

        string formattingCultureName = _formattingCultureName();
        if (formattingCultureName != CultureInfo.CurrentCulture.Name)
        {
            CultureInfo.CurrentCulture = new CultureInfo(formattingCultureName);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture;
        }

        return current;
    }

    private string FindBest(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            name = CultureInfo.CurrentUICulture.Name;
        }

        string? exactMatch = Names.FirstOrDefault(n => string.Equals(n, name, StringComparison.OrdinalIgnoreCase));
        if (exactMatch is not null)
        {
            return exactMatch;
        }

        try
        {
            string language = new CultureInfo(name).TwoLetterISOLanguageName;
            string? bestMatch = Names.FirstOrDefault(n => new CultureInfo(n).TwoLetterISOLanguageName == language);
            return bestMatch ?? Names[0];
        }
        catch (CultureNotFoundException)
        {
            return Names[0];
        }
    }
}
