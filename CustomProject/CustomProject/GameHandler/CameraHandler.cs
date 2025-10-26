using SplashKitSDK;

namespace CustomProject.GameHandler
{
    public class CameraHandler
    {
        private GameMap _gameMap;
        private Player _player;

        public CameraHandler(GameMap gamemap, Player player) 
        {
            _player = player;
            _gameMap = gamemap; 
        }

        public void HandleCamera()
        {
            // Initialize the fixed camera position on the screen
            Camera.X = _player.X - SplashKit.ScreenWidth() / 2;
            Camera.Y = _player.Y - SplashKit.ScreenHeight() / 2;

            // Update the camera as the player moves
            if (Camera.X < 0)
            {
                Camera.X = 0;
            }
            if (Camera.Y < 0)
            {
                Camera.Y = 0;
            }
            if (Camera.X > _gameMap.Width - SplashKit.ScreenWidth())
            {
                Camera.X = _gameMap.Width - SplashKit.ScreenWidth();
            }
            if (Camera.Y > _gameMap.Height - SplashKit.ScreenHeight())
            {
                Camera.Y = _gameMap.Height - SplashKit.ScreenHeight();
            }
        }
    }
}
