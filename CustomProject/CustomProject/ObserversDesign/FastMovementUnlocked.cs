using CustomProject.SingletonDesign;
using CustomProject.StrategyDesign;
namespace CustomProject.Observers
{
    public class FastMovementUnlocked : IObserver
    {
        public void Update(string eventType, Player player)
        {
            if (eventType == "SpeedPotionCollected")
            {
                Console.WriteLine("Your speed has been increased for 3 seconds!");
                player.SetMovementStrategy(new FastMovement());
                ClockSingleton.getInstance().StartTimer("fastmovement");
            }
        }
    }
}
