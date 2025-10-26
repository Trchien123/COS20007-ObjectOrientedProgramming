using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class MoveCommand : Command
    {
        private List<string> _directions;
        private List<string> _identifiers;

        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
            _directions = new List<string> { "north", "west", "south", "east"};
            _identifiers = new List<string> { "move", "head", "go", "leave" };
        }

        public override string Execute(Player p, string[] text)
        {
            string[] array = text[0].Split(" ");
            if (array.Length != 2)
            {
                return "Wrong command input!\n";
            }
            else if (!_directions.Contains(array[1]) || !_identifiers.Contains(array[0]))
            {
                return "Wrong command input!\n";
            }
            else
            {
                if (p.CurrentLocation.Locate(array[1]) == null)
                {
                    return "There is not that path in this location!\n";
                }
                else
                {
                    Path selected_path = p.CurrentLocation.Paths[array[1]];
                    return selected_path.Move(p);
                }
            }
        }
    }
}
