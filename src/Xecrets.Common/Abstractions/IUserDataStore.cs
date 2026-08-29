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

using Xecrets.Common.Models;

namespace Xecrets.Common.Abstractions;

/// <summary>
/// Provides access to the persisted data belonging to a single user.
/// </summary>
public interface IUserDataStore
{
    /// <summary>
    /// Gets the identifier of the user this store belongs to.
    /// </summary>
    UserId Id { get; }

    /// <summary>
    /// Loads the user's settings for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="UserSettings"/>.</returns>
    Task<IPersistentData<UserSettings>> LoadSettingsAsync();

    /// <summary>
    /// Loads the user's extra credentials for reading and editing.
    /// </summary>
    /// <param name="protection">The protection used to unprotect and re-protect the credentials.</param>
    /// <returns>An editable view of the user's <see cref="ExtraCredentials"/>.</returns>
    Task<IPersistentData<ExtraCredentials>> LoadExtraCredentialsAsync(IXecretsProtection protection);

    /// <summary>
    /// Loads the user's private keys for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="PrivateKeyData"/>.</returns>
    Task<IPersistentData<PrivateKeyData>> LoadPrivateKeysAsync();

    /// <summary>
    /// Loads the user's currently open files for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="OpenFiles"/>.</returns>
    Task<IPersistentData<OpenFiles>> LoadOpenFilesAsync();

    /// <summary>
    /// Loads the user's recent files for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="RecentFiles"/>.</returns>
    Task<IPersistentData<RecentFiles>> LoadRecentFilesAsync();

    /// <summary>
    /// Loads the user's license data for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="LicenseData"/>.</returns>
    Task<IPersistentData<LicenseData>> LoadLicenseAsync();

    /// <summary>
    /// Loads the user's work folders for reading and editing.
    /// </summary>
    /// <returns>An editable view of the user's <see cref="WorkFolders"/>.</returns>
    Task<IPersistentData<WorkFolders>> LoadWorkFoldersAsync();

    /// <summary>
    /// Gets the sign-in keys currently registered for the user.
    /// </summary>
    /// <returns>The user's sign-in keys.</returns>
    Task<IReadOnlyList<SignInKey>> GetSignInKeysAsync();

    /// <summary>
    /// Replaces a sign-in key with a new one, updating the user's identity information.
    /// </summary>
    /// <param name="oldKey">The sign-in key to replace.</param>
    /// <param name="replacementKey">The new sign-in key.</param>
    /// <param name="email">The email address to associate with the user.</param>
    /// <param name="baseDisplayName">The base display name to associate with the user.</param>
    /// <returns>A task that completes when the sign-in key has been replaced.</returns>
    Task ReplaceSignInKeyAsync(SignInKey oldKey, SignInKey replacementKey, string email, string baseDisplayName);
}

