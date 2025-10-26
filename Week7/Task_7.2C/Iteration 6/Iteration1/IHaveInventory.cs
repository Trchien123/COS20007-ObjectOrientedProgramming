using System;
using System.Collections.Generic;
using System.Linq;
namespace Iteration1
{
    interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name
        {
            get => Name;
        }
    }
}
