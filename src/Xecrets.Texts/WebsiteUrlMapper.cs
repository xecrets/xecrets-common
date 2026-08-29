#region Copyright and License

/*
 * Xecrets Texts - Copyright © 2022-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Texts
 *
 * Xecrets Texts is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 */

#endregion Copyright and License

namespace Xecrets.Texts;

/// <summary>
/// Maps first-party Xecrets web-site URLs to their test-site equivalent.
/// </summary>
internal static class WebsiteUrlMapper
{
    private const string ProductionSiteUrl = "https://www.axantum.com";
    private const string TestSiteUrl = "https://test.axantum.com";

    /// <summary>
    /// Maps a production Axantum URL to the hosted test site when requested.
    /// </summary>
    /// <param name="url">The URL to map.</param>
    /// <param name="useTestSite">Whether the hosted test site should be used.</param>
    /// <returns>The original URL unless it is a production Axantum URL and <paramref name="useTestSite"/> is true.</returns>
    internal static string ToSite(string url, bool useTestSite) =>
        useTestSite ? ToSite(url, TestSiteUrl) : url;

    internal static string ToSite(string url, string siteUrl)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? source) ||
            source.Scheme != Uri.UriSchemeHttps ||
            !string.Equals(source.Host, "www.axantum.com", StringComparison.OrdinalIgnoreCase) ||
            !source.IsDefaultPort ||
            !url.StartsWith(ProductionSiteUrl, StringComparison.OrdinalIgnoreCase) ||
            (url.Length > ProductionSiteUrl.Length && url[ProductionSiteUrl.Length] is not '/' and not '?' and not '#'))
        {
            return url;
        }

        return siteUrl + url[ProductionSiteUrl.Length..];
    }
}
