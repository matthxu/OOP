using AdventureGameObject;

namespace AdventureItem
{
    public class Item : GameObject
    {
        //constructor
        public Item(List<string> identifiers, string name, string description) : base(identifiers, name, description) {}
    }
    
    public class Program
    {
        public static void Main() {
            Console.WriteLine("running...");
        }
    }

}