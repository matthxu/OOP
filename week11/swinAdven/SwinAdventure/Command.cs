using SwinAdventure;

public abstract class Command : IdentifiableObject
{
    public Command(List<string> ids) : base(ids)
    {
    }
    public abstract string Execute(Player p, string[] text);
}
