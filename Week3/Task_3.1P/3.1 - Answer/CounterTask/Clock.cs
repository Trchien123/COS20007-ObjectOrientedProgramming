using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask
{
    public class Clock
    {
        private Counter _hours;
        private Counter _minutes;
        private Counter _seconds;
        public Clock()
        {
            _hours = new Counter("");
            _minutes = new Counter("");
            _seconds = new Counter("");
        }
        
        public int Hours
        {
            get => _hours.Tick;
        }

        public int Minutes
        {
            get => _minutes.Tick;
        }

        public int Seconds
        {
            get => _seconds.Tick;
        }

        public void Tick()
        {
            if (_seconds.Tick < 59)
            {
                _seconds.Increment();
            }
            else if (_minutes.Tick < 59)
            {
                _seconds.Reset();
                _minutes.Increment();
            }
            else if (_hours.Tick < 23)
            {
                _seconds.Reset();
                _minutes.Reset();
                _hours.Increment();
            }
            else
            {
                _hours.Reset();
                _minutes.Reset();
                _seconds.Reset();
            }
        }
        public void Reset()
        {
            _hours.Reset();
            _minutes.Reset();
            _seconds.Reset();
        }
        public string PrintTime()
        {
            string currentTime = _hours.Tick.ToString("D2") + ":" + _minutes.Tick.ToString("D2") + ":" + _seconds.Tick.ToString("D2");
            Console.WriteLine(currentTime);

            return currentTime;
        }
        public void StartClock(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
                Tick();
                PrintTime();
            }
        }
    }
}
