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
using System.Text.Json.Serialization;

namespace Xecrets.Common.Models;

/// <summary>
/// Converts an enum to and from JSON as <see cref="JsonStringEnumConverter{TEnum}"/> does, except that a name not known
/// is read as the default value of the enum.
/// </summary>
/// <typeparam name="TEnum">The type of the enum.</typeparam>
public sealed class DefaultingStringEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    private readonly JsonStringEnumConverter<TEnum> _factory = new();

    /// <summary>
    /// Reads the value as <see cref="JsonStringEnumConverter{TEnum}"/> does, or the default value for a name not known.
    /// </summary>
    /// <param name="reader">The reader positioned at the value to convert.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The serializer options in use.</param>
    /// <returns>The value read.</returns>
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonConverter<TEnum> converter = CreateConverter(options);
        try
        {
            return converter.Read(ref reader, typeToConvert, options);
        }
        catch (JsonException)
        {
            return default;
        }
    }

    /// <summary>
    /// Writes the value as <see cref="JsonStringEnumConverter{TEnum}"/> does.
    /// </summary>
    /// <param name="writer">The writer to write the JSON to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options in use.</param>
    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options) =>
        CreateConverter(options).Write(writer, value, options);

    private JsonConverter<TEnum> CreateConverter(JsonSerializerOptions options) =>
        (JsonConverter<TEnum>)_factory.CreateConverter(typeof(TEnum), options)!;
}
