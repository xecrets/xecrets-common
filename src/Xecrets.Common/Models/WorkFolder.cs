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
 * The source repository can be found at https://github.com/xecrets/xecrets-texts please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Text.Json.Serialization;

namespace Xecrets.Common.Models;

/// <summary>
/// Represents one folder a user has granted the app access to, for repeated encrypt/decrypt operations.
/// </summary>
/// <param name="Id">The platform-specific location identifier (a content URI, a bookmark string, or a
/// folder path, depending on platform).</param>
/// <param name="DisplayName">The persisted, user-facing name. The user may rename this independently of
/// the folder's name on disk.</param>
/// <param name="GrantId">The platform access-grant token or permission id for the folder. Defaults to
/// empty when a platform cannot yet supply one at construction time.</param>
public sealed record WorkFolder(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("grantId")] string GrantId = "")
{
    /// <summary>
    /// The name to show in a list of folders, disambiguated with as much of the path as it takes when
    /// several folders share a display name. It is derived, so it is never persisted.
    /// </summary>
    [JsonIgnore]
    public string ListDisplayName { get; init; } = DisplayName;
}
