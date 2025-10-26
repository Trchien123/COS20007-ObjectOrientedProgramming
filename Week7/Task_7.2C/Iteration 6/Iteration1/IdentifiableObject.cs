namespace Iteration1
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }
        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            return false;
        }
        public string FirstId()
        {
            if (_identifiers.Any())
            {
                return _identifiers.First();
            }
            return "";
        }
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
