namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand(List<string> ids) : base(ids)
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "look")
            {
                if (p.Location == null)
                {
                    return "Location cannot be found."; // null check
                }
                else
                {
                    return p.Location.FullDescription;
                }
            }
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0].ToLower() != "look")
                {
                    return "Error in look input";
                }
                if (text[1].ToLower() != "at")
                {
                    return "What do you want to look at?";
                }

                if (text.Length == 3)
                {
                    return LookAtIn(text[2], p);
                }
                else // path for 5 word commands
                {
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in?";
                    }
                    IHaveInventory container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return $"I cannot find the {text[4]}.";
                    }
                    return LookAtIn(text[2], container);
                }
            }
            else
            {
                return "I don't know how to look like that";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject item = p.Locate(containerId);

            if (item == null)
            {
                return null; // container not found
            }
            IHaveInventory container = item as IHaveInventory;

            return container;
        }


        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject itm = container.Locate(thingId);
            if (itm == null)
            {
                return "I can't find the " + thingId;
            }
            return itm.FullDescription;
        }
    }
}