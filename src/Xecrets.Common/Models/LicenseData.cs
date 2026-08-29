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

namespace Xecrets.Common.Models;

/// <summary>
/// Represents the license text associated with a user's installation.
/// </summary>
public sealed class LicenseData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LicenseData"/> class with empty license text.
    /// </summary>
    public LicenseData()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LicenseData"/> class with the given license text.
    /// </summary>
    /// <param name="text">The license text.</param>
    public LicenseData(string text)
    {
        Text = text;
    }

    /// <summary>
    /// Gets or sets the license text.
    /// </summary>
    public string Text { get; set; } = string.Empty;
}
