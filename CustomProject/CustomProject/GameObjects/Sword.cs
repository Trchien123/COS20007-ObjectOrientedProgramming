namespace CustomProject.GameObjects
{
    public class Sword : DrawableObject
    {
        public Sword(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "sword" }, "Metal Sword!", "Meelee weapons!", "sword.png")
        {
        }
    }
}