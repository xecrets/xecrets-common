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

using System.Text.Json;

namespace Xecrets.Common.Implementation;

/// <summary>
/// Serializes Common model values and reads and writes them as JSON files.
/// </summary>
public static class JsonFile
{
    /// <summary>
    /// Loads a value, returning a default instance when the file does not exist or contains invalid JSON.
    /// </summary>
    /// <typeparam name="T">The type of value to load.</typeparam>
    /// <param name="path">The path of the JSON file.</param>
    /// <param name="caught">Receives an exception caught while deserializing the file.</param>
    /// <returns>The loaded value, or a default instance.</returns>
    public static T Load<T>(string path, Action<Exception> caught) where T : class, new() =>
        File.Exists(path) ? Deserialize<T>(File.ReadAllBytes(path), caught) : new T();

    /// <summary>
    /// Loads a value asynchronously, returning a default instance when the file does not exist or contains invalid JSON.
    /// </summary>
    /// <typeparam name="T">The type of value to load.</typeparam>
    /// <param name="path">The path of the JSON file.</param>
    /// <param name="caught">Receives an exception caught while deserializing the file.</param>
    /// <returns>The loaded value, or a default instance.</returns>
    public static async Task<T> LoadAsync<T>(string path, Action<Exception> caught) where T : class, new() =>
        File.Exists(path) ? Deserialize<T>(await File.ReadAllBytesAsync(path), caught) : new T();

    /// <summary>
    /// Serializes a value of a type defined in Xecrets Common.
    /// </summary>
    public static string Serialize<T>(T value) =>
        JsonSerializer.Serialize(value, typeof(T), CommonJsonContext.Relaxed);

    /// <summary>
    /// Serializes a value of a type defined in Xecrets Common as UTF-8 JSON.
    /// </summary>
    public static byte[] SerializeToUtf8Bytes<T>(T value) =>
        JsonSerializer.SerializeToUtf8Bytes(value, typeof(T), CommonJsonContext.Relaxed);

    /// <summary>
    /// Deserializes a value of a type defined in Xecrets Common from JSON.
    /// </summary>
    public static T Deserialize<T>(string json, Action<Exception> caught) where T : class, new()
    {
        try
        {
            return JsonSerializer.Deserialize(json, typeof(T), CommonJsonContext.Relaxed) as T ?? new T();
        }
        catch (JsonException exception)
        {
            caught(exception);
            return new T();
        }
    }

    /// <summary>
    /// Deserializes a value of a type defined in Xecrets Common from UTF-8 JSON.
    /// </summary>
    public static T Deserialize<T>(ReadOnlySpan<byte> utf8Json, Action<Exception> caught) where T : class, new()
    {
        try
        {
            return JsonSerializer.Deserialize(utf8Json, typeof(T), CommonJsonContext.Relaxed) as T ?? new T();
        }
        catch (JsonException exception)
        {
            caught(exception);
            return new T();
        }
    }

    /// <summary>
    /// Writes a value asynchronously using the Common relaxed JSON format.
    /// </summary>
    /// <typeparam name="T">The type of value to write.</typeparam>
    /// <param name="path">The path of the JSON file.</param>
    /// <param name="value">The value to write.</param>
    /// <returns>The serialized JSON.</returns>
    public static async Task<string> WriteAsync<T>(string path, T value)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        string serialized = Serialize(value);
        await File.WriteAllTextAsync(path, serialized);
        return serialized;
    }
}
