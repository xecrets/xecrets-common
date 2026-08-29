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

using System.Text.Json;

using Xecrets.Common.Abstractions;

namespace Xecrets.Common.Implementation;

// Every T this is ever instantiated with is a Xecrets.Common.Models type registered on
// CommonJsonContext, serialized here only to detect whether Value changed since it was loaded or
// last saved - never to decide what actually gets persisted, that's up to 'persist'.
/// <summary>
/// An <see cref="IPersistentData{T}"/> holding an in-memory value together with the callback that
/// persists it. <see cref="BeginEdit"/> returns an <see cref="IEditScope{T}"/> that skips that
/// callback on an unforced save when the value has not changed since it was loaded or last saved.
/// </summary>
/// <typeparam name="T">The type of the value being held.</typeparam>
/// <param name="value">The initial value, as loaded from the underlying store.</param>
/// <param name="persist">The callback that persists a changed value to the underlying store, and returns a JSON
/// serialization of the value used for change-detection.</param>
public class PersistentData<T>(T value, Func<T, Task<string>> persist) : IPersistentData<T>
{
    private readonly Func<T, Task<string>> _persist = persist;

    private string _persisted = JsonSerializer.Serialize(value, typeof(T), CommonJsonContext.Relaxed);

    /// <inheritdoc/>
    public T Value { get; } = value;

    /// <inheritdoc/>
    public IEditScope<T> BeginEdit() => new EditScope(this);

    private sealed class EditScope(PersistentData<T> data) : IEditScope<T>
    {
        public T Value => data.Value;

        /// <inheritdoc/>
        public async Task SaveAsync(bool force)
        {
            string current = JsonSerializer.Serialize(Value, typeof(T), CommonJsonContext.Relaxed);
            if (!force && current == data._persisted)
            {
                return;
            }

            data._persisted = await data._persist(Value);
        }

        public async ValueTask DisposeAsync()
        {
            await SaveAsync(force: false);
        }
    }
}
