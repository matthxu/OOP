// OOP Task 2.1 / Matthew Xu


// Tell the Counter to increase the count value by 5. Does the code still run without
// any bugs/crash? What is the reason behind? You can provide the answers in the
// comments in your code

// No because the integer value of the counter has exceeded the range limit of the integer data type. We can use long instead of int for up to 64-bit signed integers.

public class Counter
{
    // fields
    // private ing _count;
    private long _count; // use long beacuse reset value exceeds range of int type
    private string _name;
    // properties; virtual fields
    public string Name
    {
        get { return _name; } // reading field
        set{ _name = value; } // setting to field
    }
    public long Ticks // use long beacuse reset value exceeds range of int type
    // public int Ticks
    {
        get { return _count; }
    }
    // constructor
    public Counter(string name) {
        _name = name;
        _count = 0;
    }
    //methods
    public void Increment() {
        _count += 5;
        Console.WriteLine($"{_name} increased to {_count}");
    }
    // public void Reset() {
    //     _count = 0;
    //     Console.WriteLine($"{_name} reset to {_count}");
    // }
    public void ResetByDefault() {
        _count = 214748365875; 
        Console.WriteLine($"{_name} reset to {_count}");
    }
}

public class Program 
{
    private static void PrintCounters(Counter[] counters) { // multiple objects so array is used
        foreach (Counter number in counters) { // Counter object specifically referenced otherwise class methods/fields inaccessible (ie. Counter number instead of Object number)
            Console.WriteLine($"{number.Name} is {number.Ticks}");
        }
    }
    static void Main() {
        Counter[] myCounters = new Counter[3]; // declare array of three Counter instance objects 
        myCounters[0] = new Counter("Counter 1"); // populating array
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0];
        for (int i = 0; i < 10; i++) {
            myCounters[0].Increment();
        }
        for (int i = 0; i < 15; i++) {
            myCounters[1].Increment();
        }
        PrintCounters(myCounters);
        myCounters[2].ResetByDefault();
        PrintCounters(myCounters);
    }
}