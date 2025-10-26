using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask
{
    public class Counter
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set => _name = value;
        }

        private int _count;
        public int Tick
        {
            get => _count;
        }

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }
        public int Increment()
        {
            return _count++;
        }
        public int Reset()
        {
            return _count = 0;
        }

    }
}
