using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            try
            {
                if (AreYou(id))
                {
                    return this;
                }
                else if (_inventory.HasItem(id))
                {
                    return _inventory.Fetch(id);
                }
                else if (_location.Inventory.HasItem(id))
                {
                    return _location.Locate(id);
                }
            }
            catch (Exception e)
            {
                return null;
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

        public Location CurrentLocation
        {
            get => _location;
            set => _location = value;
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}
