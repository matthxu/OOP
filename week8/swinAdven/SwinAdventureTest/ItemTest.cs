public class Tests
{
    ///////////////////////////// ITEM UNIT TESTS /////////////////////////////
    [Test]
    public void TestItemIdentifiable()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Assert.That(testItem.AreYou("TestId"), Is.True);
    }
    [Test]
    public void ShortDescription()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Assert.That(testItem.ShortDescription, Is.EqualTo("TestName - TestId"));
    }
    [Test]
    public void FullDescription()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        Assert.That(testItem.FullDescription, Is.EqualTo("TestDescription"));
    }
    [Test]
    public void PrivilegeEscalation()
    {
        Item testItem = new Item(new List<string> { "TestId" }, "TestName", "TestDescription");
        testItem.PrivilegeEscalation("5875");
        Assert.That(testItem.firstId, Is.EqualTo("#1"));
    }

}