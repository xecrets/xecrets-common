using NUnit.Framework;

using Xecrets.Texts;

namespace Xecrets.Common.Test;

[TestFixture]
public class PathEllipsisTests
{
    [Test]
    public void LeavesShortPathsUnchanged()
    {
        string path = Path.Combine("folder", "file.txt");

        Assert.That(path.PathEllipsis(50), Is.EqualTo(path));
    }

    [Test]
    public void ShortensLeadingDirectoriesAndKeepsTheFileName()
    {
        string path = Path.Combine("first-directory", "second-directory", "third-directory", "file.txt");

        string shortened = path.PathEllipsis(30);

        Assert.That(shortened, Has.Length.LessThanOrEqualTo(30));
        Assert.That(shortened, Does.Contain("…"));
        Assert.That(shortened, Does.EndWith(Path.Combine("third-directory", "file.txt")));
    }

    [Test]
    public void TrimsTheStartOfTheFileNameWhenNothingElseFits()
    {
        string path = Path.Combine("first-directory", "second-directory", "a-long-file-name.txt");

        Assert.That(path.PathEllipsis(10), Is.EqualTo("…-name.txt"));
    }
}
