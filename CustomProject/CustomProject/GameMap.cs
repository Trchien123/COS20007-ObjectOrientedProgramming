using CustomProject.GameObjects;
using SplashKitSDK;

namespace CustomProject
{
    public class GameMap : GameObject
    {
        // Game map height and width
        private int _mapWidth, _mapHeight;

        // Game map objects
        private Bitmap _background;
        private Bitmap _jungle, _sky, _sea, _desert;

        private List<Land> _lands;
        private List<CollectibleBomb> _bombs;
        private List<CollectibleGold> _golds;
        private List<Sword> _sword;
        private List<SpeedPotion> _speedPotion;
        private List<JumpPotion> _jumpPotion;

        // For reading maps and draw
        private string[] _txtMap;

        public GameMap(string[] ids, string name, string description) : base(ids, name, description)
        {
            _lands = new List<Land>();
            _bombs = new List<CollectibleBomb>();
            _golds = new List<CollectibleGold>();
            _sword = new List<Sword>();
            _speedPotion = new List<SpeedPotion>();
            _jumpPotion = new List<JumpPotion>();

            ReadMapFromFile("map.txt");
            LoadBackgrounds();
        }

        private void ReadMapFromFile(string filename)
        {
            StreamReader _rd = new StreamReader(filename);
            _txtMap = _rd.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            _rd.Close();

            _mapHeight = _txtMap.Length;
            _mapWidth = _txtMap[0].Length;
        }

        private void LoadBackgrounds()
        {
            _jungle = SplashKit.LoadBitmap("jungle", "jungle.png");
            _sky = SplashKit.LoadBitmap("sky", "sky.png");
            _sea = SplashKit.LoadBitmap("sea", "marine.png");
            _desert = SplashKit.LoadBitmap("desert", "desert.jpg");
            _background = _jungle;
        }

        // Set up the 2D array of the text map
        public void SetUpGameMap()
        {
            for (int i = 0; i < _mapHeight; i++)
            {
                for (int j = 0; j < _mapWidth; j++)
                {
                    switch (_txtMap[i][j])
                    {
                        case '#':
                            _lands.Add(new Land(j * 50, i * 50));
                            break;
                        case 'x':
                            _bombs.Add(new CollectibleBomb(j * 50, i * 50));
                            break;
                        case 'o':
                            _golds.Add(new CollectibleGold(j * 50, i * 50));
                            break;
                        case 's':
                            _sword.Add(new Sword(j * 50, i * 50));
                            break;
                        case 'a':
                            _speedPotion.Add(new SpeedPotion(j * 50, i * 50));
                            break;
                        case 'j':
                            _jumpPotion.Add(new JumpPotion(j * 50, i * 50));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Draw the game map using the 2D arry of text map
        public void Draw()
        {
            SplashKit.DrawBitmap(_background, Camera.X, Camera.Y);
            foreach (Land land in _lands)
            {
                land.Draw();
            }

            foreach (CollectibleGold gold in _golds)
            {
                gold.Draw();
            }

            foreach (CollectibleBomb bomb in _bombs)
            {
                bomb.Draw();
            }

            foreach (Sword sword in _sword)
            {
                sword.Draw();
            }

            foreach (SpeedPotion potion in _speedPotion)
            {
                potion.Draw();
            }

            foreach (JumpPotion potion in _jumpPotion)
            {
                potion.Draw();
            }
        }

        public int Width { get => _mapWidth * 50; }
        public int Height { get => _mapHeight * 50; }
        public List<Land> Lands { get => _lands; }
        public List<CollectibleBomb> Bombs { get => _bombs; }
        public List<CollectibleGold> Golds { get => _golds; }
        public List<Sword> Swords { get => _sword; }
        public List<SpeedPotion> SpeedPotion { get => _speedPotion; }
        public List<JumpPotion> JumpPotion { get => _jumpPotion; }
        public Bitmap Background { get => _background; set => _background = value; }
        public Bitmap Sea { get => _sea; }
        public Bitmap Jungle { get => _jungle; }
        public Bitmap Sky { get => _sky; }
        public Bitmap Desert { get => _desert; }
    }
}
