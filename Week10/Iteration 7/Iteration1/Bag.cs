using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
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

        public string Name
        {
            get => base.Name;
        }

        public override string FullDescription
        {
            get
            {
                string description = null;
                description += $"In the {this.Name} you can see:\n";
                description += _inventory.ItemList;
                return description;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}
