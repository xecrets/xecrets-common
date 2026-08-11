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
/// Represents the top-level persisted document for an installation: the application-wide settings
/// plus the collection of local profiles configured on this device.
/// </summary>
public sealed class ApplicationData
{
    /// <summary>
    /// The highest <see cref="Version"/> of this schema supported by this build. Persisted files
    /// written before this field existed have no <c>version</c> property and are treated as this
    /// version, since <see cref="Version"/> keeps its default value when deserialization finds no
    /// matching JSON property to overwrite it with.
    /// </summary>
    public static int SupportedVersion => 1;

    /// <summary>
    /// Gets or sets the schema version of this document, so that a future incompatible change
    /// has a way to detect old files and migrate them.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; } = SupportedVersion;

    /// <summary>
    /// Gets or sets the application-wide settings that apply across all local profiles.
    /// </summary>
    [JsonPropertyName("applicationSettings")]
    public ApplicationSettings ApplicationSettings { get; set; } = new();

    /// <summary>
    /// Gets or sets the local profiles configured on this device.
    /// </summary>
    [JsonPropertyName("users")]
    public List<LocalProfileData> Users { get; set; } = [];
}
