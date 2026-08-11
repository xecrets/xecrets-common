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

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Xecrets.Common.Models;

namespace Xecrets.Common;

/// <summary>
/// The source-generated <see cref="JsonSerializerContext"/> for the model types in
/// <see cref="Xecrets.Common.Models"/>, so that this library and its consumers can serialize and
/// deserialize them without relying on reflection - required for trimming and Native AOT.
/// </summary>
[JsonSourceGenerationOptions(WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    IgnoreReadOnlyFields = true,
    IgnoreReadOnlyProperties = true,
    IncludeFields = false)]
[JsonSerializable(typeof(ApplicationSettings))]
[JsonSerializable(typeof(UserSettings))]
[JsonSerializable(typeof(ExtraCredentials))]
[JsonSerializable(typeof(OpenState))]
[JsonSerializable(typeof(OpenFiles))]
[JsonSerializable(typeof(RecentFiles))]
[JsonSerializable(typeof(PrivateKeyData))]
[JsonSerializable(typeof(LicenseData))]
[JsonSerializable(typeof(ApplicationData))]
[JsonSerializable(typeof(LocalProfileData))]
internal partial class CommonJsonContext : JsonSerializerContext
{
    /// <summary>
    /// Gets a context using the same options as the generated default context, except for using
    /// <see cref="JavaScriptEncoder.UnsafeRelaxedJsonEscaping"/>, for writing files that do not
    /// need to be safely embeddable in HTML or JavaScript.
    /// </summary>
    internal static CommonJsonContext Relaxed { get; } = new(new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        IncludeFields = false,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    });
}
