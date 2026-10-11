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
/// Where a file is stored, as far as it is known: the storage of the device, or the provider that gives access to it,
/// such as a cloud storage service. The kind of device is kept, so that it can later be shown as specifically or as
/// generally as wanted.
/// </summary>
public enum RootProvider
{
    /// <summary>
    /// Where the file is stored is not known. The default value.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// There is no provider, and the folder path starts at the top, such as with a drive on Windows.
    /// </summary>
    None,

    /// <summary>
    /// The file is stored by a provider that is not recognized.
    /// </summary>
    Other,

    /// <summary>
    /// The file is stored on an Android phone.
    /// </summary>
    AndroidPhone,

    /// <summary>
    /// The file is stored on an Android tablet.
    /// </summary>
    AndroidTablet,

    /// <summary>
    /// The file is stored on another kind of Android device.
    /// </summary>
    AndroidDevice,

    /// <summary>
    /// The file is stored on an iPhone.
    /// </summary>
    IPhone,

    /// <summary>
    /// The file is stored on an iPad.
    /// </summary>
    IPad,

    /// <summary>
    /// The file is stored on a Mac.
    /// </summary>
    Mac,

    /// <summary>
    /// The file is stored on removable storage of an Android device, such as an SD card or a USB drive.
    /// </summary>
    RemovableStorage,

    /// <summary>
    /// The file is stored on an external drive connected to an Apple device.
    /// </summary>
    ExternalDrive,

    /// <summary>
    /// The file is one of the downloads of an Android device.
    /// </summary>
    Downloads,

    /// <summary>
    /// The file is one of the images of an Android device.
    /// </summary>
    MediaImages,

    /// <summary>
    /// The file is one of the videos of an Android device.
    /// </summary>
    MediaVideos,

    /// <summary>
    /// The file is one of the audio files of an Android device.
    /// </summary>
    MediaAudio,

    /// <summary>
    /// The file is one of the documents of an Android device.
    /// </summary>
    MediaDocuments,

    /// <summary>
    /// The file is stored in iCloud Drive.
    /// </summary>
    ICloudDrive,

    /// <summary>
    /// The file is stored in Google Drive.
    /// </summary>
    GoogleDrive,

    /// <summary>
    /// The file is stored in OneDrive.
    /// </summary>
    OneDrive,

    /// <summary>
    /// The file is stored in Dropbox.
    /// </summary>
    Dropbox,

    /// <summary>
    /// The file is stored in some other cloud storage service.
    /// </summary>
    CloudStorage,
}
