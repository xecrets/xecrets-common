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
/// Represents one local profile persisted within an <see cref="ApplicationData"/> document.
/// </summary>
public sealed class LocalProfileData
{
    /// <summary>
    /// Gets or sets the installation-unique identifier of this local profile.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address associated with this local profile.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the display name this local profile was created with, before disambiguation.
    /// </summary>
    [JsonPropertyName("baseDisplayName")]
    public string BaseDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the order in which this local profile was created, relative to others.
    /// </summary>
    [JsonPropertyName("creationOrder")]
    public long CreationOrder { get; set; }

    /// <summary>
    /// Gets or sets the per-profile settings.
    /// </summary>
    [JsonPropertyName("settings")]
    public UserSettings Settings { get; set; } = new();

    /// <summary>
    /// Gets or sets the sign-in keys registered for this local profile.
    /// </summary>
    [JsonPropertyName("signInKeys")]
    public List<SignInKey> SignInKeys { get; set; } = [];

    /// <summary>
    /// Gets or sets the encrypted private keys associated with this local profile.
    /// </summary>
    [JsonPropertyName("privateKeys")]
    public PrivateKeyData PrivateKeys { get; set; } = new();

    /// <summary>
    /// Gets or sets the license associated with this local profile.
    /// </summary>
    [JsonPropertyName("license")]
    public LicenseData License { get; set; } = new(string.Empty);

    /// <summary>
    /// Gets or sets the folders this local profile has granted the app repeated access to.
    /// </summary>
    [JsonPropertyName("workFolders")]
    public WorkFolders WorkFolders { get; set; } = new();

    /// <summary>
    /// Gets or sets protected, opaque payloads keyed by name, such as extra credentials.
    /// </summary>
    [JsonPropertyName("protectedPayloads")]
    public Dictionary<string, byte[]> ProtectedPayloads { get; set; } = [];
}
