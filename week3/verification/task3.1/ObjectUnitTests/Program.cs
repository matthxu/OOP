public class IdentifiableObject 
{
    private List<string> _identifiers;
    // Constructor
    public IdentifiableObject(List<string> identifier) {
        _identifiers = identifier;
    }
    // Method
    public bool AreYou(string stringID) {
        stringID = stringID.ToLower();
        if (_identifiers.Contains(stringID)) {
            return true;
        } else {
            return false;
        }
    }
     // read only property
    public string FirstId
    {
        get { return _identifiers.Count > 0 ? _identifiers[0] : ""; }
    }
    // Methods
    public void AddIdentifier(string identifier) {
        _identifiers.Add(identifier.ToLower());
    }

    public void PrivilegeEscalation(string input) {
        string tutorialId = "#1";
        if (input == "5875") {
            _identifiers[0] = tutorialId;
        }
    }

    public void RemoveIdentifier(string identifier) {
        identifier.ToLower();
        if (_identifiers.Contains(identifier)) {
            _identifiers.Remove(identifier);
        }
    }
}

public class Program
{
    static void Main() {
        IdentifiableObject id = new IdentifiableObject(new List<string> {"5875", "Matthew", "Xu"});
        // Console.WriteLine($"ID: {id.AreYou("5875")}");
        // Console.WriteLine($"First ID: {id.FirstId}");
    }
}