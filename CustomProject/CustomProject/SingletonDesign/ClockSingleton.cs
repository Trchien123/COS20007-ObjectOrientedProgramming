namespace CustomProject.SingletonDesign
{
    public class ClockSingleton
    {
        private static readonly object _lockObject = new object();
        private static volatile ClockSingleton _instance;
        private Dictionary<string, SplashKitSDK.Timer> _timers;

        private ClockSingleton()
        {
            _timers = new Dictionary<string, SplashKitSDK.Timer>();
        }

        public static ClockSingleton getInstance()
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ClockSingleton();
                    }
                }
            }
            return _instance;
        }

        public void StartTimer(string timerName)
        {
            if (_timers.ContainsKey(timerName))
            {
                _timers[timerName].Reset();
            }
            else
            {
                _timers[timerName] = new SplashKitSDK.Timer(timerName);
            }
            _timers[timerName].Start();
        }

        public uint GetElapsedTicks(string timerName)
        {
            if (_timers.ContainsKey(timerName))
            {
                return _timers[timerName].Ticks;
            }
            return 0;
        }
    }
}
