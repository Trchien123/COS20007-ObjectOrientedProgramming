using CustomProject.GameObjects;
using SplashKitSDK;

namespace CustomProject.GameHandler
{
    public class CollisionHandler
    {
        private GameMap _gameMap;
        private Player _player;

        public CollisionHandler(GameMap gamemap, Player player) 
        {
            _gameMap = gamemap;
            _player = player;
        }

        // Process the action of touching bombs and remove them
        public void CheckBombCollision()
        {
            List<CollectibleBomb> removedBombs = new List<CollectibleBomb>();
            AnimationHandler _animationHandler = new AnimationHandler(_player);
            foreach (CollectibleBomb bomb in _gameMap.Bombs)
            {
                if (SplashKit.BitmapCollision(_player.Image, _player.X, _player.Y, bomb.Image, bomb.X, bomb.Y))
                {
                    removedBombs.Add(bomb);
                    _player.IsDead = true;
                    _animationHandler.Die();
                }
            }

            foreach (CollectibleBomb bomb in removedBombs)
            {
                _gameMap.Bombs.Remove(bomb);
            }
        }

        // Check if the player is on the ground
        public bool IsPlayerOnGround()
        {
            return IsCollideWithLand(_player.X, _player.Y + 1);
        }

        // Check land collision with player for handle movement
        public bool IsCollideWithLand(double x, double y)
        {
            foreach (Land land in _gameMap.Lands)
            {
                if (SplashKit.BitmapCollision(_player.Image, x, y, land.Image, land.X, land.Y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
