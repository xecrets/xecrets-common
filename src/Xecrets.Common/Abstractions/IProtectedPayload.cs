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

namespace Xecrets.Common.Abstractions;

/// <summary>
/// Unprotects, deserializes, serializes and protects user-data payloads.
/// </summary>
public interface IProtectedPayload
{
    /// <summary>Unprotects a protected object, returning defaults for missing or malformed payloads.</summary>
    /// <param name="protectedBytes">The protected payload bytes.</param>
    /// <param name="protection">The protection implementation to use.</param>
    /// <param name="diagnostic">Optional diagnostic callback for exceptions.</param>
    Task<T> Unprotect<T>(byte[]? protectedBytes, IXecretsProtection protection, Action<Exception>? diagnostic = null) where T : new();

    /// <summary>Protects a serialized object for transport or storage.</summary>
    /// <param name="value">The object to protect.</param>
    /// <param name="protection">The protection implementation to use.</param>
    Task<byte[]> Protect<T>(T value, IXecretsProtection protection);
}
