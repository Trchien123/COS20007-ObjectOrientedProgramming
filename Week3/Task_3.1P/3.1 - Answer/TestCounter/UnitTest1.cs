using CounterTask;

namespace TestCounter
{
    public class Tests
    {
        private Counter myCounter;

        [SetUp]
        public void Setup()
        {
            myCounter = new Counter("My Counter");
        }

        [Test]
        public void TestIncrement()
        {
            myCounter.Increment();

            Assert.That(myCounter.Tick, Is.EqualTo(1));

            Assert.Pass();
        }

        [Test]
        public void TestIncrementMultiple()
        {
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Increment();

            Assert.That(myCounter.Tick , Is.EqualTo(3));

            Assert.Pass();
        }

        [Test]
        public void TestReset()
        {
            myCounter.Increment();

            myCounter.Reset();

            Assert.That(myCounter.Tick, Is.EqualTo(0));

            Assert.Pass();
        }
    }
}