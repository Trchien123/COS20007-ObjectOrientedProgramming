using Iteration1;

namespace ItemUnitTests
{
    public class Tests
    {
        Item itm;
        [SetUp]
        public void Setup()
        {
            itm = new Item(new string[] {"sword", "great"}, "bronze sword", "Melee weapon. High damage.");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.That(itm.AreYou("sword"), Is.EqualTo(true));
            Assert.Pass();
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(itm.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
            Assert.Pass();
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(itm.FullDescription, Is.EqualTo("Melee weapon. High damage."));
            Assert.Pass();
        }
    }
}