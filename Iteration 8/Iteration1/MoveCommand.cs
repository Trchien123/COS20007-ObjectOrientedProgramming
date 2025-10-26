using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class MoveCommand : Command
    {
        List<string> directions;
        List<string> identifiers;

        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
            directions = new List<string> { "north", "west", "south", "east"};
            identifiers = new List<string> { "move", "head", "go", "leave" };
        }

        public override string Execute(Player p, string[] text)
        {
            string[] array = text[0].Split(" ");
            try
            {
                if (array.Length != 2)
                {
                    return "Wrong command input!\n";
                }
                else if (!directions.Contains(array[1]) || !identifiers.Contains(array[0]))
                {
                    return "Where do you want to go?\n";
                }
                else
                {
                    Path selected_path = p.CurrentLocation.Paths[array[1]];
                    string id = selected_path.Destination;
                    string destination = selected_path.Destination;
                    string desc = selected_path.Description;
                    Location newLocation = new Location(new string[] { id }, destination, desc);
                    p.CurrentLocation = newLocation;
                    return $"You have moved to {destination}\n";
                }
            }
            catch (Exception e)
            {
                return "There is not that path in this room!\n";
            }
        }
    }
}
