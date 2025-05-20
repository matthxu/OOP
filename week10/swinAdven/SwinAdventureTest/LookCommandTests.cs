using SwinAdventure;

public class LookCommandTests
{
    private Item _testItem;
    private Player _testPlayer;
    private Bag _testMoneyBag;
    private LookCommand _testLookCommand;

    [SetUp]

    public void IdentifiablePlayer()
    {
        _testLookCommand = new LookCommand(new List<string> { "" });

        _testPlayer = new Player("Harry Potter", "a student");

        _testItem = new Item(new List<string> { "gem", "Ruby" }, "A Ruby", "A bright pink ruby");
        _testMoneyBag = new Bag(new List<string> { "bag", "money" }, "Money Bag", "A bag that contains Valuables");

        _testPlayer.Inventory.Put(_testItem);
    }

    [Test]
    public void TestLookAtMe()
    {
        string[] commandText = { "look", "at", "inventory" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        string expected = "You are Harry Potter a student\nYou are carrying:\nA Ruby (gem)";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtGem()
    {
        string[] commandText = { "look", "at", "gem" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        Assert.That(_testItem.FullDescription, Is.EqualTo(result));
    }

    [Test]
    public void TestLookAtUnk()
    {
        string[] commandText = { "look", "at", "sword" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        string expected = $"I can't find the sword";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtGemInMe()
    {
        string[] commandText = { "look", "at", "gem", "in", "inventory" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        Assert.That(result, Is.EqualTo(_testItem.FullDescription));
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        _testPlayer.Inventory.Put(_testMoneyBag);
        _testMoneyBag.Inventory.Put(_testItem);

        string[] commandText = { "look", "at", "gem", "in", "bag" }; // Using "coin" and "bag" IDs
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        Assert.That(result, Is.EqualTo(_testItem.FullDescription));
    }

    [Test]
    public void TestLookAtGemInNoBag()
    {
        string[] commandText = { "look", "at", "gem", "in", "bag" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        string expected = "I cannot find the bag.";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtNoGemInBag()
    {
        _testPlayer.Inventory.Put(_testMoneyBag);
        string[] commandText = { "look", "at", "gem", "in", "bag" };
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        string expected = $"I can't find the gem";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    // Test look options to check all error conditions. This include “look around”, or “hello your student ID”, “look at your name”.
    public void TestInvalidLook()
    {
        string[] cmdLookAround = { "look", "around" };
        string resultLookAround = _testLookCommand.Execute(_testPlayer, cmdLookAround);
        Assert.That(resultLookAround, Is.EqualTo("I don't know how to look like that"));

        string[] cmdHelloId = { "hello", "player", "105645875" };
        string resultHelloId = _testLookCommand.Execute(_testPlayer, cmdHelloId);
        Assert.That(resultHelloId, Is.EqualTo("Error in look input"));

        string[] cmdLookInBag = { "look", "in", "bag" };
        string resultLookInBag = _testLookCommand.Execute(_testPlayer, cmdLookInBag);
        Assert.That(resultLookInBag, Is.EqualTo("What do you want to look at?"));

        string[] cmdLookOnGround = { "look", "at", "gem", "on", "ground" };
        string resultLookOnGround = _testLookCommand.Execute(_testPlayer, cmdLookOnGround);
        Assert.That(resultLookOnGround, Is.EqualTo("What do you want to look in?"));
    }
}