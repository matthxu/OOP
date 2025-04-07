using AdventureInventory;

namespace AdventureGameObject
{
    public abstract class GameObject // abstract classes cannot be instantiated directly, but inherited by its subclasses
    {
        // fields
        protected string _description; // protected - classes deriving from this class can access
        protected string _name;
        protected List<string> _identifiers;
        
        // constructor
        public GameObject(List<string> identifiers, string name, string description) {
            _name = name;
            _description = description;
            _identifiers = identifiers;
        }

        // methods
        public bool AreYou(string id) {
            return _identifiers.Contains(id) ? true : false;
        }
        public string firstId {
            get { return _identifiers.Count > 0 ? _identifiers[0] : ""; }
        }
        public void addIdentifier(string id) {
            id = id.ToLower();
            _identifiers.Add(id);
        }
        public void RemoveIdentifier(string id) {
            id = id.ToLower();
            if (_identifiers.Contains(id)) {
                _identifiers.Remove(id);
            } else {
                Console.WriteLine($"{id} doesn't exist...");
            }
        }
        public void PrivilegeEscalation(string pin) {
            if (pin == "5875") {
                _identifiers[0] = "#1"; // Tutorial ID = #1
            }
        }

        // properties
        public string Name 
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return $"{_name} - {firstId}"; }
        }

        public virtual string FullDescription // virtual methods can only be overridden by using override command
        {
            get { return _description; }
        }

        public int IdentifierCount
        {
            get { return _identifiers.Count(); }
        }

    }
}
