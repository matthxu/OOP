using AdventureItem;

namespace AdventureInventory
{
    public class Inventory
    {
        // field
        private List<Item> _Items;

        // constructor
        public Inventory(List<Item> Item) {
            _Items = Item;
        }

        // methods
        public bool HasItem(string id) {
            foreach(Item item in _Items) {
                item.AreYou(id);
                return true;
            }
            return false;
        }

        public void Put(Item itm) {
            _Items.Add(itm);
            Console.WriteLine($"Added {itm.Name} to the inventory!");
        }

        public Item? Take(string id) { // Item? (?) indicates call may return null; ie null is valid and no error warning
            foreach(Item item in _Items) {
                if (item.AreYou(id)) {
                    _Items.Remove(item);
                    return item;
                }
            }
            Console.WriteLine($"{id} could not be found...");
            return null; // can't return an Item object
        }

        public Item? Fetch(string id) {
            foreach(Item item in _Items) {
                if (item.AreYou(id)) {
                    return item;
                }
            }
            Console.WriteLine("Item could not be found");
            return null; // can't return an Item object
        }

        public Inventory RemoveItem(Item item)
        {
            if (_Items.Contains(item))
            {
                _Items.Remove(item);
                Console.WriteLine("Item removed");
            }
            else
            {
                Console.WriteLine($"{item.Name} could not be found...");
            }
            return this; // Return the updated inventory
        }

        public string ItemList
        {
            // for each loop to return list of all items in invent
            get 
            {
                // if (ItemList.Count() == 0) {
                //     return "Inventory is empty.";
                // }
                string AllItems = "";
                foreach (Item item in _Items) {
                    AllItems += $"{item.ShortDescription} \n";
                }
                return AllItems;
            }
        }
    }
}