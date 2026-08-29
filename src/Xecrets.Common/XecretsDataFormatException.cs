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

namespace Xecrets.Common;

/// <summary>
/// The exception thrown when persisted or imported data does not conform to the expected format,
/// for example because it uses an unsupported version or is otherwise malformed.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="XecretsDataFormatException"/> class.
/// </remarks>
/// <param name="dataKind">The kind of data that failed to conform to the expected format.</param>
/// <param name="reason">A description of why the data was rejected.</param>
/// <param name="supportedVersion">The highest format version supported by this build.</param>
/// <param name="encounteredVersion">The format version found in the data, if it could be determined.</param>
/// <param name="innerException">The exception that caused this exception, if any.</param>
public sealed class XecretsDataFormatException(
    string dataKind,
    string reason,
    int supportedVersion,
    int? encounteredVersion = null,
    Exception? innerException = null) : Exception($"Invalid {dataKind}: {reason}", innerException)
{

    /// <summary>
    /// Gets the kind of data that failed to conform to the expected format.
    /// </summary>
    public string DataKind { get; } = dataKind;

    /// <summary>
    /// Gets a description of why the data was rejected.
    /// </summary>
    public string Reason { get; } = reason;

    /// <summary>
    /// Gets the highest format version supported by this build.
    /// </summary>
    public int SupportedVersion { get; } = supportedVersion;

    /// <summary>
    /// Gets the format version found in the data, or <see langword="null"/> if it could not be determined.
    /// </summary>
    public int? EncounteredVersion { get; } = encounteredVersion;
}
