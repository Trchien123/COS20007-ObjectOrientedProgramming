using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            string containerId;
            string thingId;
            string thing;
            IHaveInventory container;
            Item item;
            string[] array = text[0].Split(" ");
            
            if (array[0] != "look")
            {
                return "Error in look input\n";
            }

            if (array[1] != "at")
            {
                return "What do you want to look at?\n";       
            }

            if (array.Length == 5)
            {
                if (array[3] != "in")
                {
                    return "What do you want to look in?\n";
                }
                else
                {
                    thingId = array[2];
                    containerId = array[4];
                    container = FetchContainer(p, containerId);
                    if (container != null)
                    {
                        thing = LookAtIn(thingId, container);
                        if (thing != null)
                        {
                            return $"{thing}\n";
                        }
                        else
                        {
                            return $"I cannot find the {thingId} in the {containerId}\n";
                        }
                    }
                    else
                    {
                        return $"I cannot find the {containerId}\n";
                    }
                }
            }
            else if (array.Length == 3)
            {
                thingId = array[2];
                thing = LookAtIn(thingId, p);
                if (thing != null)
                {
                    return $"{thing}\n";
                }
                else
                {
                    return $"I cannot find the {thingId}\n";
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.Locate(containerId) == null)
            {
                return null;
            }
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return null;
            }
            return container.Locate(thingId).FullDescription;
        }
    }
   
}
