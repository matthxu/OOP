using SwinAdventure;

namespace MainProgram
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Player _testPlayer;
            _testPlayer = new Player("James", "an explorer");

            Item item1 = new Item(new List<string> { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new List<string> { "light", "torch" }, "A Torch", "A Torch to light the path");

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            // Console.WriteLine(_testPlayer.AreYou("me"));
            // Console.WriteLine(_testPlayer.AreYou("inventory"));

            if (_testPlayer.Locate("torch") != null)
            {
                Console.WriteLine("The object torch exists");
                Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            }
            else
            {
                Console.WriteLine("The object torch does not exist");
            }

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
        }
    }
}