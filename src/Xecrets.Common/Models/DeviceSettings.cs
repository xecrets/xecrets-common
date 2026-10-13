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
/// Represents the settings that only apply to the installation on this device, such as calibrated key-wrap iterations
/// and the folders and files the app has been granted access to. They are kept apart from other data, out of backups
/// and transfers, since they are not meaningful on another device or in another installation, and are never exported.
/// </summary>
public sealed class DeviceSettings
{
    /// <summary>
    /// Gets or sets the version of the device-specific settings. Settings of another version are discarded.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; }

    /// <summary>
    /// Gets or sets the random salt, as hex, used to hash the device identifier into <see cref="DeviceId"/>.
    /// </summary>
    [JsonPropertyName("deviceIdSalt")]
    public string DeviceIdSalt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the salted hash, as hex, of the identifier of the device the settings were written on, or empty if
    /// it was unknown.
    /// </summary>
    [JsonPropertyName("deviceId")]
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the settings values persisted on behalf of Xecrets.Core, keyed by the name Xecrets.Core uses for
    /// them.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, string> Values { get; set; } = [];

    /// <summary>
    /// Gets or sets the device-specific settings of each local profile, keyed by the local profile identifier.
    /// </summary>
    [JsonPropertyName("profiles")]
    public Dictionary<string, ProfileDeviceSettings> Profiles { get; set; } = [];
}
