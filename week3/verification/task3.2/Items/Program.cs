public class Items
{
    // private fields
    private List<string> _identifiers;
    private string _description;
    private string _name;

    //constructor
    public Items(List<string> identifier, string desc, string title) {
        _identifiers = identifier;
        _description = desc;
        _name = title;
    }

    // public fields
    public string Name
    {
        get { return _name; }
    }
    public string ShortDescription
    {
        get { return $"{_name} ({_identifiers[0]})"; }
    }
    public string LongDescription
    {
        get { return _description; }
    }
    public List<string> Identifier
    {
        get { return _identifiers; }
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
    // 3.2 code:
    // public void RemoveIdentifier(string id) {
    //     id = id.ToLower();
    //     if (_identifiers.Contains(id)) {
    //         _identifiers.Remove(id);
    //     } else {
    //         Console.WriteLine($"{id} doesn't exist...");
    //     }
    // }
    public void PrivilegeEscalation(string pin) {
        if (pin == "5875") {
            _identifiers[0] = "#1"; // Tutorial ID = #1
        }
    }

    public bool RemoveIdentifier (string id) {
        if (id != "") {
            id = id.ToLower();
        } else {
            Console.WriteLine("Please enter a valid item");
            return false;
        }
        if (_identifiers.Contains(id)) {
            _identifiers.Remove(id);
            Console.WriteLine($"{id} removed.");
            return true;
        } else {
            Console.WriteLine($"{id} does not exist.");
            return false;
        }
    }

    public void AddItem (string id) {
        if (_identifiers.Contains(id)) {
            Console.WriteLine($"{id} already exists.");
        } else {
            Console.WriteLine($"{id} added.");
            _identifiers.Add(id);
        }
    }
}

public class Program
{
    static void Main() {
        Items item = new Items(new List<string> {}, "description", "name");
    }
}