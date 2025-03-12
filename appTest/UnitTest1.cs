using HelloWorld;

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
    public void Test2()
    {
        Message myMessage = new("This is the default message");
        myMessage.Print();
        string currentContent = myMessage.getMessage();
        Assert.That(currentContent, Is.EqualTo("This is the default message"));
    }
}
