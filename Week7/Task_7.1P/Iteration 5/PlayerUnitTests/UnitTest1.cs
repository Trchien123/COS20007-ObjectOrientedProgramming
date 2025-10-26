using Iteration1;

namespace PlayerUnitTests
{
    public class Tests
    {
        Player player;
        Item sword;
        Item ak47;

        [SetUp]
        public void Setup()
        {
            player = new Player("Chien", "A boy with high curiosity.");
            sword = new Item(new string[] { "sword", "melee" }, "bronze sword", "Melee weapon. High damage.");
            ak47 = new Item(new string[] { "ak47", "gun" }, "ak47", "Gun. High Damage.");
            player.Inventory.Put(sword);
            player.Inventory.Put(ak47);
        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.That(player.AreYou("inventory"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerLocatesItem()
        {
            Assert.That(player.Locate("sword"), Is.EqualTo(sword));
            Assert.That(player.Inventory.HasItem("sword"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(player.Locate("inventory"), Is.EqualTo(player));
            Assert.That(player.Locate("me"), Is.EqualTo(player));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(player.Locate("machine gun"), Is.EqualTo(null));
            Assert.Pass();
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(player.FullDescription, Is.EqualTo("You are Chien, A boy with high curiosity.\nYou are carrying\n\ta bronze sword (sword)\n\ta ak47 (ak47)\n"));
            Assert.Pass();
        }
    }
}