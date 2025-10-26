using Iteration1;
using Path = Iteration1.Path;

namespace TestMoveCommand
{
    public class Tests
    {
        private Player _player;
        private Location _location;
        private Item _sword;
        private Item _ak47;
        private Item _grenade;
        private Path _northpath;
        private MoveCommand _move;

        [SetUp]
        public void Setup()
        {
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
            _move = new MoveCommand();
        }

        [Test]
        public void TestPathMovesPlayer()
        {
            _northpath.Move(_player);
            Assert.That(_player.CurrentLocation.Name, Is.EqualTo(_northpath.Destination));
            Assert.Pass();
        }

        [Test]
        public void TestGetPathFromLocation()
        {
            string id = "north";
            Assert.That(_location.Locate(id), Is.EqualTo(_northpath));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerLeaveLocation()
        {
            Assert.That(_move.Execute(_player, new string[] { "move north" }), Is.EqualTo($"You have moved to {_northpath.Destination}\n"));
            _player.CurrentLocation = _location;
            Assert.That(_move.Execute(_player, new string[] { "leave north" }), Is.EqualTo($"You have moved to {_northpath.Destination}\n"));
            _player.CurrentLocation = _location;
            Assert.That(_move.Execute(_player, new string[] { "go north" }), Is.EqualTo($"You have moved to {_northpath.Destination}\n"));
            _player.CurrentLocation = _location;
            Assert.That(_move.Execute(_player, new string[] { "head north" }), Is.EqualTo($"You have moved to {_northpath.Destination}\n"));
            Assert.Pass();
        }

        [Test]
        public void TestWrongCommand()
        {
            Assert.That(_move.Execute(_player, new string[] { "run north" }), Is.EqualTo($"Wrong command input!\n"));
            Assert.That(_move.Execute(_player, new string[] { "go home" }), Is.EqualTo($"Wrong command input!\n"));
            Assert.That(_move.Execute(_player, new string[] { "move south" }), Is.EqualTo("There is not that path in this location!\n"));
            Assert.Pass();
        }

        [Test]
        public void TestNotMoveWithUnvalidPath()
        {
            _move.Execute(_player, new string[] { "go home" });
            _move.Execute(_player, new string[] { "move south" });
            Assert.That(_player.CurrentLocation, Is.EqualTo(_location));
            Assert.Pass();
        }
    }
}