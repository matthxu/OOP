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
    public void TestLookAtItemInBag() // Renamed from TestLookAtGemInBag for clarity with _testItem
    {
        _testPlayer.Inventory.Put(_testMoneyBag);
        _testMoneyBag.Inventory.Put(_testItem);

        string[] commandText = { "look", "at", "coin", "in", "bag" }; // Using "coin" and "bag" IDs
        string result = _testLookCommand.Execute(_testPlayer, commandText);
        Assert.That(result, Is.EqualTo(_testItem.FullDescription));
    }

    // [Test]
    // public void TestLookAtItemInNoBag() // Renamed from TestLookAtGemInNoBag
    // {
    //     // _testMoneyBag is NOT in player's inventory.
    //     string[] commandText = { "look", "at", "coin", "in", "bag" };
    //     string result = _testLookCommand.Execute(_testPlayer, commandText);
    //     string expected = "I cannot find the bag."; // Assuming "bag" is the ID used in command
    //     Assert.That(result, Is.EqualTo(expected));
    // }

    // [Test]
    // public void TestLookAtNoItemInBag() // Renamed from TestLookAtNoGemInBag
    // {
    //     _testPlayer.Inventory.Put(_testMoneyBag);
    //     // _testMoneyBag is in player's inventory, but it's empty or doesn't have a "diamond".
    //     string[] commandText = { "look", "at", "diamond", "in", "bag" };
    //     string result = _testLookCommand.Execute(_testPlayer, commandText);
    //     string expected = $"I cannot find the diamond in {_testMoneyBag.Name}.";
    //     Assert.That(result, Is.EqualTo(expected));
    // }

    // [Test]
    // public void TestInvalidLook()
    // {
    //     string[] cmdLookAround = { "look", "around" };
    //     string resultLookAround = _testLookCommand.Execute(_testPlayer, cmdLookAround);
    //     Assert.That(resultLookAround, Is.EqualTo("What do you want to look at?"));

    //     string[] cmdLookAtMissingItem = { "look", "at" };
    //     string resultLookAtMissingItem = _testLookCommand.Execute(_testPlayer, cmdLookAtMissingItem);
    //     Assert.That(resultLookAtMissingItem, Is.EqualTo("I don’t know how to look like that"));

    //     string[] cmdLookAtGemInMissingContainer = { "look", "at", "gem", "in" };
    //     string resultLookAtGemInMissingContainer = _testLookCommand.Execute(_testPlayer, cmdLookAtGemInMissingContainer);
    //     Assert.That(resultLookAtGemInMissingContainer, Is.EqualTo("I don’t know how to look like that"));

    //     string[] cmdTooManyParams = { "look", "at", "gem", "in", "bag", "in", "box" };
    //     string resultTooManyParams = _testLookCommand.Execute(_testPlayer, cmdTooManyParams);
    //     Assert.That(resultTooManyParams, Is.EqualTo("I don’t know how to look like that"));

    //     string[] cmdWrongPreposition1 = { "look", "on", "gem" };
    //     string resultWrongPreposition1 = _testLookCommand.Execute(_testPlayer, cmdWrongPreposition1);
    //     Assert.That(resultWrongPreposition1, Is.EqualTo("What do you want to look at?"));

    //     string[] cmdWrongPreposition2 = { "look", "at", "gem", "on", "table" };
    //     string resultWrongPreposition2 = _testLookCommand.Execute(_testPlayer, cmdWrongPreposition2);
    //     Assert.That(resultWrongPreposition2, Is.EqualTo("What do you want to look in?"));

    //     string[] cmdNotLook = { "go", "at", "gem" };
    //     string resultNotLook = _testLookCommand.Execute(_testPlayer, cmdNotLook);
    //     Assert.That(resultNotLook, Is.EqualTo("Error in look input"));
    // }


}