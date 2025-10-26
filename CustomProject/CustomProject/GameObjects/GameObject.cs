namespace CustomProject.GameObjects
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
            get => $"a {Name} ({FirstId()})\n";
        }

        public virtual string FullDescription
        {
            get => _description;
        }
    }
}
