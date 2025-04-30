namespace SwinAdventure
{
    public class Player : GameObject
    {
        // field
        private Inventory _inventory;

        // property
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        // constructor
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        // methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return Inventory.Fetch(id);
            }

        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + Inventory.ItemList;
            }
        }

    }
}