using Iteration1;
using static PowerArgs.Ansi.Cursor;
using Path = Iteration1.Path;

namespace CommandProcessorUnitTest
{
    public class Tests
    {
        private CommandProcessor _command; 
        private Player _player;
        private Location _location;
        private Item _sword;
        private Item _ak47;
        private Item _grenade;
        private Path _northpath;

        [SetUp]
        public void Setup()
        {
            _command = new CommandProcessor();
            _player = new Player("Chien", "A boy with high curiosity");
            _location = new Location(new string[] { "military base" }, "military base", "large area");
            _sword = new Item(new string[] { "sword", "melee" }, "sword", "Short range weapon");
            _ak47 = new Item(new string[] { "ak47" }, "ak47", "Long range weapon");
            _grenade = new Item(new string[] { "grenade" }, "grenade", "Very high damage weapon!");
            _location.Inventory.Put(_sword);
            _location.Inventory.Put(_ak47);
            _player.CurrentLocation = _location;
            _northpath = new Path(new string[] { "north" }, "hospital", "this is a hospital");
            _location.AddPath(_northpath);
        }

        [Test]
        public void TestMoveCommand()
        {
            Assert.That(_command.Execute(_player, ["move north"]), Is.EqualTo("You have moved to hospital\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookCommand()
        {
            Assert.That(_command.Execute(_player, ["look at me"]), Is.EqualTo(_player.FullDescription + "\n"));
            Assert.Pass();
        }

        [Test]
        public void TestWrongCommand()
        {
            Assert.That((_command.Execute(_player, new string[] { "look around" })), Is.EqualTo("What do you want to look at?\n"));
            Assert.That(_command.Execute(_player, new string[] { "run north" }), Is.EqualTo("Wrong command!!!"));
            Assert.That(_command.Execute(_player, new string[] { "hello" }), Is.EqualTo("Wrong command!!!"));
            Assert.Pass();
        }
    }
}