using SwinAdventure;

public class PlayerTests
{
    private Item _testItem1;
    private Item _testItem2;
    private Player _testPlayer;

    [SetUp]

    public void IdentifiablePlayer()
    {
        _testPlayer = new Player("NPC1", "are you an npc as well?");
        _testItem1 = new Item(new List<string> { "TestItemId1" }, "TestItemName", "TestItemDescription");
        _testItem2 = new Item(new List<string> { "TestItemId2" }, "TestItem2Name", "TestItem2Description");
        _testPlayer.Inventory.Put(_testItem1);
        _testPlayer.Inventory.Put(_testItem2);
    }

    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Assert.That(_testPlayer.AreYou("me"), Is.True);
        Assert.That(_testPlayer.AreYou("inventory"), Is.True);
    }
    [Test]
    public void TestPlayerLocatesItems()
    {
        Assert.That(_testPlayer.Locate("TestItemId1"), Is.EqualTo(_testItem1));
    }
    [Test]
    public void TestPlayerLocatesItself()
    {
        Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));
        Assert.That(_testPlayer.Locate("inventory"), Is.EqualTo(_testPlayer));
    }
    [Test]
    public void TestPlayerLocatesNothing()
    {
        Assert.That(_testPlayer.Locate("soul"), Is.Null);
    }
    [Test]
    public void TestPlayerFullDescription()
    {
        Assert.That(_testPlayer.FullDescription, Is.EqualTo("You are NPC1 are you an npc as well?\nYou are carrying:\n" + "TestItemName (TestItemId1), TestItem2Name (TestItemId2)"));
    }
}