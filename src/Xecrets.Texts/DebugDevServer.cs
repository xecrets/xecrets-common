#region Copyright and License

/*
 * Xecrets Texts - Copyright © 2022-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Texts
 *
 * Xecrets Texts is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Texts is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Texts.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-common please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;

namespace Xecrets.Texts;

/// <summary>
/// Detects whether the local development web server is running on port 3000.
/// Only valid in debug builds and only on desktop operating systems.
/// </summary>
public static class DebugDevServer
{
    /// <summary>
    /// Returns <see langword="true"/> when a TCP listener is active on port 3000, indicating the dev server is up.
    /// Must only be called inside a debug-mode guard (<see cref="Is.Debug"/>).
    /// </summary>
    /// <exception cref="NotImplementedException">Thrown if called in a release build.</exception>
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    [SupportedOSPlatform("macos")]
    internal static bool IsDevServerRunning
    {
        get
        {
            if (Is.Debug)
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] tcpListeners = ipGlobalProperties.GetActiveTcpListeners();

                return tcpListeners.Any(l => l.Port == 3000);
            }

            throw new NotImplementedException("This should never be called in Release builds.");
        }
    }
}
