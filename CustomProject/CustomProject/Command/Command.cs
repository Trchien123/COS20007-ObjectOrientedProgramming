namespace CustomProject.Command
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(new string[] { "command" })
        {

        }

        public abstract string Execute(Player p, string[] text);
    }
}
