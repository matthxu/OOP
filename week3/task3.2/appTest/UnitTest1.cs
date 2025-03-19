namespace appTest;

public class Tests
{
    [Test]
    public void AreYouTest()
    {
        Items TestVar = new Items(new List<string> {"TestItem"}, "description", "name");
        Assert.That(TestVar.AreYou("TestItem"), Is.True);
        Assert.That(TestVar.AreYou("MissingItem"), Is.False);
    }
    [Test]
    public void TestShortDescription() {
        Items TestVar = new Items(new List<string> {"sword"}, "a sturdy sword", "a bronze sword");
        Assert.That(TestVar.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
    }
    [Test]
    public void TestFullDescription() {
        Items TestVar = new Items(new List<string> {"sword"}, "a sturdy sword", "a bronze sword");
        Assert.That(TestVar.LongDescription, Is.EqualTo("a sturdy sword"));
    }
    [Test]
    public void TestPrivilegeEscalation() {
        Items TestVar = new Items(new List<string> {""}, "desc", "name");
        TestVar.PrivilegeEscalation("5875");
        Assert.That(TestVar.firstId, Is.EqualTo("#1"));
    }
}
