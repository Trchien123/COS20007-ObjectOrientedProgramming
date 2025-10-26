using static PowerArgs.Ansi.Cursor;

namespace Iteration1
{
    public class CommandProcessor : Command
    {
        List<Command> _commands;

        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            string[] array = text[0].Split(' ');
            foreach (Command command in _commands)
            {
                if (command.AreYou(array[0]))
                {
                    return command.Execute(p, new string[] { text[0] });
                }
            }
            return "Wrong command!!!";
        }
    }
}
