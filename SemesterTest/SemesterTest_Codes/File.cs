namespace SemesterTest_104848770
{
    public class File : Thing 
    {
        private string _name;
        private string _extension;
        private int _size;

        public File(string name, string extension, int size) : base(name)
        {
            _name = name;
            _extension = extension;
            _size = size;
        }

        public override int Size()
        {
            return _size;
        }

        public override void Print()
        {
            Console.WriteLine($"File '{Name}' -- {Size()} bytes\n");
        }

        public string Name
        {
            get => _name + _extension;
        }
    }
}
