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

using System.Text.Json.Serialization;

namespace Xecrets.Common.Models;

/// <summary>
/// Represents a file on the list of recently used files, together with the operation that put it there.
/// </summary>
public sealed class RecentFile
{
    /// <summary>
    /// Gets or sets the full path of, or the platform reference to, the file.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the file as last seen while it could be accessed, for showing it when it no longer
    /// can be and its name cannot be had from <see cref="Id"/>. Null when not known.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the name of the known folder the file was last accessed through, for naming that folder when it
    /// is no longer known. Null when not known.
    /// </summary>
    [JsonPropertyName("folder")]
    public string? FolderName { get; set; }

    /// <summary>
    /// Gets or sets the name of the operation that put the file on the list, as persisted. The name is kept as is,
    /// even when not known by this version, so that it survives being read and written again.
    /// </summary>
    [JsonPropertyName("operation")]
    public string? OperationName { get; set; }

    /// <summary>
    /// Gets or sets the operation that put the file on the list. A missing name, or a name not known by this version,
    /// is read as <see cref="RecentFileOperation.Unknown"/>.
    /// </summary>
    [JsonIgnore]
    public RecentFileOperation Operation
    {
        get => Enum.TryParse(OperationName, out RecentFileOperation value) && value.ToString() == OperationName
            ? value
            : RecentFileOperation.Unknown;
        set => OperationName = value.ToString();
    }
}
