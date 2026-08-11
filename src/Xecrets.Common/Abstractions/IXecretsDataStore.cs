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

using Xecrets.Common.Models;

namespace Xecrets.Common.Abstractions;

/// <summary>
/// Provides top-level access to the application's persisted configuration and the data stores
/// of its individual users.
/// </summary>
public interface IXecretsDataStore
{
    /// <summary>
    /// Opens the application-wide settings for reading and editing.
    /// </summary>
    /// <returns>An editable view of the <see cref="ApplicationSettings"/>.</returns>
    Task<IPersistentData<ApplicationSettings>> OpenApplicationSettingsAsync();

    /// <summary>
    /// Opens the application-wide settings for reading and editing.
    /// </summary>
    /// <returns>An editable view of the <see cref="ApplicationSettings"/>.</returns>
    IPersistentData<ApplicationSettings> OpenApplicationSettings();

    /// <summary>
    /// Gets a summary of every user known to the application.
    /// </summary>
    /// <returns>The summaries of all users.</returns>
    Task<IReadOnlyList<UserSummary>> GetUsersAsync();

    /// <summary>
    /// Creates a new user and its associated data store.
    /// </summary>
    /// <param name="user">The data describing the new user.</param>
    /// <returns>The data store for the newly created user.</returns>
    Task<IUserDataStore> CreateUserAsync(NewUserData user);

    /// <summary>
    /// Opens the data store for an existing user.
    /// </summary>
    /// <param name="userId">The identifier of the user to open.</param>
    /// <returns>The data store for the specified user.</returns>
    Task<IUserDataStore> OpenUserAsync(UserId userId);

    /// <summary>
    /// Exports the application-wide configuration for backup or transfer.
    /// </summary>
    /// <returns>A package containing the exported application configuration.</returns>
    Task<ApplicationConfigurationPackage> ExportApplicationConfigurationAsync();

    /// <summary>
    /// Imports a previously exported application-wide configuration, replacing the current one.
    /// </summary>
    /// <param name="package">The configuration package to import.</param>
    /// <returns>A task that completes when the configuration has been imported.</returns>
    Task ImportApplicationConfigurationAsync(ApplicationConfigurationPackage package);

    /// <summary>
    /// Exports a user's data for backup or transfer.
    /// </summary>
    /// <param name="userId">The identifier of the user to export.</param>
    /// <param name="protection">The protection used to unprotect and re-protect the user's secrets.</param>
    /// <returns>A package containing the exported user data.</returns>
    Task<UserDataPackage> ExportUserAsync(UserId userId, IXecretsProtection protection);

    /// <summary>
    /// Imports a previously exported user, creating or overwriting its data store.
    /// </summary>
    /// <param name="package">The user data package to import.</param>
    /// <param name="protection">The protection used to unprotect and re-protect the user's secrets.</param>
    /// <returns>The data store for the imported user.</returns>
    Task<IUserDataStore> ImportUserAsync(UserDataPackage package, IXecretsProtection protection);

    /// <summary>
    /// Resets the application-wide configuration to its default values.
    /// </summary>
    /// <returns>A task that completes when the configuration has been reset.</returns>
    Task ResetApplicationConfigurationAsync();

    /// <summary>
    /// Resets a single user's data to its default values.
    /// </summary>
    /// <param name="userId">The identifier of the user to reset.</param>
    /// <returns>A task that completes when the user has been reset.</returns>
    Task ResetUserAsync(UserId userId);

    /// <summary>
    /// Resets the entire data store, removing all users and application configuration.
    /// </summary>
    /// <returns>A task that completes when the store has been reset.</returns>
    Task ResetStoreAsync();
}

