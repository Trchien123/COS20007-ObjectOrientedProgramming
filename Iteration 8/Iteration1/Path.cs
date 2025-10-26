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
