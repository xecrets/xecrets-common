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
/// Represents a value that has been opened for editing and will be automatically
/// persisted if needed on disposal.
/// </summary>
/// <typeparam name="T">The type of the value being edited.</typeparam>
public interface IEditScope<T> : IAsyncDisposable
{
    /// <summary>
    /// Gets the current value.
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Persists the current <see cref="Value"/> to its underlying store.
    /// </summary>
    /// <param name="force">
    /// When <see langword="false"/>, the save is skipped if <see cref="Value"/> is unchanged from
    /// what was last loaded or saved. When <see langword="true"/>, saves unconditionally.
    /// </param>
    /// <returns>A task that completes when the value has been saved, or the save has been skipped.</returns>
    Task SaveAsync(bool force);
}
