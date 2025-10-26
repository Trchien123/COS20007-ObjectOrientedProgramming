using CounterTask;
using System.Diagnostics.CodeAnalysis;

namespace TestClock
{
    public class Tests
    {
        private Clock myClock;
        [SetUp]
        public void Setup()
        {
            myClock = new Clock();
        }

        [Test]
        public void TestClockTick() 
        {
            // Test clock tick less than 1 minute
            for (int i = 0; i < 59; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Hours, Is.EqualTo(0));
            Assert.That(myClock.Minutes, Is.EqualTo(0));
            Assert.That(myClock.Seconds, Is.EqualTo(59));
            
            // Test clock tick when reaching over 1 minute
            for (int i = 0; i < 60; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Hours, Is.EqualTo((0)));
            Assert.That(myClock.Minutes, Is.EqualTo(1));
            Assert.That(myClock.Seconds, Is.EqualTo(59));

            // Test clock tick when reaching over 1 hour
            for (int i = 0; i < 3600; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Hours, Is.EqualTo(1));
            Assert.That(myClock.Minutes, Is.EqualTo(1));
            Assert.That(myClock.Seconds, Is.EqualTo(59));

            // Test clock tick when reaching over 24 hours
            for (int i = 0; i < 3600*24; i++)
            {
                myClock.Tick();
            }
            Assert.That(myClock.Hours, Is.EqualTo(1));
            Assert.That(myClock.Minutes, Is.EqualTo(1));
            Assert.That(myClock.Seconds, Is.EqualTo(59));

            Assert.Pass();
        }

        [Test]
        public void TestReset()
        {
            for (int i = 0; i < 3676; i++)
            {
                myClock.Tick();
            }

            myClock.Reset();
            Assert.That(myClock.Hours, Is.EqualTo(0));
            Assert.That(myClock.Minutes, Is.EqualTo(0));
            Assert.That(myClock.Seconds, Is.EqualTo(0));

            Assert.Pass();
        }

        [Test]
        public void TestTimeFormat()
        {
            for (int i = 0; i < 3676; i++)
            {
                myClock.Tick();
            }
            string a = myClock.PrintTime();
            Assert.That(a, Is.EqualTo("01:01:16"));

            Assert.Pass();
        }
    }
}