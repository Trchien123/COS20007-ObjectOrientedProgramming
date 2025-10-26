namespace CustomProject.Command
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            string thingId;
            string thing;
            Item item;
            string[] array = text[0].Split(" ");

            thingId = array[2];
            thing = LookAtIn(thingId, p);
            return $"{thing}\n";
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return null;
            }
            return container.Locate(thingId).FullDescription;
        }
    }
}