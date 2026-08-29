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
/// Represents the application-wide settings that apply across all users on this installation.
/// </summary>
public sealed class ApplicationSettings
{
    /// <summary>
    /// The highest <see cref="Version"/> of this schema supported by this build. Persisted files
    /// written before this field existed have no <c>version</c> property and are treated as this
    /// version, since <see cref="Version"/> keeps its default value when deserialization finds no
    /// matching JSON property to overwrite it with.
    /// </summary>
    public static int SupportedVersion => 1;

    /// <summary>
    /// Gets or sets the schema version of this settings file, so that a future incompatible change
    /// has a way to detect old files and migrate them.
    /// </summary>
    [JsonPropertyName("version")]
    public int Version { get; set; } = SupportedVersion;

    /// <summary>
    /// Gets or sets the UTC timestamp of the last time these settings were written.
    /// </summary>
    [JsonPropertyName("lastWriteUtc")]
    public DateTime LastWriteUtc { get; set; }

    /// <summary>
    /// Gets or sets the global UI scale factor applied on top of the platform's own scaling.
    /// </summary>
    [JsonPropertyName("globalScaleFactor")]
    public double GlobalScaleFactor { get; set; }

    /// <summary>
    /// Gets or sets the next local, installation-unique, identifier to assign to a new user.
    /// </summary>
    [JsonPropertyName("nextLocalUserId")]
    public int NextLocalUserId { get; set; } = 1;

    /// <summary>
    /// Gets or sets the UTC timestamp of the last time an update check was performed, or
    /// <see langword="null"/> if no check has ever been performed.
    /// </summary>
    [JsonPropertyName("lastUpdateCheckUtc")]
    public DateTime? LastUpdateCheckUtc { get; set; }

    /// <summary>
    /// Gets or sets the highest version for which the release notes have already been shown.
    /// </summary>
    [JsonPropertyName("lastReleaseNotesSeenVersion")]
    public Version LastReleaseNotesSeenVersion { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// Gets or sets the most recent application version known to have been run.
    /// </summary>
    [JsonPropertyName("mostRecentVersion")]
    public Version MostRecentVersion { get; set; } = new(1, 0, 0, 0);

    /// <summary>
    /// Gets or sets the key identifying the last CLI version mismatch notice that was shown to the user.
    /// </summary>
    [JsonPropertyName("lastCliVersionMismatchSeenKey")]
    public string LastCliVersionMismatchSeenKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the culture used for the application's user interface.
    /// </summary>
    [JsonPropertyName("culture")]
    public string Culture { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether premium features should be hidden from the user interface.
    /// </summary>
    [JsonPropertyName("hidePremium")]
    public bool? HidePremium { get; set; }

    /// <summary>
    /// Gets or sets the name of the visual theme used by the application.
    /// </summary>
    [JsonPropertyName("theme")]
    public string Theme { get; set; } = "Default";

    /// <summary>
    /// Gets or sets the number of minutes of inactivity after which the application locks itself.
    /// </summary>
    [JsonPropertyName("inactivityTimeoutMinutes")]
    public int InactivityTimeout { get; set; }
}
