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
/// Converts <see cref="YubiKeyConfiguration"/> to and from JSON, accepting both the current
/// multi-key format and the legacy single-key format for backward compatibility on read.
/// </summary>
public sealed class YubiKeyConfigurationConverter : JsonConverter<YubiKeyConfiguration>
{
    /// <summary>
    /// Reads a <see cref="YubiKeyConfiguration"/> from JSON, accepting either the current
    /// <c>keys</c> array format or the legacy single-key format.
    /// </summary>
    /// <param name="reader">The reader positioned at the value to convert.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The serializer options in use.</param>
    /// <returns>The deserialized configuration.</returns>
    public override YubiKeyConfiguration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement root = document.RootElement;
        List<YubiKeyData> keys = [];

        if (root.TryGetProperty("serialNumber", out JsonElement serialNumber))
        {
            keys.Add(ReadKey(root, true));
        }

        if (root.TryGetProperty("keys", out JsonElement keyArray))
        {
            foreach (JsonElement keyElement in keyArray.EnumerateArray())
            {
                keys.Add(ReadKey(keyElement, false));
            }
        }

        return new YubiKeyConfiguration { Keys = keys };
    }

    /// <summary>
    /// Writes a <see cref="YubiKeyConfiguration"/> as JSON, always using the current <c>keys</c> array format.
    /// </summary>
    /// <param name="writer">The writer to write the JSON to.</param>
    /// <param name="value">The configuration to write.</param>
    /// <param name="options">The serializer options in use.</param>
    public override void Write(Utf8JsonWriter writer, YubiKeyConfiguration value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("keys");
        writer.WriteStartArray();
        foreach (YubiKeyData key in value.Keys)
        {
            writer.WriteStartObject();
            if (key.SerialNumber.Length > 0)
            {
                writer.WriteString("serialNumber", key.SerialNumber);
            }
            if (key.Slot.Length > 0)
            {
                writer.WriteString("slot", key.Slot);
            }
            if (key.Mode != ProtectionMode.Undefined)
            {
                writer.WriteString("mode", key.Mode.ToString());
            }
            if (key.EncryptedPassword.Length > 0)
            {
                writer.WriteString("encryptedPassword", key.EncryptedPassword);
            }
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    private static YubiKeyData ReadKey(JsonElement element, bool legacy)
    {
        ProtectionMode mode = ProtectionMode.Uninitialized;
        if (element.TryGetProperty("mode", out JsonElement modeElement))
        {
            mode = legacy
                ? (ProtectionMode)modeElement.GetInt32()
                : Enum.Parse<ProtectionMode>(modeElement.GetString()!, false);
        }

        return new YubiKeyData
        {
            SerialNumber = element.TryGetProperty("serialNumber", out JsonElement serialNumber)
                ? serialNumber.GetString() ?? string.Empty
                : string.Empty,
            Slot = element.TryGetProperty("slot", out JsonElement slot) ? slot.GetString() ?? string.Empty : string.Empty,
            Mode = mode,
            EncryptedPassword = element.TryGetProperty("encryptedPassword", out JsonElement encryptedPassword)
                ? encryptedPassword.GetString() ?? string.Empty
                : string.Empty,
        };
    }
}
