using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Path : GameObject
    {
        public Path(string[] ids, string destination, string desc) : base(ids, destination, desc)
        {

        }
        
        public string Move(Player player)
        {
            string id = this.Destination;
            string destination = this.Destination;
            string desc = this.Description;
            Location newLocation = new Location(new string[] { id }, destination, desc);
            player.CurrentLocation = newLocation;
            return $"You have moved to {destination}\n";
        }

        public string Description
        {
            get => base.FullDescription;
        }

        public string Direction
        {
            get => base.FirstId();
        }

        public string Destination
        {
            get => base.Name;
        }
    }
}
