namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        // field
        private Inventory _inventory;

        // constructor
        public Bag(List<string> ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        // properties
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get { return "In the " + Name + " you can see:\n" + Inventory.ItemList; }
        }

        // methods 
        public GameObject Locate(string id)
        {
            // return 
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }


    }
}