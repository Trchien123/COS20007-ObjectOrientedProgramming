using System.Runtime.InteropServices;

namespace Iteration1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Player name: ");
            string name = Console.ReadLine();
            Console.Write("Player description: ");
            string desc_ = Console.ReadLine();
            Player player = new Player(name, desc_);

            Item sword = new Item(new string[] { "sword" }, "sword", "Short range weapon!");
            Item ak47 = new Item(new string[] { "ak47" }, "ak47", "Average range weapon with high damage!");

            player.Inventory.Put(sword);
            player.Inventory.Put(ak47);

            Item grenade = new Item(new string[] { "grenade" }, "grenade", "Extreme damage and short range weapon!");
            Bag bag1 = new Bag(new string[] {"bag1"}, "bag1", "");
            bag1.Inventory.Put(grenade);
            player.Inventory.Put(bag1);

            Location location = new Location(new string[] { "military base" }, "military base", "large area");
            Path _northpath = new Path(new string[] { "north" }, "hospital", "this is a hospital");

            location.AddPath(_northpath);
            player.CurrentLocation = location;

            while (true)
            {
                Console.Write("Which look command do you want to execute: ");
                string command = Console.ReadLine();
                CommandProcessor selected_command = new CommandProcessor();
                string message = selected_command.Process(player, command);
                Console.WriteLine(message);
            }
        }
    }
}