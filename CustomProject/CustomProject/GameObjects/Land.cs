namespace CustomProject.GameObjects
{
    public class Land : DrawableObject
    {
        public Land(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "" }, "", "", "land.png")
        {
        }
    }
}