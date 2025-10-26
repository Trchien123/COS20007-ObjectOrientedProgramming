using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string description) : base(ids)
        {
            _description = description;
            _name = name;
        }

        public string Name
        {
            get => _name;
        }

        public string ShortDescription
        {
            get => $"a {Name} ({FirstId()})";
        }

        public virtual string FullDescription
        {
            get => _description;
        }
    }
}
