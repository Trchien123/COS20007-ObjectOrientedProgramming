namespace QueueApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntegerQueue myQueue = new IntegerQueue();

            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);

            Console.WriteLine(myQueue.Count());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
        }
    }
}
