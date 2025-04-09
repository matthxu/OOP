using AdventureGameObject;
using AdventureInventory;
using AdventureItem;

namespace appTest;

public class Tests
{
    [Test]
    public void TestFindItem()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> { testItem });
        Assert.That(inventory.HasItem("TestItem"), Is.True);
    }

    [Test]
    public void TestNoFindItem()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> {});
        Assert.That(inventory.HasItem("UnknownItem"), Is.False);
    }

    [Test]
    public void TestFetchItem()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> { testItem });
        Item fetchedItem = inventory.Fetch("TestId");
        Assert.That(fetchedItem, Is.EqualTo(testItem));
    }
    [Test]
    public void TestTakeItem()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> { testItem });
        Item takenItem = inventory.Take("TestId");
        Assert.That(inventory.HasItem("TestId"), Is.False);
    }
    [Test]
    public void TestItemList()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> { testItem });
        Assert.That(inventory.ItemList, Is.EqualTo("TestName - TestId \n"));
    }
    [Test]
    public void TestRemoveItem()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Inventory inventory = new Inventory(new List<Item> { testItem });
        inventory.RemoveItem(testItem);
        Assert.That(inventory.HasItem("TestId"), Is.False);
    }
}
