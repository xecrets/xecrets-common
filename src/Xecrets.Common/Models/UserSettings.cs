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
/// Represents the settings and preferences specific to a single user.
/// </summary>
public sealed class UserSettings
{
    /// <summary>
    /// Gets or sets the globally unique identifier of this user profile.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString("N");

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
    /// Gets or sets the display name shown to the user for their own account.
    /// </summary>
    [JsonPropertyName("userDisplayName")]
    public string UserDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether newly used passwords should be remembered.
    /// </summary>
    [JsonPropertyName("saveAddedPasswords")]
    public bool? SaveAddedPasswords { get; set; }

    /// <summary>
    /// Gets or sets the local, installation-unique, identifier of the user.
    /// </summary>
    [JsonPropertyName("localUserId")]
    public int LocalUserId { get; set; }

    /// <summary>
    /// Gets or sets the YubiKey configuration used to protect the user's passwords.
    /// </summary>
    [JsonPropertyName("yubiKeyConfiguration")]
    public YubiKeyConfiguration YubiKeyConfiguration { get; set; } = new();

    /// <summary>
    /// Gets or sets the UTC timestamp of the last time the user was informed that their
    /// subscription had expired, or <see langword="null"/> if they have not been informed.
    /// </summary>
    [JsonPropertyName("expiredInformedUtc")]
    public DateTime? ExpiredInformedUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user has declined a trial offer.
    /// </summary>
    [JsonPropertyName("trialDeclined")]
    public bool? TrialDeclined { get; set; }

    /// <summary>
    /// Gets or sets the identifier of a notice the user has chosen not to see again.
    /// </summary>
    [JsonPropertyName("dontShowAgain")]
    public string? DontShowAgain { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the user first started the application.
    /// </summary>
    [JsonPropertyName("firstStartUtc")]
    public DateTime? FirstStartUtc { get; set; }

    /// <summary>
    /// Gets or sets the number of days after <see cref="FirstStartUtc"/> at which the user should
    /// next be prompted for a review.
    /// </summary>
    [JsonPropertyName("nextReviewFromFirstStart")]
    public int? NextReviewFromFirstStart { get; set; }
}
