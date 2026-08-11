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

namespace Xecrets.Common.Abstractions;

/// <summary>
/// Provides encryption and decryption of sensitive data at rest, independent of any particular
/// storage or platform mechanism.
/// </summary>
public interface IXecretsProtection
{
    /// <summary>
    /// Protects the given cleartext, producing a form suitable for storage.
    /// </summary>
    /// <param name="cleartext">The data to protect.</param>
    /// <param name="originalFilename">The original filename of the data being protected.</param>
    /// <returns>The protected bytes.</returns>
    Task<byte[]> ProtectAsync(byte[] cleartext, string originalFilename);

    /// <summary>
    /// Reverses <see cref="ProtectAsync(byte[], string)"/>, recovering the original cleartext.
    /// </summary>
    /// <param name="protectedBytes">The previously protected data.</param>
    /// <returns>The recovered cleartext bytes.</returns>
    Task<byte[]> UnprotectAsync(byte[] protectedBytes);
}

