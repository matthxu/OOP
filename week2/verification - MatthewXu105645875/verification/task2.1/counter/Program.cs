public class Clock
{
    private int _MinuteCounter;
    private int _SecondCounter;

    public int MinuteCounter
    {
        get { return _MinuteCounter; }
        set { _MinuteCounter = value; }
    }
    
    public int SecondCounter
    {
        get { return _SecondCounter; }
        set { _SecondCounter = value; }
    }


    public Clock()
    {
        _SecondCounter = 0;
        _MinuteCounter = 0;
    }

    public void Tick(){
        _SecondCounter += 1;
        if (_SecondCounter == 60) {
            _SecondCounter = 0;
            _MinuteCounter += 1;
        }
    }
    public void Display() {
        Console.WriteLine($"{MinuteCounter}:{SecondCounter}");
    }
}

public class Program
{
    static void Main () {
        Clock clock = new Clock();
        for (int i=0; i<=100; i++) {
            clock.Tick();
            clock.Display();
        }
    }
}