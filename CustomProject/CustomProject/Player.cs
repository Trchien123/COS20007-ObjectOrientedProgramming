using CustomProject.GameHandler;
using CustomProject.GameObjects;
using CustomProject.Observers;
using CustomProject.StrategyDesign;
using SplashKitSDK;

namespace CustomProject
{
    public class Player : DrawableObject, IHaveInventory, ISubject
    {
        private double _gravity;
        private AnimationScript _playerScript;
        private Sprite _playerSprite;
        private GameMap _gameMap;
        private bool _isDead;
        private bool _isMoving;

        private Inventory _inventory;
        private int _collectedGolds;
        private int _collectedSwords;
        private bool _increaseSpeed;
        private bool _increaseJump;

        private IMovementStrategy _movementStrategy;
        private IJumpStrategy _jumpStrategy;
        private ICollectStrategy _collectStrategy;

        private List<IObserver> _observers;

        private AnimationHandler _animationHandler;
        private CameraHandler _cameraHandler;
        private CollisionHandler _collisionHandler;

        public Player(GameMap gameMap, string name, string description) : base(200, 200, new string[] { "inventory" }, name, description, "playerImage.png")
        {
            InitializePlayerSprite();
            InitializePlayerState(gameMap);
            InitializeStrategy();

            _animationHandler = new AnimationHandler(this);
            _cameraHandler = new CameraHandler(gameMap, this);
            _collisionHandler = new CollisionHandler(gameMap, this);

            _observers = new List<IObserver>();
        }

        // Update the actions of the player
        public void Update()
        {
            if (_isDead)
            {
                _animationHandler.UpdateDeadAnimation();
            }

            _movementStrategy.Move(this);
            _collectStrategy.Collect(this);
            UpdateYLocation();

            _animationHandler.UpdateMovingAnimation();
            _cameraHandler.HandleCamera();
            _playerSprite.UpdateAnimation();
            _collisionHandler.CheckBombCollision();
        }

        private void UpdateYLocation()
        {
            if (!_isDead) // Check for jumping keypressed
            {
                _jumpStrategy.Jump(this);
            }

            // Update the gravity and Y location
            _gravity += 1;
            double newY = _yLocation + _gravity;

            if (_gravity > 0 && _collisionHandler.IsCollideWithLand(_xLocation, newY))
            {
                _gravity = 0;
            }
            else if (_gravity < 0 && _collisionHandler.IsCollideWithLand(_xLocation, newY))
            {
                _gravity = 0;
            }
            else
            {
                _yLocation = newY;
            }
        }

        // Draw the player on the screen
        public override void Draw()
        {
            _playerSprite.Draw(_xLocation, _yLocation);
        }

        private void InitializePlayerSprite()
        {
            _image.SetCellDetails(_image.Width / 8, _image.Height / 6, 8, 6, 48);
            _playerScript = SplashKit.LoadAnimationScript("_playerScript", "animationscript.txt");
            _playerSprite = SplashKit.CreateSprite(_image, _playerScript);
            _playerSprite.StartAnimation(0);
        }

        private void InitializePlayerState(GameMap gameMap)
        {
            _gravity = 0;
            _isDead = false;
            _isMoving = false;
            _gameMap = gameMap;
            _inventory = new Inventory();
            _collectedGolds = 0;
            _collectedSwords = 0;
            _increaseSpeed = false;
            _increaseJump = false;
        }

        private void InitializeStrategy()
        {
            _movementStrategy = new NormalMovement();
            _jumpStrategy = new NormalJump();
            _collectStrategy = new NormalCollect();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string eventType)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(eventType, this);
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

        public void SetMovementStrategy(IMovementStrategy strategy)
        {
            _movementStrategy = strategy;
        }

        public void SetJumpStrategy(IJumpStrategy strategy)
        {
            _jumpStrategy = strategy;
        }

        public void SetCollectStrategy(ICollectStrategy strategy)
        {
            _collectStrategy = strategy;
        }

        public override string FullDescription
        {
            get
            {
                string fulldesc = "\n" + "-----INVENTORY-----" + "\n";
                fulldesc += $"You are {Name}, {base.FullDescription}\n";
                fulldesc += "You are carrying\n";
                fulldesc += $"{_inventory.ItemList}";
                return fulldesc;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
            set => _inventory = value;
        }

        public double Gravity { get => _gravity; set => _gravity = value; }
        public bool IsMoving { get => _isMoving; set => _isMoving = value; }
        public bool IsDead { get => _isDead; set => _isDead = value; }
        public GameMap GameMap { get => _gameMap; } 
        public int CollectedGolds { get => _collectedGolds; set => _collectedGolds = value; }
        public int CollectedSwords { get => _collectedSwords; set => _collectedSwords = value; }
        public bool IncreaseSpeed { get => _increaseSpeed; set => _increaseSpeed = value; }
        public bool IncreaseJump { get => _increaseJump; set => _increaseJump = value; }
        public Sprite PlayerSprite { get => _playerSprite; }
        public CollisionHandler CollisionHandler { get => _collisionHandler; }
    }
}

