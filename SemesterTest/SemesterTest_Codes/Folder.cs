namespace SemesterTest_104848770
{
    public class Folder : Thing
    {
        private List<Thing> _contents;
        private string _name;

        public Folder(string name) : base(name)
        {
            _contents = new List<Thing>();
            _name = name;
        }

        public void Add(Thing thing)
        {
            _contents.Add(thing);
        }

        public override int Size()
        {
            int size = 0;
            foreach (Thing thing in _contents)
            {
                size += thing.Size();
            }
            return size;
        }

        public override void Print()
        {
            if (Size() == 0)
            {
                Console.WriteLine($"The folder '{Name}' is empty!");
            }
            else
            {
                Console.WriteLine($"The folder '{Name}' contains {Size()} bytes in total:\n");
                foreach (Thing thing in _contents)
                {
                    thing.Print();
                }
            }
        }
    }
}
