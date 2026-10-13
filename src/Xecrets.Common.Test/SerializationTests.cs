#region Copyright and GPL License

/*
 * Xecrets.Net - Copyright © 2022-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets.Net, parts of which in turn are derived from AxCrypt as licensed under GPL v3 or later.
 *
 * However, this code is not derived from AxCrypt and is separately copyrighted and only licensed as follows unless
 * explicitly licensed otherwise. If you use any part of this code in your software, please see https://www.gnu.org/licenses/
 * for details of what this means for you.
 *
 * Xecrets.Net is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *
 * Xecrets.Net is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets.Net. If not, see
 * <https://www.gnu.org/licenses/>.
 */

#endregion Copyright and GPL License

using System.Text.Json;
using System.Text.Json.Serialization;

using NUnit.Framework;

using Xecrets.Common;
using Xecrets.Common.Abstractions;
using Xecrets.Common.Implementation;
using Xecrets.Common.Models;

namespace Xecrets.Common.Test;

[TestFixture]
public class SerializationTests
{
    private static readonly JsonSerializerOptions LegacyOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        WriteIndented = true,
    };

    [Test]
    public void ApplicationSettingsUseLegacyPropertyNamesAndDefaults()
    {
        ApplicationSettings settings = new();

        string json = JsonSerializer.Serialize(settings, LegacyOptions);

        Assert.That(json, Does.Contain("\"nextLocalUserId\": 1"));
        Assert.That(json, Does.Contain("\"theme\": \"Default\""));
        Assert.That(json, Does.Contain("\"mostRecentVersion\": \"1.0.0.0\""));
        Assert.That(json, Does.Not.Contain("globalScaleFactor"));
    }

    // A settings file written before the 'version' property existed has no such property in its
    // JSON. Deserialization must then leave Version at its default, i.e. treat the file as the
    // current SupportedVersion, so old files keep loading without a migration step. The same
    // reasoning applies to every other type with a SupportedVersion/Version pair.
    [Test]
    public void MissingVersionPropertyDeserializesAsSupportedVersion()
    {
        Assert.That(JsonSerializer.Deserialize<ApplicationSettings>("{}")!.Version,
            Is.EqualTo(ApplicationSettings.SupportedVersion));
        Assert.That(JsonSerializer.Deserialize<UserSettings>("{}")!.Version,
            Is.EqualTo(UserSettings.SupportedVersion));
        Assert.That(JsonSerializer.Deserialize<ExtraCredentials>("{}")!.Version,
            Is.EqualTo(ExtraCredentials.SupportedVersion));
        Assert.That(JsonSerializer.Deserialize<OpenState>("{}")!.Version,
            Is.EqualTo(OpenState.SupportedVersion));
        Assert.That(JsonSerializer.Deserialize<PrivateKeyData>("{}")!.Version,
            Is.EqualTo(PrivateKeyData.SupportedVersion));
    }

    [Test]
    public void ApplicationSettingsVersionIsWritten()
    {
        ApplicationSettings settings = new();

        string json = JsonSerializer.Serialize(settings, LegacyOptions);

        Assert.That(json, Does.Contain($"\"version\": {ApplicationSettings.SupportedVersion}"));
    }

    [Test]
    public void UserSettingsIdIsGeneratedAndPreservedWhenMissingFromLegacyJson()
    {
        UserSettings created = new();
        UserSettings legacy = JsonSerializer.Deserialize<UserSettings>("{}")!;

        Assert.Multiple(() =>
        {
            Assert.That(Guid.TryParseExact(created.Id, "N", out _), Is.True);
            Assert.That(Guid.TryParseExact(legacy.Id, "N", out _), Is.True);
            Assert.That(JsonSerializer.Serialize(legacy, LegacyOptions), Does.Contain($"\"id\": \"{legacy.Id}\""));
        });
    }

    [Test]
    public void RecentFilesRoundTripAsAnIndependentModel()
    {
        RecentFiles recentFiles = new() { Files = ["one.axx", "two.axx"] };

        string json = JsonSerializer.Serialize(recentFiles, LegacyOptions);
        RecentFiles roundTrip = JsonSerializer.Deserialize<RecentFiles>(json)!;

        Assert.That(roundTrip.Files, Is.EqualTo(["one.axx", "two.axx"]));
    }

    [Test]
    public void RecentFileOperationsRoundTripAsAnIndependentModel()
    {
        RecentFileOperations recentFiles = new()
        {
            Files =
            [
                new RecentFile { Id = "one.axx", Operation = RecentFileOperation.InPlace },
                new RecentFile { Id = "two.axx", Operation = RecentFileOperation.View },
            ],
        };

        string json = JsonSerializer.Serialize(recentFiles, LegacyOptions);
        RecentFileOperations roundTrip = JsonSerializer.Deserialize<RecentFileOperations>(json)!;

        Assert.That(roundTrip.Files.Select(file => (file.Id, file.Operation)), Is.EqualTo(new[]
        {
            ("one.axx", RecentFileOperation.InPlace),
            ("two.axx", RecentFileOperation.View),
        }));
    }

    [Test]
    public void RecentFileIsWrittenAsAnObjectWithTheOperationName()
    {
        string json = JsonSerializer.Serialize(
            new RecentFile { Id = "one.axx", Operation = RecentFileOperation.EncryptWithSendTo },
            LegacyOptions);

        using JsonDocument document = JsonDocument.Parse(json);
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("id").GetString(), Is.EqualTo("one.axx"));
            Assert.That(document.RootElement.GetProperty("operation").GetString(), Is.EqualTo("EncryptWithSendTo"));
        });
    }

    [Test]
    public void RecentFileReadsMissingAndUnknownOperationsAsUnknown()
    {
        RecentFileOperations recentFiles = JsonSerializer.Deserialize<RecentFileOperations>(
            """{ "Files": [ { "id": "one.axx" }, { "id": "two.axx", "operation": "SomethingNew" } ] }""")!;

        Assert.That(recentFiles.Files.Select(file => (file.Id, file.Operation)), Is.EqualTo(new[]
        {
            ("one.axx", RecentFileOperation.Unknown),
            ("two.axx", RecentFileOperation.Unknown),
        }));
    }

    [Test]
    public void RecentFileRoundTripsItsName()
    {
        string json = JsonSerializer.Serialize(new RecentFile { Id = "one.axx", Name = "One.axx" }, LegacyOptions);
        RecentFile roundTrip = JsonSerializer.Deserialize<RecentFile>(json)!;

        Assert.That(roundTrip.Name, Is.EqualTo("One.axx"));
    }

    [Test]
    public void RecentFileReadsAMissingNameAsEmpty()
    {
        RecentFile recentFile = JsonSerializer.Deserialize<RecentFile>("""{ "id": "one.axx", "operation": "View" }""")!;

        Assert.That(recentFile.Name, Is.Empty);
    }

    [Test]
    public void RecentFileRoundTripsItsRootAndFolderPath()
    {
        string json = JsonSerializer.Serialize(
            new RecentFile { Id = "one.axx", Root = RootProvider.GoogleDrive, FolderPath = ["Work", "Secret"] },
            LegacyOptions);
        RecentFile roundTrip = JsonSerializer.Deserialize<RecentFile>(json)!;

        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Root, Is.EqualTo(RootProvider.GoogleDrive));
            Assert.That(roundTrip.FolderPath, Is.EqualTo(new[] { "Work", "Secret" }));
        });
    }

    [Test]
    public void WorkFolderRoundTripsItsRootAndFolderPath()
    {
        string json = JsonSerializer.Serialize(
            new WorkFolder("id", "Work", "grant") { Root = RootProvider.Dropbox, FolderPath = ["Projects"] },
            LegacyOptions);
        WorkFolder roundTrip = JsonSerializer.Deserialize<WorkFolder>(json)!;

        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Root, Is.EqualTo(RootProvider.Dropbox));
            Assert.That(roundTrip.FolderPath, Is.EqualTo(new[] { "Projects" }));
            Assert.That(roundTrip.DisplayName, Is.EqualTo("Work"));
        });
    }

    [Test]
    public void WorkFolderReadsAMissingRootAsUnknown()
    {
        WorkFolder folder = JsonSerializer.Deserialize<WorkFolder>("""{ "id": "id", "displayName": "Work" }""")!;

        Assert.Multiple(() =>
        {
            Assert.That(folder.Root, Is.EqualTo(RootProvider.Unknown));
            Assert.That(folder.FolderPath, Is.Empty);
        });
    }

    [Test]
    public void RecentFileReadsAMissingRootAsUnknown()
    {
        RecentFile recentFile = JsonSerializer.Deserialize<RecentFile>("""{ "id": "one.axx" }""")!;

        Assert.Multiple(() =>
        {
            Assert.That(recentFile.Root, Is.EqualTo(RootProvider.Unknown));
            Assert.That(recentFile.FolderPath, Is.Empty);
        });
    }

    [Test]
    public void RecentFileIsWrittenWithTheRootName()
    {
        string json = JsonSerializer.Serialize(new RecentFile { Id = "one.axx", Root = RootProvider.None }, LegacyOptions);

        using JsonDocument document = JsonDocument.Parse(json);
        Assert.That(document.RootElement.GetProperty("root").GetString(), Is.EqualTo("None"));
    }

    [Test]
    public void RecentFileDoesNotWriteAnUnknownRoot()
    {
        string json = JsonSerializer.Serialize(
            new RecentFile { Id = "one.axx", Root = RootProvider.Unknown },
            LegacyOptions);

        using JsonDocument document = JsonDocument.Parse(json);
        Assert.That(document.RootElement.TryGetProperty("root", out _), Is.False);
    }

    [Test]
    public void DeviceSettingsRoundTrip()
    {
        DeviceSettings settings = new()
        {
            Version = 1,
            DeviceIdSalt = "00",
            DeviceId = "device",
            Values = { ["iterations"] = "1000" },
            Profiles =
            {
                ["profile"] = new ProfileDeviceSettings
                {
                    WorkFolders = new WorkFolders { Folders = [new WorkFolder("folder", "Folder")] },
                    RecentFiles = [new RecentFile { Id = "one.axx", Operation = RecentFileOperation.View }],
                    DontShowAgain = "WelcomeInformation",
                },
            },
        };

        DeviceSettings roundTrip = JsonSerializer.Deserialize<DeviceSettings>(JsonFile.Serialize(settings))!;

        ProfileDeviceSettings profile = roundTrip.Profiles["profile"];
        Assert.Multiple(() =>
        {
            Assert.That(roundTrip.Version, Is.EqualTo(1));
            Assert.That(roundTrip.DeviceIdSalt, Is.EqualTo("00"));
            Assert.That(roundTrip.DeviceId, Is.EqualTo("device"));
            Assert.That(roundTrip.Values["iterations"], Is.EqualTo("1000"));
            Assert.That(profile.WorkFolders.Folders.Select(folder => folder.Id), Is.EqualTo(new[] { "folder" }));
            Assert.That(profile.RecentFiles.Select(file => (file.Id, file.Operation)), Is.EqualTo(new[]
            {
                ("one.axx", RecentFileOperation.View),
            }));
            Assert.That(profile.DontShowAgain, Is.EqualTo("WelcomeInformation"));
        });
    }

    [Test]
    public void DeviceSettingsReadAMissingVersionAsZero()
    {
        DeviceSettings settings = JsonSerializer.Deserialize<DeviceSettings>("""{ "values": {} }""")!;

        Assert.That(settings.Version, Is.Zero);
    }

    [Test]
    public void OpenStateRoundTripsOpenAndRecentFilesTogether()
    {
        OpenState state = new()
        {
            RecentFiles = ["one.axx", "two.axx"],
        };

        string json = JsonSerializer.Serialize(state, LegacyOptions);
        OpenState roundTrip = JsonSerializer.Deserialize<OpenState>(json)!;

        Assert.That(roundTrip.RecentFiles, Is.EqualTo(["one.axx", "two.axx"]));
        Assert.That(json, Does.Contain("\"open\""));
        Assert.That(json, Does.Contain("\"recentFiles\""));
    }

    [Test]
    public void OpenFilesRoundTripAsAnIndependentModel()
    {
        OpenFiles openFiles = new()
        {
            Files =
            [
                new OpenFilePairState
                {
                    OriginalName = "one.txt",
                    Encrypted = new FileMetadata { FullName = "one.axx" },
                    Decrypted = new FileMetadata { FullName = "one.txt" },
                },
            ],
        };

        string json = JsonSerializer.Serialize(openFiles, LegacyOptions);
        OpenFiles roundTrip = JsonSerializer.Deserialize<OpenFiles>(json)!;

        Assert.That(roundTrip.Files, Has.Count.EqualTo(1));
        Assert.That(roundTrip.Files[0].Encrypted.FullName, Is.EqualTo("one.axx"));
        Assert.That(json, Does.Contain("\"openFiles\""));
    }

    [Test]
    public void LegacySingleYubiKeyIsReadAndCurrentShapeIsWritten()
    {
        const string legacy = """
            {"serialNumber":"123","slot":"9a","mode":3,"encryptedPassword":"cipher"}
            """;

        YubiKeyConfiguration configuration = JsonSerializer.Deserialize<YubiKeyConfiguration>(legacy)!;
        string current = JsonSerializer.Serialize(configuration, LegacyOptions);

        Assert.That(configuration.Keys, Has.Count.EqualTo(1));
        Assert.That(configuration.Keys[0].Mode, Is.EqualTo(ProtectionMode.Secure));
        Assert.That(current, Does.Contain("\"keys\""));
        Assert.That(current, Does.Contain("\"mode\": \"Secure\""));
    }

    // A password with no recorded usage count must keep the legacy plain-string shape on write,
    // not just on read - the object shape is only introduced once a usage count is actually
    // recorded (see PasswordUsageCountRoundTripsThroughCurrentObjectShape below), so that a file
    // untouched by Xecrets Mobile never changes shape just because some other app happened to
    // resave it.
    [Test]
    public void LegacyStringPasswordsAreReadAndWrittenBackUnchangedUntilCounted()
    {
        const string legacy = """
            {"passwords":["pw1","pw2"]}
            """;

        ExtraCredentials credentials = JsonSerializer.Deserialize<ExtraCredentials>(legacy)!;
        string current = JsonSerializer.Serialize(credentials, LegacyOptions);

        Assert.That(credentials.Passwords, Has.Count.EqualTo(2));
        Assert.That(credentials.Passwords[0], Has.Property(nameof(PasswordUsage.Password)).EqualTo("pw1"));
        Assert.That(credentials.Passwords[0], Has.Property(nameof(PasswordUsage.UsageCount)).EqualTo(0));
        Assert.That(current, Does.Contain("\"pw1\""));
        Assert.That(current, Does.Not.Contain("\"password\":"));
        Assert.That(current, Does.Not.Contain("usageCount"));
    }

    [Test]
    public void PasswordUsageCountRoundTripsThroughCurrentObjectShape()
    {
        const string current = """
            {"passwords":[{"password":"pw1","usageCount":3}]}
            """;

        ExtraCredentials credentials = JsonSerializer.Deserialize<ExtraCredentials>(current)!;
        string roundTrip = JsonSerializer.Serialize(credentials, LegacyOptions);

        Assert.That(credentials.Passwords[0].UsageCount, Is.EqualTo(3));
        Assert.That(roundTrip, Does.Contain("\"usageCount\": 3"));
    }

    [Test]
    public void PrivateKeyJsonRoundTripsWithoutChangingTheTypedShape()
    {
        const string json = """
            {"accounts":[{"keys":[{"user":"a@example.com","timestamp":"2025-01-02T03:04:05Z","thumbprint":"abc","keypair":{"public":"public","private":"private"},"keypair_status":1}],"user":"a@example.com"}]}
            """;

        PrivateKeyData data = JsonSerializer.Deserialize<PrivateKeyData>(json)!;
        string roundTrip = JsonSerializer.Serialize(data, LegacyOptions);

        Assert.That(data.Accounts[0].Keys[0].PasswordStatus, Is.EqualTo(PrivateKeyPasswordStatus.Known));
        Assert.That(roundTrip, Does.Contain("\"keypair_status\": 1"));
        Assert.That(roundTrip, Does.Contain("\"accounts\""));
    }
}
