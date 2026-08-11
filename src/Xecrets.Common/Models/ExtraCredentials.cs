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
/// Represents extra credentials remembered on behalf of a user, such as previously used passwords.
/// </summary>
public sealed class ExtraCredentials
{
    /// <summary>
    /// The highest <see cref="Version"/> of this schema supported by this build. Persisted files
    /// written before this field existed have no <c>version</c> property and are treated as this
    /// version, since <see cref="Version"/> keeps its default value when deserialization finds no
    /// matching JSON property to overwrite it with.
    /// </summary>
    public static int SupportedVersion => 1;

    /// <summary>
    /// Gets or sets the schema version of this file, so that a future incompatible change has a
    /// way to detect old files and migrate them.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; } = SupportedVersion;

    /// <summary>
    /// Gets or sets the UTC timestamp of the last time these credentials were written.
    /// </summary>
    [JsonPropertyName("lastWriteUtc")]
    public DateTime LastWriteUtc { get; set; }

    /// <summary>
    /// Gets or sets the passwords previously used by the user, along with their usage counts.
    /// </summary>
    [JsonPropertyName("passwords")]
    public List<PasswordUsage> Passwords { get; set; } = [];

    /// <summary>
    /// Gets or sets the last password used when sharing a file.
    /// </summary>
    [JsonPropertyName("lastSharePassword")]
    public string LastSharePassword { get; set; } = string.Empty;
}
