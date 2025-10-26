using CustomProject.SingletonDesign;
using CustomProject.StrategyDesign;
namespace CustomProject.Observers
{
    public class HighJumpUnlocked : IObserver
    {
        public void Update(string eventType, Player player)
        {
            if (eventType == "JumpPotionCollected")
            {
                Console.WriteLine("Your jump ability has been increased for 3 seconds!");
                player.SetJumpStrategy(new HighJump());
                ClockSingleton.getInstance().StartTimer("highjump");
            }
        }
    }
}
