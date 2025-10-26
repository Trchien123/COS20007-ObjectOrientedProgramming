namespace CustomProject.GameObjects
{
    public class SpeedPotion : DrawableObject
    {
        public SpeedPotion(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "speed potion" }, "Speed Potion!!", "Increase speed !!", "speedpotion.png")
        {
        }
    }
}
