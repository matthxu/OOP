namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        // field
        private Inventory _inventory;
        private Location _location;

        // property
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        // constructor
        public Player(string name, string desc) : base(new List<string> { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory(); // inventory initialised as empty with overloaded inventory constructor
        }

        // methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject itemInInvent = Inventory.Fetch(id);
            if (itemInInvent != null)
            {
                return itemInInvent;
            }
            else
            {
                return Location.Locate(id);
            }

        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + Inventory.ItemList;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(_inventory.ItemList);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string ItemDescriptionList = reader.ReadLine();

            Console.WriteLine("Player Information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);
        }
    }
}