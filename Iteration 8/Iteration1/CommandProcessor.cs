namespace Iteration1
{
    public class CommandProcessor
    {
        Dictionary<string, Command> commands;

        public CommandProcessor()
        {
            commands = new Dictionary<string, Command>
            {
                {"look", new LookCommand() },
                {"move", new MoveCommand() },
                {"leave", new MoveCommand() },
                {"head", new MoveCommand() },
                {"go", new MoveCommand() }
            };
        }

        public string Process(Player p, string input)
        {
            string[] array = input.Split(" ");
            if (!commands.ContainsKey(array[0]))
            {
                return "Cannot find that command!\n";
            }
            else
            {
                Command _command = commands[array[0]];
                return _command.Execute(p, new string[] { input });
            }
        }
    }
}
