using SwinAdventure;

namespace MainProgram
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Player _testPlayer;
            _testPlayer = new Player("James", "an explorer");

            Item item1 = new Item(new List<string> { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new List<string> { "light", "torch" }, "A Torch", "A Torch to light the path");

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            // Console.WriteLine(_testPlayer.AreYou("me"));
            // Console.WriteLine(_testPlayer.AreYou("inventory"));

            // if (_testPlayer.Locate("torch") != null)
            // {
            //     Console.WriteLine("The object torch exists");
            //     Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            // }
            // else
            // {
            //     Console.WriteLine("The object torch does not exist");
            // }

            // writer PlayerObject to file
            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }

            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                writer.Close();
            }

            List<IHaveInventory> myContainers = new List<IHaveInventory>();

            myContainers.Add(_testPlayer);

            Bag _testToolBag = new(new List<string> { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            Item item3 = new(new List<string> { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");

            _testToolBag.Inventory.Put(item3);
            myContainers.Add(_testToolBag);

            // Print description using polymorphism
            foreach (IHaveInventory container in myContainers)
            {
                Console.WriteLine($"Container: {container.Name}");
                GameObject found = container.Locate("stew");
                if (found != null)
                    Console.WriteLine($"Found item: {found.Name}");
                else
                    Console.WriteLine("Item not found.");
            }

            // 1.Get the player's name and description from the user, and use these details to create a
            // Player object.
            // 2.Create two items and add them to the the player's inventory
            // 3.Create a bag and add it to the player's inventory
            // 4.Create another item and add it to the bag
            // 5.Loop reading commands from the user, and getting the look command to execute them.



        }
    }
}
