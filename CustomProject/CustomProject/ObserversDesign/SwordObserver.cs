namespace CustomProject.Observers
{
    public class SwordObserver : IObserver
    {
        public void Update(string eventType, Player player)
        {
            if (eventType == "SwordCollected")
            {
                Console.WriteLine($"Swords collected: {player.CollectedSwords}");
            }
        }
    }
}
