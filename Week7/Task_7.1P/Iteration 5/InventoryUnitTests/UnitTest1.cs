using Iteration1;

namespace InventoryUnitTests
{
    public class Tests
    {
        Inventory ivt;
        Item sword;
        Item ak47;

        [SetUp]
        public void Setup()
        {
            ivt = new Inventory();
            sword = new Item(new string[] { "sword", "melee" }, "bronze sword", "Melee weapon. High damage.");
            ak47 = new Item(new string[] { "ak47", "gun" }, "ak47", "Gun. High Damage.");
            ivt.Put(sword);
            ivt.Put(ak47);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.That(ivt.HasItem("sword"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.That(ivt.HasItem("machine gun"), Is.EqualTo(false));
            Assert.Pass();
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.That(ivt.Fetch("sword"), Is.EqualTo(sword));
            Assert.That(ivt.HasItem("sword"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.That(ivt.Take("ak47"), Is.EqualTo(ak47));
            Assert.That(ivt.HasItem("ak47"), Is.EqualTo(false));
            Assert.Pass();
        }

        [Test]
        public void TestItemList()
        {
            Assert.That(ivt.ItemList, Is.EqualTo("\ta bronze sword (sword)\n\ta ak47 (ak47)\n"));
            Assert.Pass();
        }
    }
}