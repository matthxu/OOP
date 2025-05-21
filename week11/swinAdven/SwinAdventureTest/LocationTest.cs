using SwinAdventure;

public class LocationTest
{
    private Item _testItem;
    private Player _testPlayer;
    private LookCommand _testLookCommand;
    private Location _testLocation;

    [SetUp]

    public void IdentifiablePlayer()
    {
        _testLookCommand = new LookCommand(new List<string> { "" });
        _testPlayer = new Player("Harry Potter", "a student");
        _testLocation = new Location(new List<string> { "TestLocation" }, "Testbed", "For testing...");
        _testItem = new Item(new List<string> { "gem", "Ruby" }, "A Ruby", "A bright pink ruby");
    }

    // [Test]
    // public void TestLocationExists()
    // {
    //     string[] commandText = { "look" };
    //     string result = _testLookCommand.Execute(_testPlayer, commandText);
    //     string expected = "You are in Testbed. For testing....\nHere, you can see :";
    //     Assert.That(result, Is.EqualTo(expected));
    // }

    // [Test]
    // public void TestLocationItems()
    // {
    //     _testLocation.Inventory.Put(_testItem);
    //     string[] commandText = { "look" };
    //     string result = _testLookCommand.Execute(_testPlayer, commandText);
    //     string expected = "You are in Testbed. For testing....\nHere, you can see :\nA Ruby(gem)";
    //     Assert.That(result, Is.EqualTo(expected));
    // }

}