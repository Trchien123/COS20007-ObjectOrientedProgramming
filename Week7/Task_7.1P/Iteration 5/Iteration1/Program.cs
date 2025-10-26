namespace Iteration1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string desc_;
            string command;
            Item sword;
            Item ak47;
            Item grenade;

            Console.Write("Player name: "); 
            name = Console.ReadLine();
            Console.Write("Player description: ");
            desc_ = Console.ReadLine();
            Player player = new Player(name, desc_);

            sword = new Item(new string[] { "sword" }, "sword", "Short range weapon!");
            ak47 = new Item(new string[] { "ak47" }, "ak47", "Average range weapon with high damage!");

            player.Inventory.Put(sword);
            player.Inventory.Put(ak47);

            grenade = new Item(new string[] { "grenade" }, "grenade", "Extreme damage and short range weapon!");
            Bag bag1 = new Bag(new string[] {"bag1"}, "bag1", "");
            bag1.Inventory.Put(grenade);
            player.Inventory.Put(bag1);

            LookCommand player_command = new LookCommand();
            while (true)
            {
                Console.Write("Command -> ");
                command = Console.ReadLine();
                string message = player_command.Execute(player, new string[] { command });
                Console.WriteLine(message);
            }
        }
    }
}