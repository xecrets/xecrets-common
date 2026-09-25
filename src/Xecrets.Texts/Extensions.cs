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
using System.Text.RegularExpressions;

using JetBrains.Annotations;

using Microsoft.Extensions.Localization;

namespace Xecrets.Texts;

/// <summary>
/// Extensions and helpers for URL rewriting, string formatting and file name manipulation used across Xecrets assemblies.
/// </summary>
public static partial class Extensions
{
    /// <summary>
    /// The official extension used for encrypted files, including the leading dot.
    /// </summary>
    [PublicAPI]
    public static string EncryptedExtension => ".axx";

    /// <summary>
    /// Select the files that appear to be encrypted, according to their extension.
    /// </summary>
    /// <param name="files">File names to filter</param>
    /// <returns>An array of the files that match the pattern for encrypted files.</returns>
    [PublicAPI]
    public static string[] Encrypted(this IEnumerable<string> files)
    {
        return [.. files.Where(IsEncrypted)];
    }

    /// <summary>
    /// Select the files that appear not to be encrypted, according to their extension.
    /// </summary>
    /// <param name="files">File names to filter</param>
    /// <returns>An enumeration of the files that do not match the pattern for encrypted files.</returns>
    [PublicAPI]
    public static IEnumerable<string> NotEncrypted(this IEnumerable<string> files)
    {
        return files.Where(f => !IsEncrypted(f));
    }

    /// <summary>
    /// Add the extension for an encrypted file
    /// </summary>
    /// <param name="file">A file name, presumably without extension</param>
    /// <returns>The file parameter with the extension for encrypted files concatenated.</returns>
    [PublicAPI]
    public static string AddEncryptedExtension(this string file)
    {
        return file + EncryptedExtension;
    }

    /// <summary>
    /// Build an encrypted file name from the original file name, i.e. according to the pattern: filename.ext =>
    /// filename-ext.axx
    /// </summary>
    /// <param name="destinationFileFullFolder">The full path to an optional destination folder. Set to empty string if same as source.</param>
    /// <param name="file">A file name, presumably without extension</param>
    /// <returns>The suggested name for it when encrypted.</returns>
    [PublicAPI]
    public static string ToEncryptedName(this string file, string destinationFileFullFolder)
    {
        string extensionWithDot = Path.GetExtension(file);
        string pathWithoutExtensionAndDot = file.Substring(0, file.Length - extensionWithDot.Length);
        string trailingNumberInParenthesis = string.Empty;
        string pathWithoutExtensionAndDotAndTrailingNumberInParenthesis = TrailingNumberInParenthesis().Replace(
            pathWithoutExtensionAndDot,
            (m) =>
            {
                trailingNumberInParenthesis = m.Value;
                return string.Empty;
            });
        string encryptedFullName = extensionWithDot.Length > 1
            ? $"{pathWithoutExtensionAndDotAndTrailingNumberInParenthesis}-{extensionWithDot.Substring(1)}{trailingNumberInParenthesis}{EncryptedExtension}"
            : $"{pathWithoutExtensionAndDotAndTrailingNumberInParenthesis}{trailingNumberInParenthesis}{EncryptedExtension}";

        if (destinationFileFullFolder.Length > 0)
        {
            encryptedFullName = Path.Combine(destinationFileFullFolder, Path.GetFileName(encryptedFullName));
        }

        return encryptedFullName;
    }

    /// <summary>
    /// A predicate determining of the name of a file has the suggested encrypted extension, i.e. ".axx".
    /// </summary>
    /// <param name="file">A file name, presumably without extension</param>
    /// <returns><see langword="true"/> if the name ends with the encrypted extension.</returns>
    [PublicAPI]
    public static bool IsEncrypted(this string file)
    {
        return string.Compare(Path.GetExtension(file), EncryptedExtension, StringComparison.OrdinalIgnoreCase) == 0;
    }

    [GeneratedRegex(@" \([\d]+\)$")]
    private static partial Regex TrailingNumberInParenthesis();

    /// <summary>
    /// Shortens a file path to at most <paramref name="maxLength"/> characters by replacing leading directory
    /// segments with an ellipsis, preserving the root and the file name as far as possible.
    /// </summary>
    /// <param name="path">The path to shorten.</param>
    /// <param name="maxLength">The maximum length of the result.</param>
    /// <returns>The path, shortened with an ellipsis if it is longer than <paramref name="maxLength"/>.</returns>
    [PublicAPI]
    public static string PathEllipsis(this string path, int maxLength)
    {
        return
            Ellipsis(Ellipsis(path, maxLength, EllipsisFormat.Path | EllipsisFormat.Start), maxLength,
                EllipsisFormat.Start);
    }

