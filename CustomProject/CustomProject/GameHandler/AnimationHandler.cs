using CustomProject.SingletonDesign;
using SplashKitSDK;

namespace CustomProject.GameHandler
{
    public class AnimationHandler
    {
        private Player _player;

        public AnimationHandler(Player player)
        {
            _player = player;
        }

        public void UpdateMovingAnimation()
        {
            if (_player.IsDead) return;

            if (_player.IsMoving)
            {
                UpdateRunningAnimation();
            }
            else
            {
                UpdateStandingAnimation();
            }
        }

        private void UpdateStandingAnimation()
        {
            if (_player.PlayerSprite.AnimationName() == "runleft")
            {
                _player.PlayerSprite.StartAnimation("Left");
            }
            else if (_player.PlayerSprite.AnimationName() == "runright")
            {
                _player.PlayerSprite.StartAnimation("Right");
            }
        }

        private void UpdateRunningAnimation()
        {
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                StartAnimationIfNotRunning("RunLeft");
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                StartAnimationIfNotRunning("RunRight");
            }
        }

        private void StartAnimationIfNotRunning(string animationName)
        {
            if (SplashKit.SpriteAnimationName(_player.PlayerSprite) != animationName.ToLower())
            {
                _player.PlayerSprite.StartAnimation(animationName);
            }
        }

        public void UpdateDeadAnimation()
        {
            if (ClockSingleton.getInstance().GetElapsedTicks("deathframe") <= 800)
            {
                _player.PlayerSprite.UpdateAnimation();
            }
        }

        public void Die()
        {
            _player.IsDead = true;
            ClockSingleton.getInstance().StartTimer("deathframe");
            if (_player.PlayerSprite.AnimationName().Contains("right"))
            {
                _player.PlayerSprite.StartAnimation("DeadRight");
            }
            else if (_player.PlayerSprite.AnimationName().Contains("left"))
            {
                _player.PlayerSprite.StartAnimation("DeadLeft");
            }
        }
    }
}
