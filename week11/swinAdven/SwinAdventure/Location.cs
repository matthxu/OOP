using SwinAdventure;

public class Location : GameObject, IHaveInventory
{
    private Inventory _inventory;

    public Location(List<string> ids, string name, string desc) : base(ids, name, desc)
    {
        _inventory = new Inventory();
    }

    public Inventory Inventory
    {
        get { return _inventory; }
    }

    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        }
        else
        {
            if (Inventory.Fetch(id) == null)
            {
                Console.WriteLine($"{id} could not be found...");
                return null;
            }
            else
            {
                return Inventory.Fetch(id);
            }
        }
    }
    public override string FullDescription
    {
        get
        {
            string nameDescription;
            string inventoryDescription;

            if (Name != null && Name != "")
            {
                nameDescription = Name;
            }
            else
            {
                nameDescription = " an unknown location";
            }

            if (_inventory != null && _inventory.ItemList != null)
            {
                inventoryDescription = _inventory.ItemList;
            }
            else
            {
                inventoryDescription = "There are no items at this location.";
            }

            return "You are in " + nameDescription + ". " +
            base.FullDescription +
            "\nHere, you can see :\n" + inventoryDescription;
        }
    }
}