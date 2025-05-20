using SwinAdventure;

namespace SwinAdventureTest;

public class IdentifiableObjectTests
{
    [Test]
    public void TestAreYou()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "5875" });
        Assert.That(TestVariable.AreYou("5875"), Is.True);
    }

    [Test]
    public void TestNotAreYou()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "5875" });
        Assert.That(TestVariable.AreYou("5555"), Is.False);
    }
    [Test]
    public void TestCaseSensitive()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "matthew" });
        Assert.That(TestVariable.AreYou("mATTHEW"), Is.True);
    }
    [Test]
    public void TestFirstId()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "5875", "Matthew", "Xu" });
        Assert.That(TestVariable.FirstId, Is.EqualTo("5875"));
    }
    [Test]
    public void TestFirstIdWithNoIds()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { });
        Assert.That(TestVariable.FirstId, Is.EqualTo(""));
    }
    [Test]
    public void TestAddId()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "seekers", "athol", "keith", "bruce" });
        TestVariable.AddIdentifier("Mary");
        Assert.That(TestVariable.AreYou("seekers"), Is.True);
        Assert.That(TestVariable.AreYou("keith"), Is.True);
        Assert.That(TestVariable.AreYou("mary"), Is.True);
    }
    [Test]
    public void TestPrivilegeEscalation()
    {
        IdentifiableObject TestVariable = new IdentifiableObject(new List<string> { "#2" });
        TestVariable.PrivilegeEscalation("5875");
        Assert.That(TestVariable.FirstId, Is.EqualTo("#1"));
    }
}