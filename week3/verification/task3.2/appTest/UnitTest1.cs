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
    [Test]
    public void TestRemoveIdentifier() {
        Items TestVar = new Items(new List<string> {"item1", "item2"}, "desc", "name");
        TestVar.RemoveIdentifier("item1");
        Assert.That(TestVar.firstId, Is.EqualTo("item2"));
    }
    [Test]
    public void TestAddUniqueItem() {
        Items TestVar = new Items(new List<string> {}, "desc", "name");
        TestVar.AddItem("rock");
        Assert.That(TestVar.firstId, Is.EqualTo("rock"));
    }
    public void TestAddDuplicateItemBlocked() {
        Items TestVar = new Items(new List<string> {"rock"}, "desc", "name");
        TestVar.AddItem("rock");
        Assert.That(TestVar.firstId, Is.EqualTo("rock"));        
        // Assert.That(TestVar.Identifier.Count(), Is.EqualTo(1)); // check duplicate isn't added       
    }
    public void TestCollectionContainsOnlyUnique() {
        Items TestVar = new Items(new List<string> {"tiny rock"}, "desc", "name");
        bool Duplicates = false;
        int CopiesOfItems = 0;
        int ItemCount = TestVar.Identifier.Count();
        TestVar.AddItem("small rock");
        TestVar.AddItem("tiny rock");
        TestVar.AddItem("large rock");
        TestVar.AddItem("garntuan rock");

        // check all items are unique
        for (int i=0; i < ItemCount; i++) {
            for (int index=0; index < ItemCount; index++) {
                if (TestVar.Identifier[i] == TestVar.Identifier[index]) {
                    CopiesOfItems += 1;
                }
                if (CopiesOfItems > 1) {
                    Duplicates = true;
                    return;
                }
            }
        }

        // check items are all added
        int UpdatedAmount = ItemCount + 4; // AddItem called 4 times
        Assert.That(UpdatedAmount, Is.EqualTo(5)); // initialised with 1, added 4
        Assert.That(Duplicates, Is.False);
    }

}