#region Copyright and License

/*
 * Xecrets Common - Copyright © 2026-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Common
 *
 * Xecrets Common is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Common is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Common.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-common please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Text.Json.Serialization;

namespace Xecrets.Common.Models;

/// <summary>
/// Represents the user's preferences for the built-in text editor.
/// </summary>
public sealed class TextEditor
{
    /// <summary>
    /// Gets or sets a value indicating whether text files should always be opened in an external editor, instead of
    /// being edited in memory in the application.
    /// </summary>
    [JsonPropertyName("alwaysUseExternal")]
    public bool? AlwaysUseExternal { get; set; }

    /// <summary>
    /// Gets or sets the font size of the built-in text editor, or <see langword="null"/> to use the default.
    /// </summary>
    [JsonPropertyName("fontSize")]
    public double? FontSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the built-in text editor uses the regular proportional font of the
    /// device instead of a monospace font.
    /// </summary>
    [JsonPropertyName("proportionalFont")]
    public bool? ProportionalFont { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether line numbers are shown in the built-in text editor.
    /// </summary>
    [JsonPropertyName("showLineNumbers")]
    public bool? ShowLineNumbers { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether tabs, spaces and line endings are shown in the built-in text editor.
    /// </summary>
    [JsonPropertyName("showWhitespace")]
    public bool? ShowWhitespace { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether syntax highlighting is used in the built-in text editor, when available
    /// for the file type. The default is to highlight.
    /// </summary>
    [JsonPropertyName("syntaxHighlighting")]
    public bool? SyntaxHighlighting { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether long lines are wrapped in the built-in text editor.
    /// </summary>
    [JsonPropertyName("wordWrap")]
    public bool? WordWrap { get; set; }
}
