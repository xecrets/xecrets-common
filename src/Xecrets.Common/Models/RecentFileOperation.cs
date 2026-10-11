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
/// The operation that put a file on the list of recently used files.
/// </summary>
public enum RecentFileOperation
{
    /// <summary>
    /// The operation is not known, such as when recorded by a later version. The default value.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// The file was encrypted or decrypted where it is stored, or added to the list by the user.
    /// </summary>
    InPlace,

    /// <summary>
    /// The encrypted file was decrypted temporarily and viewed.
    /// </summary>
    View,

    /// <summary>
    /// The encrypted file was decrypted temporarily and edited.
    /// </summary>
    Edit,

    /// <summary>
    /// A decrypted copy of the encrypted file was opened in another app.
    /// </summary>
    DecryptCopyOpenIn,

    /// <summary>
    /// A decrypted copy of the encrypted file was saved.
    /// </summary>
    DecryptCopySaveAs,

    /// <summary>
    /// A decrypted copy of the encrypted file was sent to another app.
    /// </summary>
    DecryptCopySendTo,

    /// <summary>
    /// An encrypted copy of the file was saved.
    /// </summary>
    EncryptCopySaveAs,

    /// <summary>
    /// An encrypted copy of the file was sent to another app.
    /// </summary>
    EncryptCopySendTo,

    /// <summary>
    /// A copy of the file encrypted with a password was saved.
    /// </summary>
    EncryptWithSaveAs,

    /// <summary>
    /// A copy of the file encrypted with a password was sent to another app.
    /// </summary>
    EncryptWithSendTo,
}
