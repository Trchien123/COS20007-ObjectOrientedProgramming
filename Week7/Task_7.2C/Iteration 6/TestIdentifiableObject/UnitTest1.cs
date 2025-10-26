using Iteration1;

namespace TestIdentifiableObject
{
    public class Tests
    {
        private IdentifiableObject myObject;

        [SetUp]
        public void SetUp()
        {
            myObject = new IdentifiableObject(new string[] { "fred", "bob" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.That(myObject.AreYou("bob"), Is.EqualTo(true));
            Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));

            Assert.Pass();
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.That(myObject.AreYou("wilma"), Is.EqualTo(false));
            Assert.That(myObject.AreYou("boby"), Is.EqualTo(false));

            Assert.Pass();
        }

        [Test]
        public void TestCaseSentive()
        {
            Assert.That(myObject.AreYou("FRED"), Is.EqualTo(true));
            Assert.That(myObject.AreYou("bOB"), Is.EqualTo(true));

            Assert.Pass(); 
        }

        [Test]
        public void TestFirstId()
        {
            Assert.That(myObject.FirstId(), Is.EqualTo("fred"));

            Assert.Pass();
        }

        [Test]
        public void TestFirstIdWithoutIDs()
        {
            IdentifiableObject myObject = new IdentifiableObject(new string[] { });

            Assert.That(myObject.FirstId(), Is.EqualTo(""));

            Assert.Pass();
        }

        [Test]
        public void TestAddId()
        {
            myObject.AddIdentifier("wilma");

            Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));
            Assert.That(myObject.AreYou("bob"), Is.EqualTo(true));
            Assert.That(myObject.AreYou("wilma"), Is.EqualTo(true));

            Assert.Pass();
        }
    }
}