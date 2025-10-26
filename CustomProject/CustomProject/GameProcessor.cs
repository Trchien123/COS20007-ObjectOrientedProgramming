using CustomProject.Command;
using CustomProject.Observers;
using CustomProject.SingletonDesign;
using CustomProject.StrategyDesign;
using SplashKitSDK;

namespace CustomProject
{
    public class GameProcessor
    {
        private readonly Window _window;
        private GameMap _map;
        private Player _player;

        private Bitmap _interface;

        private string _playerName;
        private string _playerDescription;

        private bool _gameStarted;
        private bool _gameOver;
        private bool _showingInstructions;

        private SwordUnlocked _swordUnlockedNotification;
        private FastMovementUnlocked _fastMovementNotification;
        private HighJumpUnlocked _highJumpNotification;

        public GameProcessor()
        {
            GetUserName();
            GetUserDescription();

            _window = new Window("Adventure Time", 850, 400);

            _gameStarted = false;
            _gameOver = false;
            _showingInstructions = false;

            _swordUnlockedNotification = new SwordUnlocked();
            _fastMovementNotification = new FastMovementUnlocked();
            _highJumpNotification = new HighJumpUnlocked();

            InitializeMap();
            InitializePlayer();
        }

        private void GetUserName()
        {
            do
            {
                Console.Write("Player name: ");
                _playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(_playerName))
                {
                    Console.WriteLine("Invalid Name!!");
                }
            }
            while (string.IsNullOrWhiteSpace(_playerName));
        }

        private void GetUserDescription()
        {
            do
            {
                Console.Write("Player description: ");
                _playerDescription = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(_playerDescription))
                {
                    Console.WriteLine("Invalid Description!!");
                }
            }
            while (string.IsNullOrWhiteSpace(_playerDescription));
        }

        private void InitializeMap()
        {
            _map = new GameMap(new string[] { "jungle" }, "Jungle!", "You are in the jungle!");
            _map.SetUpGameMap();
        }

        private void InitializePlayer()
        {
            _player = new Player(_map, _playerName, _playerDescription);
            _player.Attach(new ScoreObserver());
            _player.Attach(new SwordObserver());
            _player.Attach(_swordUnlockedNotification);
        }

        public void Run()
        {
            while (!_window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                _window.Clear(Color.White);

                if (!_gameStarted)
                {
                    HandleGameStart();
                }
                else if (_gameOver)
                {
                    HandleGameOver();
                }
                else
                {
                    HandleGamePlay();
                }

                SplashKit.RefreshScreen(60);
            }
        }

        private void HandleGameStart()
        {
            if (!_showingInstructions)
            {
                _interface = SplashKit.LoadBitmap("game start", "GameStart.png");
                SplashKit.DrawBitmap(_interface, Camera.X, Camera.Y);
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _showingInstructions = true;
                }
            }
            else
            {
                _interface = SplashKit.LoadBitmap("instructions", "Instructions.png");
                SplashKit.DrawBitmap(_interface, Camera.X, Camera.Y);
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _gameStarted = true;
                }
            }
        }

        private void HandleGameOver()
        {
            _interface = SplashKit.LoadBitmap("game over", "GameOver.png");
            SplashKit.DrawBitmap(_interface, Camera.X, Camera.Y);
            {
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    _gameStarted = true;
                    _gameOver = false;
                    InitializeMap();
                    InitializePlayer();
                }
                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    _window.Close();
                }
            }
        }

        private void HandleGamePlay()
        {
            _map.Draw();
            _player.Update();
            _player.Draw();
            CheckDeathState();
            UpdatePlayerState();
            UpdateInventory();
            OpenInventory();
            UpdateGameMap();
        }

        private void CheckDeathState()
        {
            if (_player.IsDead && ClockSingleton.getInstance().GetElapsedTicks("deathframe") >= 800)
            {
                Console.WriteLine("You lose!!!\n");
                _gameOver = true;
            }
        }

        private void UpdateInventory()
        {
            int golds = _player.CollectedGolds;
            int swords = _player.CollectedSwords;

            _player.Inventory = new Inventory();

            if (golds > 0)
            {
                Item goldItem = new Item(new string[] { "gold" }, $"box of {golds} golds", "Very Precious Things");
                _player.Inventory.Put(goldItem);
            }

            if (swords > 0)
            {
                Item swordItem = new Item(new string[] { "sword" }, "Metal Sword", "Melee Weapon!");
                _player.Inventory.Put(swordItem);
            }
        }

        private void OpenInventory()
        {
            if (SplashKit.KeyTyped(KeyCode.TabKey))
            {
                string message = new LookCommand().Execute(_player, new string[] { "look at inventory" });
                Console.WriteLine(message);
            }
        }

        private void UpdateGameMap()
        {
            var keyToBackgroundMap = new Dictionary<KeyCode, (Bitmap, string, string)>
            {
                { KeyCode.Num2Key, (_map.Sea, "You have moved to the sea!", "the sea") },
                { KeyCode.Num1Key, (_map.Jungle, "You have moved to the jungle!", "the jungle") },
                { KeyCode.Num3Key, (_map.Sky, "You have moved to the sky!", "the sky") } ,
                { KeyCode.Num4Key, (_map.Desert, "You have moved to the desert!", "the desert") }
            };

            foreach (var entry in keyToBackgroundMap)
            {
                if (SplashKit.KeyTyped(entry.Key))
                {
                    if (_map.Background == entry.Value.Item1)
                    {
                        Console.WriteLine($"You are already in {entry.Value.Item3}!");
                    }
                    else
                    {
                        _map.Background = entry.Value.Item1;
                        Console.WriteLine(entry.Value.Item2);
                    }
                    break; // No need to check other keys once we find a match
                }
            }
        }

        private void UpdatePlayerState()
        {
            if (_player.CollectedGolds == 5)
            {
                _player.SetCollectStrategy(new AdvancedCollect());
                _player.Notify("SwordUnlocked");
                _player.Detach(_swordUnlockedNotification);
            }

            if (_player.IncreaseSpeed)
            {
                // Ensure the potion observer is attached
                _player.Attach(_fastMovementNotification);
                _player.Notify("SpeedPotionCollected");
                _player.Detach(_fastMovementNotification);
                _player.IncreaseSpeed = false; // Prevent repeated notifications
            }

            if (_player.IncreaseJump)
            {
                _player.Attach(_highJumpNotification);
                _player.Notify("JumpPotionCollected");
                _player.Detach(_highJumpNotification);
                _player.IncreaseJump = false; // Prevent repeated notifications
            }

            // Check if the fast movement period is over
            if (ClockSingleton.getInstance().GetElapsedTicks("fastmovement") >= 3000)
            {
                _player.SetMovementStrategy(new NormalMovement());
            }

            // Check if the high jump period is over
            if (ClockSingleton.getInstance().GetElapsedTicks("highjump") >= 3000)
            {
                _player.SetJumpStrategy(new NormalJump());
            }
        }
    }
}