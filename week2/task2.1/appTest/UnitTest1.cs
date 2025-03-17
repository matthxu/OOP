// [OOP] Task 2.2 | Matthew Xu

using System.Diagnostics.Metrics;
namespace appTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void CheckStartCount()
    {
        Counter countNum = new Counter("TestCounter"); // create new instance of Counter
        Assert.That(countNum.Ticks, Is.EqualTo(0)); // check starting count is 0.
    }

    [Test]
    public void CheckIncrements() 
    {
        Counter testNum = new Counter("IncrementTester");
        testNum.Increment(); // call increment method
        Assert.That(testNum.Ticks, Is.EqualTo(5)); // if increment is 5
    }

    [Test]
    public void CheckResetValue() 
    {
        Counter resetNum = new Counter("TestResetter");
        resetNum.ResetByDefault(); // call on reset method
        Assert.That(resetNum.Ticks, Is.EqualTo(214748365875)); // check reset method produces expected long
    }
}
