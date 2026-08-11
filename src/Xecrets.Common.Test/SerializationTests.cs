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
