using NUnit.Framework;

using Xecrets.Texts;

namespace Xecrets.Common.Test;

[TestFixture]
public class WebsiteUrlMapperTests
{
    [TestCase("https://www.axantum.com", "https://test.axantum.com")]
    [TestCase("https://www.axantum.com/help?topic=profiles#sign-in", "https://test.axantum.com/help?topic=profiles#sign-in")]
    public void MapsProductionSiteUrlsToTheTestSite(string source, string expected)
    {
        Assert.That(source.ToSite(useTestSite: true), Is.EqualTo(expected));
    }

    [Test]
    public void LeavesProductionUrlsUnchangedWhenTheTestSiteIsDisabled()
    {
        const string source = "https://www.axantum.com/help";

        Assert.That(source.ToSite(useTestSite: false), Is.EqualTo(source));
    }

    [TestCase("https://test.axantum.com/help")]
    [TestCase("https://www.axantum.com.example/help")]
    [TestCase("https://github.com/xecrets/xecrets-mobile")]
    [TestCase("not a URL")]
    public void LeavesNonProductionUrlsUnchanged(string source)
    {
        Assert.That(source.ToSite(useTestSite: true), Is.EqualTo(source));
    }
}
