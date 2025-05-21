using SwinAdventure;

namespace MainProgram
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Player _testPlayer;
            // _testPlayer = new Player("James", "an explorer");

            // Item item1 = new Item(new List<string> { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            // Item item2 = new Item(new List<string> { "light", "torch" }, "A Torch", "A Torch to light the path");

            // _testPlayer.Inventory.Put(item1);
            // _testPlayer.Inventory.Put(item2);

            // // writer PlayerObject to file
            // StreamWriter writer = new StreamWriter("TestPlayer.txt");
            // try
            // {
            //     _testPlayer.SaveTo(writer);
            // }
            // finally
            // {
            //     writer.Close();
            // }

            // StreamReader reader = new StreamReader("TestPlayer.txt");
            // try
            // {
            //     _testPlayer.LoadFrom(reader);
            // }
            // finally
            // {
            //     writer.Close();
            // }

            // List<IHaveInventory> myContainers = new List<IHaveInventory>();

            // myContainers.Add(_testPlayer);

            // Bag _testToolBag = new(new List<string> { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            // Item item3 = new(new List<string> { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");

            // _testToolBag.Inventory.Put(item3);
            // myContainers.Add(_testToolBag);

            // // Print description using polymorphism
            // foreach (IHaveInventory container in myContainers)
            // {
            //     Console.WriteLine($"Container: {container.Name}");
            //     GameObject found = container.Locate("stew");
            //     if (found != null)
            //         Console.WriteLine($"Found item: {found.Name}");
            //     else
            //         Console.WriteLine("Item not found.");
            // }

            // 1.Get the player's name and description from the user, and use these details to create a
            // Player object.
            // 2.Create two items and add them to the the player's inventory
            // 3.Create a bag and add it to the player's inventory
            // 4.Create another item and add it to the bag
            // 5.Loop reading commands from the user, and getting the look command to execute them.
            Console.WriteLine("Welcome to SwinAdventure");
            Console.WriteLine("Who are you?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Tell me more about yourself...");
            string playerDesc = Console.ReadLine();
            Player newPlayer = new(playerName, playerDesc);
            Console.WriteLine($"Welcome {newPlayer.Name}");

            Location startingLocation = new Location(new List<string> { "spawn", "testChamber" }, "Dark Chamber", "A narrow, dimly lit chamber.");
            newPlayer.Location = startingLocation;
            Item sand = new(new List<string> { "junk", "sand" }, "Sand", "Yellow sand.");
            startingLocation.Inventory.Put(sand);

            Item donut = new(new List<string> { "food", "donut" }, "Donut", "A cinammon donut.");
            Item shoes = new(new List<string> { "clothes", "shoes" }, "Shoes", "An old pair of shoes.");

            newPlayer.Inventory.Put(donut);
            newPlayer.Inventory.Put(shoes);

            Bag rucksack = new(new List<string> { "bag", "rucksack" }, "Rucksack", "A large rucksack.");
            newPlayer.Inventory.Put(rucksack);

            Item persimmon = new(new List<string> { "food", "persimmon" }, "Persimmon", "A ripe persimmon.");
            rucksack.Inventory.Put(persimmon);

            bool finished = false;
            LookCommand cmd = new LookCommand(new List<string> { "" });
            while (!finished)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    finished = true;
                    break;
                }
                string[] split = command.Split(" ");
                Console.WriteLine(cmd.Execute(newPlayer, split));
            }

        }
    }
}
