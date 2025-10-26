using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in  _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }

        public Item Take(string id)
        {
            Item a = Fetch(id);
            _items.Remove(a);
            return a;
        }

        public string ItemList
        {
            get
            {
                string list = "";
                foreach (Item itm in _items)
                {
                    list += "\t" + itm.ShortDescription + "\n";
                }
                return list;
            }
        }

    }
}
