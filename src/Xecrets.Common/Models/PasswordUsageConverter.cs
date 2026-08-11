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
using System.Text.Json.Serialization;

namespace Xecrets.Common.Models;

/// <summary>
/// Converts <see cref="PasswordUsage"/> to and from JSON, accepting both the current object
/// format and the legacy plain-string format for backward compatibility on read.
/// </summary>
public sealed class PasswordUsageConverter : JsonConverter<PasswordUsage>
{
    /// <summary>
    /// Reads a <see cref="PasswordUsage"/> from JSON, accepting either the current
    /// <c>{"password":...,"usageCount":...}</c> object format or a legacy plain JSON string,
    /// which is read as the password with a usage count of zero.
    /// </summary>
    /// <param name="reader">The reader positioned at the value to convert.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The serializer options in use.</param>
    /// <returns>The deserialized password usage.</returns>
    public override PasswordUsage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new PasswordUsage { Password = reader.GetString() ?? string.Empty };
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement root = document.RootElement;
        return new PasswordUsage
        {
            Password = root.TryGetProperty("password", out JsonElement password)
                ? password.GetString() ?? string.Empty
                : string.Empty,
            UsageCount = root.TryGetProperty("usageCount", out JsonElement usageCount) ? usageCount.GetInt32() : 0,
        };
    }

    /// <summary>
    /// Writes a <see cref="PasswordUsage"/> as JSON, When the
    /// <c>usageCount</c> property is zero, the old format is used.
    /// </summary>
    /// <param name="writer">The writer to write the JSON to.</param>
    /// <param name="value">The password usage to write.</param>
    /// <param name="options">The serializer options in use.</param>
    public override void Write(Utf8JsonWriter writer, PasswordUsage value, JsonSerializerOptions options)
    {
        if (value.UsageCount == 0)
        {
            writer.WriteStringValue(value.Password);
            return;
        }

        // We had a usageCount, so we write the full object format.
        writer.WriteStartObject();
        writer.WriteString("password", value.Password);
        writer.WriteNumber("usageCount", value.UsageCount);
        writer.WriteEndObject();
    }
}
