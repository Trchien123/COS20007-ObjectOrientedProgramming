using CustomProject.GameObjects;

namespace CustomProject
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
