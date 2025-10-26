namespace CustomProject.Observers
{
    public class ScoreObserver : IObserver
    {
        private int _score;

        public void Update(string eventType, Player player)
        {
            if (eventType == "GoldCollected")
            {
                _score = player.CollectedGolds * 10;
                Console.WriteLine($"Score updated: {_score}");
            }
        }
    }
}
