using Iteration1;
using System.Numerics;

namespace LookCommandUnitTests
{
    public class Tests
    {
        private Player _player;
        private Inventory _inventory;
        private Item sword;
        private Item ak47;
        private Item gems;
        private Bag _bag;
        private LookCommand look;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "bag", "1" }, "Bag 1", "This is the 1st bag of the player!");
            _player = new Player("Chien", "A boy with high curiosity");
            _inventory = new Inventory();
            sword = new Item(new string[] { "sword", "melee" }, "bronze sword", "Melee weapon. High damage.");
            ak47 = new Item(new string[] { "ak47", "gun" }, "ak47", "Gun. High Damage.");
            gems = new Item(new string[] { "gem" }, " collectible gems", "Using for buying weapons");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(ak47);
            look = new LookCommand();
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.That((look.Execute(_player, new string[] { "look at inventory" })), Is.EqualTo(_player.FullDescription + "\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(gems);
            Assert.That((look.Execute(_player, new string[] { "look at gem" })), Is.EqualTo(gems.FullDescription + "\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookAtUnk()
        {
            Assert.That((look.Execute(_player, new string[] { "look at gem" })), Is.EqualTo("I cannot find the gem\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(gems);
            Assert.That((look.Execute(_player, new string[] { "look at gem in inventory" })), Is.EqualTo(gems.FullDescription + "\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _bag.Inventory.Put(gems);
            _player.Inventory.Put(_bag);
            Assert.That((look.Execute(_player, new string[] { "look at gem in bag" })), Is.EqualTo(gems.FullDescription + "\n"));
            Assert.Pass();
        }


        [Test]
        public void TestLookAtGemInNoBag()
        {
            _bag.Inventory.Put(gems);
            Assert.That((look.Execute(_player, new string[] { "look at gem in bag" })), Is.EqualTo("I cannot find the bag\n"));
            Assert.Pass();
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);
            Assert.That((look.Execute(_player, new string[] { "look at gem in bag" })), Is.EqualTo("I cannot find the gem in the bag\n"));
            Assert.Pass();
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That((look.Execute(_player, new string[] { "look around" })), Is.EqualTo("What do you want to look at?\n"));
            Assert.That((look.Execute(_player, new string[] { "hello" })), Is.EqualTo("Error in look input\n"));
            Assert.That((look.Execute(_player, new string[] { "look at gem a b" })), Is.EqualTo("What do you want to look in?\n"));
            Assert.Pass();
        }
    }
}