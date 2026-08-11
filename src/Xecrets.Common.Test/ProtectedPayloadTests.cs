using NUnit.Framework;

using Xecrets.Common.Abstractions;
using Xecrets.Common.Implementation;
using Xecrets.Common.Models;

namespace Xecrets.Common.Test;

[TestFixture]
public sealed class ProtectedPayloadTests
{
    private readonly IProtectedPayload _payload = new ProtectedPayload();

    [Test]
    public async Task ExtraCredentialsDecodePreservesDuplicatePasswords()
    {
        ExtraCredentials source = new()
        {
            Passwords = [
                new PasswordUsage { Password = "same" },
                new PasswordUsage { Password = "same" },
                new PasswordUsage { Password = "other" },
            ],
        };
        PassthroughProtection protection = new();
        ExtraCredentials decoded = await _payload.Unprotect<ExtraCredentials>(
            await _payload.Protect(source, protection), protection);

        Assert.That(decoded.Passwords.Select(password => password.Password), Is.EqualTo(["same", "same", "other"]));
    }

    [Test]
    public async Task InvalidPayloadReturnsDefaultAndDiagnosticCannotAlterFallback()
    {
        ExtraCredentials value = await _payload.Unprotect<ExtraCredentials>(
            "{ invalid"u8.ToArray(),
            new PassthroughProtection(),
            _ => throw new InvalidOperationException());

        Assert.That(value.Passwords, Is.Empty);
        Assert.That(value.Version, Is.EqualTo(ExtraCredentials.SupportedVersion));
    }

    private sealed class PassthroughProtection : IXecretsProtection
    {
        public Task<byte[]> ProtectAsync(byte[] cleartext, string originalFilename) => Task.FromResult(cleartext);

        public Task<byte[]> UnprotectAsync(byte[] protectedBytes) => Task.FromResult(protectedBytes);
    }

}
