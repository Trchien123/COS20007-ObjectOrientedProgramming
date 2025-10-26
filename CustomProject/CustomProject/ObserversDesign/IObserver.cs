namespace CustomProject.Observers
{
    public interface IObserver
    {
        void Update(string eventType, Player player);
    }
}
