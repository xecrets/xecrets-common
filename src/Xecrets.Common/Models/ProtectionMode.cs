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

namespace Xecrets.Common.Models;

/// <summary>
/// Specifies how a YubiKey slot is used to protect an encrypted password.
/// </summary>
public enum ProtectionMode
{
    /// <summary>
    /// The protection mode has not been determined.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// The slot requires no user interaction to be used.
    /// </summary>
    Open = 1,

    /// <summary>
    /// The slot requires a touch, but not a PIN, to be used.
    /// </summary>
    Convenient = 2,

    /// <summary>
    /// The slot requires both a touch and a PIN to be used.
    /// </summary>
    Secure = 3,

    /// <summary>
    /// The slot has not yet been configured for use.
    /// </summary>
    Uninitialized = 4,
}
