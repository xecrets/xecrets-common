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

using System.Text.Json;

using NUnit.Framework;

using Xecrets.Common.Implementation;
using Xecrets.Common.Models;

namespace Xecrets.Common.Test;

[TestFixture]
public sealed class JsonFileTests
{
    private string _directory = null!;

    [SetUp]
    public void SetUp()
    {
        _directory = Path.Combine(Path.GetTempPath(), $"xecrets-common-json-test-{Guid.NewGuid():N}");
        Directory.CreateDirectory(_directory);
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(_directory, true);
    }

    [Test]
    public void LoadReportsInvalidJsonAndReturnsDefault()
    {
        string path = Path.Combine(_directory, "settings.json");
        File.WriteAllText(path, "{ invalid");
        Exception? caught = null;

        ApplicationSettings settings = JsonFile.Load<ApplicationSettings>(path, exception => caught = exception);

        Assert.That(caught, Is.Not.Null);
        Assert.That(settings.NextLocalUserId, Is.EqualTo(1));
    }

    [Test]
    public async Task LoadAsyncReportsInvalidJsonAndReturnsDefault()
    {
        string path = Path.Combine(_directory, "settings.json");
        await File.WriteAllTextAsync(path, "{ invalid");
        Exception? caught = null;

        ApplicationSettings settings = await JsonFile.LoadAsync<ApplicationSettings>(
            path, exception => caught = exception);

        Assert.That(caught, Is.Not.Null);
        Assert.That(settings.NextLocalUserId, Is.EqualTo(1));
    }

    [Test]
    public async Task WriteAsyncRoundTripsValue()
    {
        string path = Path.Combine(_directory, "settings.json");
        ApplicationSettings expected = new() { Theme = "Dark" };

        string serialized = await JsonFile.WriteAsync(path, expected);
        ApplicationSettings actual = await JsonFile.LoadAsync<ApplicationSettings>(path, _ => { });

        Assert.That(serialized, Does.Contain("\"theme\": \"Dark\""));
        Assert.That(actual.Theme, Is.EqualTo(expected.Theme));
    }

    [Test]
    public void StringSerializationRoundTripsValue()
    {
        ApplicationSettings expected = new() { Theme = "Dark" };

        string json = JsonFile.Serialize(expected);
        ApplicationSettings actual = JsonFile.Deserialize<ApplicationSettings>(json, _ => { });

        Assert.That(actual.Theme, Is.EqualTo(expected.Theme));
    }

    [Test]
    public void SerializeUsesCanonicalRelaxedFormat()
    {
        ApplicationSettings settings = new() { Theme = "Räksmörgås" };

        string json = JsonFile.Serialize(settings);

        Assert.That(json, Does.Contain("\n  \"theme\""));
        Assert.That(json, Does.Contain("Räksmörgås"));
        Assert.That(json, Does.Not.Contain("lastWriteUtc"));
    }

    [Test]
    public void Utf8SerializationRoundTripsValue()
    {
        ApplicationSettings expected = new() { Theme = "Dark" };

        byte[] json = JsonFile.SerializeToUtf8Bytes(expected);
        ApplicationSettings actual = JsonFile.Deserialize<ApplicationSettings>(json, _ => { });

        Assert.That(actual.Theme, Is.EqualTo(expected.Theme));
    }

    [TestCase("null")]
    [TestCase("{ invalid")]
    public void DeserializeReturnsDefaultForNullOrInvalidJson(string json)
    {
        ApplicationSettings settings = JsonFile.Deserialize<ApplicationSettings>(json, _ => { });

        Assert.That(settings.NextLocalUserId, Is.EqualTo(1));
    }

    [Test]
    public void DeserializeReportsInvalidUtf8Json()
    {
        Exception? caught = null;

        ApplicationSettings settings = JsonFile.Deserialize<ApplicationSettings>("{ invalid"u8,
            exception => caught = exception);

        Assert.That(caught, Is.TypeOf<JsonException>());
        Assert.That(settings.NextLocalUserId, Is.EqualTo(1));
    }

    [Test]
    public void DeserializeAllowsCallbackToThrow()
    {
        Assert.That(
            () => JsonFile.Deserialize<ApplicationSettings>("{ invalid", exception => throw exception),
            Throws.TypeOf<JsonException>());
    }
}
