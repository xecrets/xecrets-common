#region Copyright and License

/*
 * Xecrets Common - Copyright © 2026-2026, Svante Seleborg, All Rights Reserved.
 */

#endregion Copyright and License

using System.Text.Json;

using Xecrets.Common.Abstractions;

namespace Xecrets.Common.Implementation;

/// <summary>
/// Decodes, encodes, and protects Common user-data payloads.
/// </summary>
public sealed class ProtectedPayload : IProtectedPayload
{
    /// <inheritdoc/>
    public async Task<T> Unprotect<T>(byte[]? protectedBytes, IXecretsProtection protection, Action<Exception>? diagnostic = null) where T : new()
    {
        if (protectedBytes is not { Length: > 0 })
        {
            return new();
        }

        byte[] json = await protection.UnprotectAsync(protectedBytes);
        if (json.Length == 0)
        {
            return new();
        }

        try
        {
            if (JsonSerializer.Deserialize(json, typeof(T), CommonJsonContext.Relaxed) is T result)
            {
                return result;
            }
            return new();
        }
        catch (JsonException exception)
        {
            try
            {
                diagnostic?.Invoke(exception);
            }
            catch
            {
                // Diagnostics must not change the malformed-payload fallback.
            }
            return new();
        }
    }

    /// <inheritdoc/>
    public Task<byte[]> Protect<T>(T value, IXecretsProtection protection) =>
        protection.ProtectAsync(JsonFile.SerializeToUtf8Bytes(value), "extra-credentials.json");
}
