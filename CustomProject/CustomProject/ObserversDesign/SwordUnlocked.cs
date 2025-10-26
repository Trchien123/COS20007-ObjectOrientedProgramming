namespace CustomProject.Observers
{
    public class SwordUnlocked : IObserver
    {
        public void Update(string eventType, Player player)
        {
            if (eventType == "SwordUnlocked")
            {
                Console.WriteLine($"\nYou are now able to collect Sword and the Potions!\n");
            }
        }
    }
}
