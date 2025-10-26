using Iteration1;

namespace TestLocations
{
    public class Tests
    {
        Player _player;
        Location _location;
        Item _sword;
        Item _ak47;
        Item _grenade;

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
        }

        [Test]
        public void TestLocationLocatesItself()
        {
            Assert.That(_location.Locate("military base"), Is.EqualTo(_location));
            Assert.Pass();
        }

        [Test]
        public void TestLocationLocatesItem()
        {
            Assert.That(_location.Locate("sword"), Is.EqualTo(_sword));
            Assert.Pass();
        }

        [Test]
        public void TestLocationLocatesNothing()
        {
            Assert.That(_location.Locate("grenade"), Is.EqualTo(null));
            Assert.Pass();
        }

        [Test]
        public void TestPLayerLocatesItemInLocation()
        {
            Assert.That(_player.Locate("ak47"), Is.EqualTo(_ak47));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerLocatesNothingInLocation()
        {
            Assert.That(_player.Locate("grenade"), Is.EqualTo(null));
            Assert.Pass();
        }
    }
}