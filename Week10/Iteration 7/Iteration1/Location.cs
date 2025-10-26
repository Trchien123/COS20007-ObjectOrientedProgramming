using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Dictionary<string, Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Path>();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }

            foreach (Path p in _paths.Values)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }

            return null;
        }

        public void AddPath(Path path)
        {
            string direction = path.Direction;
            _paths.Add(direction, path);
        }

        public Dictionary<string, Path> Paths
        {
            get => _paths;
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

        public string Description
        {
            get => base.FullDescription;
        }
    }
}
