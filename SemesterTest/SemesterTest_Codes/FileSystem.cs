namespace SemesterTest_104848770
{
    public class FileSystem
    {
        private List<Thing> _contents;

        public FileSystem()
        {
            _contents = new List<Thing>();
        }

        public void Add(Thing thing)
        {
            _contents.Add(thing);
        }

        public void PrintContents()
        {
            Console.WriteLine("This file system contains:\n");
            foreach (Thing thing in _contents)
            {
                thing.Print();
            }   
        }
    }
}
