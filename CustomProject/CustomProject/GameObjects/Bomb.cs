namespace CustomProject.GameObjects
{
    public class CollectibleBomb : DrawableObject
    {
        public CollectibleBomb(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "bomb" }, "Bombs!!", "Do not touch the bombs!", "Bomb.png")
        {
        }
    }
}
