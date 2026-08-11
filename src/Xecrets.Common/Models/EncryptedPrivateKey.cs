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
/// Represents a single encrypted key pair belonging to a user, together with the metadata needed
/// to identify and manage it.
/// </summary>
public sealed class EncryptedPrivateKey
{
    /// <summary>
    /// Gets or sets the email address of the user this key pair belongs to.
    /// </summary>
    [JsonPropertyName("user")]
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when this key pair was created.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTime Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the thumbprint uniquely identifying this key pair.
    /// </summary>
    [JsonPropertyName("thumbprint")]
    public required string Thumbprint { get; set; }

    /// <summary>
    /// Gets or sets the encrypted key pair itself.
    /// </summary>
    [JsonPropertyName("keypair")]
    public required EncryptedPrivateKeyPair KeyPair { get; set; }

    /// <summary>
    /// Gets or sets whether the password protecting the private key is known.
    /// </summary>
    [JsonPropertyName("keypair_status")]
    public PrivateKeyPasswordStatus PasswordStatus { get; set; }
}
