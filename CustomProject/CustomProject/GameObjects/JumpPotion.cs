namespace CustomProject.GameObjects
{
    public class JumpPotion : DrawableObject
    {
        public JumpPotion(double xLocation, double yLocation) : base(xLocation, yLocation, new string[] { "jump potion" }, "Jump Potion!!", "Increase jump !!", "jumppotion.png")
        {
        }
    }
}
