using SplashKitSDK;

namespace CustomProject.StrategyDesign
{
    public class NormalJump : IJumpStrategy
    {
        public void Jump(Player player)
        {
            if (SplashKit.KeyTyped(KeyCode.UpKey))
            {
                if (player.CollisionHandler.IsPlayerOnGround())
                {
                    player.Gravity = -20;
                }
            }
        }
    }
}

