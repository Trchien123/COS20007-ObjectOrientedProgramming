using Iteration1;
using System.Numerics;

namespace BagUnitTests
{
    public class Tests
    {
        Bag bag1;
        Bag bag2;
        Item sword;
        Item ak47;
        Item machine_gun;

        [SetUp]
        public void Setup()
        {
            bag1 = new Bag(new string[] { "bag1", "1" }, "Bag 1", "This is the 1st bag of the player!");
            sword = new Item(new string[] { "sword", "melee" }, "bronze sword", "Melee weapon. High damage.");
            ak47 = new Item(new string[] { "ak47", "gun" }, "ak47", "Gun. High Damage.");
            bag1.Inventory.Put(sword);
            bag1.Inventory.Put(ak47);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.That(bag1.Locate("sword"), Is.EqualTo(sword));
            Assert.That(bag1.Inventory.HasItem("sword"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(bag1.Locate("bag1"), Is.EqualTo(bag1));
            Assert.Pass();
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(bag1.Locate("machine gun"), Is.EqualTo(null));
            Assert.Pass();
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.That(bag1.FullDescription, Is.EqualTo($"In the {bag1.Name} you can see:\n    a bronze sword (sword)\n    a ak47 (ak47)\n"));
            Assert.Pass();
        }

        [Test]
        public void TestBagInBag()
        {
            bag2 = new Bag(new string[] { "bag2", "2" }, "Bag 2", "This is the 2nd part of the player!");
            machine_gun = new Item(new string[] { "machine gun", "super gun" }, "machine gun", "this is a weapon having lots of bullets");
            bag2.Inventory.Put(machine_gun);

            bag1.Inventory.Put(bag2);
            Assert.That(bag1.Locate("bag2"), Is.EqualTo(bag2));
            Assert.That(bag1.Locate("ak47"), Is.EqualTo(ak47));
            Assert.That(bag1.Locate("machine gun"), Is.EqualTo(null));
            Assert.Pass();

        }
    }
}