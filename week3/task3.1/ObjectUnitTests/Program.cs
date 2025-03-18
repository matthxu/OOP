public class IdentifiableObject 
{
    private List<string> _identifiers;
    // Constructor
    public IdentifiableObject(List<string> identifier) {
        _identifiers = identifier;
    }
    // Methods
    public bool AreYou(string stringID) {
        if (_identifiers.Contains(stringID)) {
            return true;
        } else {
            return false;
        }
    }
     // read only
    public string FirstId
    {
        get { return _identifiers.Count > 0 ? _identifiers[0] : ""; }
        // alternatively...
        // get
        // {
        //     if (_identifiers.Count > 0) {
        //         return _identifiers[0];
        //     } else {
        //         return ""; // return empty string if _identifiers empty
        //     }
        // }
    }
    public void AddIdentifier(string identifier) {
        _identifiers.Add(identifier.ToLower());
    }
    public void PrivilegeEscalation(string Id) {
        if (Id == "5875") {
            _identifiers[0] = Id;
        }
    }
    public void RemoveIdentifier(string identifier) {
        identifier.ToLower();
        if (_identifiers.Contains(identifier)) {
            _identifiers.Remove(identifier);
        }
    }
}