using SwinAdventure;

public class BagTests
{
    private Bag _testToolBag;
    private Bag _testFoodBag;
    private Item _testItem1;
    private Item _testItem2;

    [SetUp]

    public void SetUp()
    {
        _testToolBag = new Bag(new List<string> { "TestToolBag" }, "TestToolBag", "TestToolBagDesc");
        _testFoodBag = new Bag(new List<string> { "TestFoodBag" }, "TestFoodBag", "TestFoodBagDesc");
        _testItem1 = new Item(new List<string> { "Item1" }, "TestItem1", "Item1Desc");
        _testItem2 = new Item(new List<string> { "Item2" }, "TestItem2", "Item2Desc");
        _testToolBag.Inventory.Put(_testItem1);
    }

    [Test]
    // Add items to the Bag, and locate the items in its inventory, this returns items the bag has and the item remains in the bag's inventory.
    public void BagLocatesItems()
    {
        // _testToolBag.Inventory.Put(_testItem1);
        Assert.That(_testToolBag.Locate("Item1"), Is.EqualTo(_testItem1));
    }
    [Test]
    // The bag returns itself if asked to locate one of its identifiers.
    public void BagLocatesItself()
    {
        Assert.That(_testToolBag.Locate("TestToolBag"), Is.EqualTo(_testToolBag));
    }
    [Test]
    // The bag returns a null/nil object if asked to locate something it does not have.
    public void BagLocatesNothing()
    {
        Assert.That(_testToolBag.Locate("Item3"), Is.Null);
    }
    [Test]
    // The bag's full description contains the text "In the <name> you can see:" and the short descriptions of the items the bag contains (from its inventory's item list)
    public void BagFullDescription()
    {
        _testToolBag.Inventory.Put(_testItem2);
        Assert.That(_testToolBag.FullDescription, Is.EqualTo("In the TestToolBag you can see:\nTestItem1 (Item1), TestItem2 (Item2)"));
    }
    [Test]
    // Create two Bag objects (b1, b2), put b2 in b1’s inventory. Test that b1 can locate b2. Test that b1 can locate other items in b1. Test that b1 can not locate items in b2.
    public void BagInBag()
    {
        _testToolBag.Inventory.Put(_testFoodBag);
        _testToolBag.Inventory.Put(_testItem1);
        _testFoodBag.Inventory.Put(_testItem2);
        Assert.That(_testToolBag.Locate("TestFoodBag"), Is.EqualTo(_testFoodBag));
        Assert.That(_testToolBag.Locate("Item1"), Is.EqualTo(_testItem1));
        Assert.That(_testToolBag.Locate("Item2"), Is.Null);
    }
    [Test]
    // Create two Bag objects (b1,b2), put b2 in b1's inventory. Put a privileged item into b2 by using PrivilegeEscalation method. Then, please test that b1 can not locate the privileged item in b2.
    public void BagPreviledItem()
    {
        _testToolBag.Inventory.Put(_testFoodBag);
        _testItem2.PrivilegeEscalation("5875");
        _testFoodBag.Inventory.Put(_testItem2);
        Assert.That(_testToolBag.Locate("Item2"), Is.Null);
    }
}