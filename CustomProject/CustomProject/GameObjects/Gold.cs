namespace CustomProject.GameObjects
{
    public class CollectibleGold : DrawableObject
    {
        public CollectibleGold(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "gold" }, "Golds!!", "Collect golds to win the game!!", "Gold.png")
        {
        }
    }
}