using System.Security.Cryptography;

using NUnit.Framework;

namespace Xecrets.Common.Test;

[TestFixture]
public sealed class PublicKeyExtensionsTests
{
    [Test]
    public void MatchesTheSamePublicKeyWithDifferentPemFormatting()
    {
        using RSA rsa = RSA.Create(1024);
        byte[] publicKey = rsa.ExportSubjectPublicKeyInfo();
        string pem = PemEncoding.WriteString("PUBLIC KEY", publicKey);
        string reformatted = "-----BEGIN PUBLIC KEY-----\r\n"
            + Convert.ToBase64String(publicKey) + "\r\n-----END PUBLIC KEY-----";

        Assert.That(pem.HasSamePublicKey(reformatted), Is.True);
    }

    [Test]
    public void DoesNotMatchDifferentPublicKeys()
    {
        using RSA first = RSA.Create(1024);
        using RSA second = RSA.Create(1024);

        Assert.That(first.ExportSubjectPublicKeyInfoPem().HasSamePublicKey(second.ExportSubjectPublicKeyInfoPem()),
            Is.False);
    }
}