    /// <summary>
    /// Specifies ellipsis format and alignment.
    /// </summary>
    [Flags]
    // ReSharper disable once UnusedMember.Local
    private enum EllipsisFormat
    {
        /// <summary>
        /// Text is not modified.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        None = 0,

        /// <summary>
        /// Text is trimmed at the end of the string. An ellipsis (…) is drawn in place of the remaining text.
        /// </summary>
        End = 1,

        /// <summary>
        /// Text is trimmed at the beginning of the string. An ellipsis (…) is drawn in place of the remaining text. 
        /// </summary>
        Start = 2,

        /// <summary>
        /// Text is trimmed in the middle of the string. An ellipsis (…) is drawn in place of the remaining text.
        /// </summary>
        Middle = End | Start,

        /// <summary>
        /// Preserve as much as possible of the drive and filename information. Must be combined with alignment information.
        /// </summary>
        Path = 4,

        /// <summary>
        /// Text is trimmed at a word boundary. Must be combined with alignment information.
        /// </summary>
        Word = 8
    }

    private const string EllipsisChars = "…";

    private static readonly Regex PrevWord = PrevWordRegex();

    private static readonly Regex NextWord = NextWordRegex();

    /// <summary>
    /// Truncates a text string to fit within a given control width by replacing trimmed text with ellipses. 
    /// </summary>
    /// <param name="text">String to be trimmed.</param>
    /// <param name="maxLength">Maximum length of trimmed string.</param>
    /// <param name="options">Format and alignment of ellipsis.</param>
    /// <returns>This function returns text trimmed to the specified length.</returns>
    /// <remarks>Based on https://www.codeproject.com/Articles/37503/Auto-Ellipsis</remarks>
    private static string Ellipsis(string text, int maxLength, EllipsisFormat options)
    {
        if (!options.HasFlag(EllipsisFormat.Start) && !options.HasFlag(EllipsisFormat.End))
        {
            return text;
        }

        if (text.Length <= maxLength)
        {
            return text;
        }

        string pre = string.Empty;
        string mid = text;
        string post = string.Empty;

        if (options.HasFlag(EllipsisFormat.Path))
        {
            // Split into <drive><directory><filename>
            pre = Path.GetPathRoot(text) ?? string.Empty;
            mid = Path.GetDirectoryName(text)?.Substring(pre.Length) ?? string.Empty;
            post = Path.GetFileName(text);
        }

        int len = 0;
        int seg = mid.Length;
        string fit = string.Empty;

        // find the longest string that fits into 
        // the control boundaries using bisection method
        while (seg > 1)
        {
            seg -= seg / 2;

            int left = len + seg;
            int right = mid.Length;

            if (left > right)
            {
                continue;
            }

            if (options.HasFlag(EllipsisFormat.Middle))
            {
                right -= left / 2;
                left -= left / 2;
            }
            else if (options.HasFlag(EllipsisFormat.Start))
            {
                right -= left;
                left = 0;
            }

            // trim at a word boundary using regular expressions
            if (options.HasFlag(EllipsisFormat.Word))
            {
                if (options.HasFlag(EllipsisFormat.End))
                {
                    left -= PrevWord.Match(mid, 0, left).Length;
                }

                if (options.HasFlag(EllipsisFormat.Start))
                {
                    right += NextWord.Match(mid, right).Length;
                }
            }

            // build and measure a candidate string with ellipsis
            string tst = string.Concat(mid.AsSpan(0, left), EllipsisChars, mid.AsSpan(right));

            // restore path with <drive> and <filename>
            if (options.HasFlag(EllipsisFormat.Path))
            {
                tst = Path.Combine(Path.Combine(pre, tst), post);
            }

            // candidate string fits into control boundaries, try a longer string
            // stop when seg <= 1
            if (tst.Length <= maxLength)
            {
                len += seg;
                fit = tst;
            }
        }

        if (len == 0) // string can't fit into control
        {
            // "path" mode is off, just return ellipsis characters
            if (!options.HasFlag(EllipsisFormat.Path))
            {
                return EllipsisChars;
            }

            // <drive> and <directory> are empty, return <filename>
            if (pre.Length == 0 && mid.Length == 0)
            {
                return post;
            }

            // measure "C:\…\filename.ext"
            fit = Path.Combine(Path.Combine(pre, EllipsisChars), post);

            // if still does not fit, then return "…\filename.ext"
            if (fit.Length > maxLength)
            {
                fit = Path.Combine(EllipsisChars, post);
            }
        }

        return fit;
    }

    [GeneratedRegex("\\W*\\w*$")]
    private static partial Regex PrevWordRegex();

    [GeneratedRegex("\\w*\\W*")]
    private static partial Regex NextWordRegex();

