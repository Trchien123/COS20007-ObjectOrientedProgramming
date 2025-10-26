using SplashKitSDK;

namespace CustomProject.StrategyDesign
{
    public class FastMovement : IMovementStrategy
    {
        public void Move(Player player)
        {
            player.IsMoving = false;
            if (!player.IsDead)
            {
                if (SplashKit.KeyDown(KeyCode.LeftKey))
                {
                    player.IsMoving = true;
                    if (!player.CollisionHandler.IsCollideWithLand(player.X - 6, player.Y))
                    {
                        player.X -= 6;
                    }
                }
                else if (SplashKit.KeyDown(KeyCode.RightKey))
                {
                    player.IsMoving = true;
                    if (!player.CollisionHandler.IsCollideWithLand(player.X + 6, player.Y))
                    {
                        player.X += 6;
                    }
                }
            }
        }
    }
}
