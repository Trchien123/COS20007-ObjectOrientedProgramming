using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
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
            return null;
        }

        public override string FullDescription
        {
            get
            {
                string fulldesc = "";
                fulldesc += $"You are {Name}, {base.FullDescription}\n";
                fulldesc += "You are carrying\n";
                fulldesc += $"{_inventory.ItemList}";
                return fulldesc;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}