    /// <summary>
    /// Formats a string using <see cref="CultureInfo.CurrentCulture"/>.
    /// </summary>
    /// <param name="args">Format arguments passed to <see cref="string.Format(IFormatProvider, string, object[])"/>.</param>
    /// <param name="format">The raw localized menu string.</param>
    /// <returns>The formatted string.</returns>
    [PublicAPI]
    public static string FormatUi(this string format, params object[] args) =>
        string.Format(CultureInfo.CurrentCulture, format, args);

    internal static string FormatUi(this LocalizedString format, params object[] args) =>
        format.Value.FormatUi(args);

    /// <summary>
    /// Formats a pipe-delimited plural string by selecting the segment matching <paramref name="n">,
    /// typically 0, 1 or 2. If n > number of segments, the last one is chosen.</paramref>/>.
    /// </summary>
    /// <param name="n">The count that selects the plural form. Negative values return an empty string.</param>
    /// <param name="args">Additional format arguments.</param>
    /// <param name="format">The raw localized menu string.</param>
    /// <returns>The formatted plural string, or <see cref="string.Empty"/> when <paramref name="n"/> is negative.</returns>
    [PublicAPI]
    public static string PluralFormatUi(this string format, int n, params object[] args)
    {
        if (n < 0)
        {
            return string.Empty;
        }

        string[] formats = format.Split('|');
        return string.Format(CultureInfo.CurrentCulture, formats[n < formats.Length ? n : formats.Length - 1], n,
            args);
    }

    internal static string PluralFormatUi(this LocalizedString format, int n, params object[] args) =>
        format.Value.PluralFormatUi(n, args);

    /// <summary>
    /// Strips accelerator underscores from a localized menu string, keeping any ellipsis. Use for text that is
    /// displayed outside of a menu, but still triggers a dialog or a further selection, such as a tool bar button.
    /// </summary>
    /// <param name="format">The raw localized menu string.</param>
    /// <returns>The text without accelerator underscores.</returns>
    /// <remarks>
    /// Chain with <see cref="StripEllipsis(string)"/> when the text is used as a title, a heading or for an action
    /// that is carried out immediately, i.e. where nothing further follows.
    /// </remarks>
    [PublicAPI]
    public static string StripAccelerator(this string format) => format.Replace("_", string.Empty);

    internal static string StripAccelerator(this LocalizedString format) => format.Value.StripAccelerator();

    /// <summary>
    /// Strips ellipsis, both the single character and the three period variant, from a text. Use for text that is
    /// used as a title or a heading, or for an action that is taken immediately, since an ellipsis indicates that a
    /// dialog or a further selection follows.
    /// </summary>
    /// <param name="text">The text to strip the ellipsis from, typically the result of <see
    /// cref="StripAccelerator(string)"/>.</param>
    /// <returns>The text without any ellipsis.</returns>
    [PublicAPI]
    public static string StripEllipsis(this string text) =>
        text.Replace("...", string.Empty).Replace("…", string.Empty);

    /// <summary>
    /// Rewrites a production URL to point to a local dev server or test server when running in debug mode.
    /// In release builds the URL is returned unchanged.
    /// </summary>
    /// <param name="url">The URL, must be rooted at <c>https://www.axantum.com</c>.</param>
    /// <returns>The original URL in release builds, or a rewritten URL in debug builds.</returns>
    internal static string ToSite(this string url)
    {
        if (Is.Debug)
        {
            string testServer = (Platform.IsWindows || Platform.IsLinux || Platform.IsMacOS) &&
                                DebugDevServer.IsDevServerRunning
                ? "http://localhost:3000"
                : "https://test.axantum.com";
            return WebsiteUrlMapper.ToSite(url, testServer);
        }

        return url;
    }

    /// <summary>
    /// Rewrites a production URL to point to either the production or test site.
    /// </summary>
    /// <param name="url">The URL, must be rooted at <c>https://www.axantum.com</c>.</param>
    /// <param name="useTestSite">If <see langword="true"/>, rewrites to the test site; otherwise uses the production site.</param>
    /// <returns>The rewritten URL.</returns>
    [PublicAPI]
    public static string ToSite(this string url, bool useTestSite)
    {
        return WebsiteUrlMapper.ToSite(url, useTestSite);
    }

    /// <summary>
    /// Rewrites a production URL (see <see cref="ToSite(string)"/>) and appends a URL fragment.
    /// </summary>
    /// <param name="fragment">The fragment to append, e.g. <c>"#section"</c>.</param>
    /// <param name="url">The URL, must be rooted at <c>https://www.axantum.com</c>.</param>
    /// <returns>The rewritten URL with the fragment appended.</returns>
    internal static string ToSite(this string url, string fragment) => url.ToSite() + fragment;
}
