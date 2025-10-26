using CustomProject.GameObjects;
using SplashKitSDK;

namespace CustomProject.StrategyDesign
{
    public class AdvancedCollect : ICollectStrategy
    {
        public void Collect(Player player)
        {
            if (!player.IsDead)
            {
                List<CollectibleGold> collectedGolds = new List<CollectibleGold>();
                List<Sword> collectedSwords = new List<Sword>();
                List<SpeedPotion> collectedSpeedPotion = new List<SpeedPotion>();
                List<JumpPotion> collectedJumpPotion = new List<JumpPotion>();

                foreach (CollectibleGold gold in player.GameMap.Golds)
                {
                    if (SplashKit.BitmapCollision(player.Image, player.X, player.Y, gold.Image, gold.X, gold.Y))
                    {
                        collectedGolds.Add(gold);
                    }
                }

                foreach (Sword sword in player.GameMap.Swords)
                {
                    if (SplashKit.BitmapCollision(player.Image, player.X, player.Y, sword.Image, sword.X, sword.Y))
                    {
                        collectedSwords.Add(sword);
                    }
                }

                foreach (SpeedPotion potion in player.GameMap.SpeedPotion)
                {
                    if (SplashKit.BitmapCollision(player.Image, player.X, player.Y, potion.Image, potion.X, potion.Y))
                    {
                        collectedSpeedPotion.Add(potion);
                    }
                }

                foreach (JumpPotion potion in player.GameMap.JumpPotion)
                {
                    if (SplashKit.BitmapCollision(player.Image, player.X, player.Y, potion.Image, potion.X, potion.Y))
                    {
                        collectedJumpPotion.Add(potion);
                    }
                }

                foreach (SpeedPotion potion in collectedSpeedPotion)
                {
                    player.GameMap.SpeedPotion.Remove(potion);
                    player.IncreaseSpeed = true;
                }

                foreach (JumpPotion potion in collectedJumpPotion)
                {
                    player.GameMap.JumpPotion.Remove(potion);
                    player.IncreaseJump = true;
                }

                foreach (Sword sword in collectedSwords)
                {
                    player.GameMap.Swords.Remove(sword);
                    player.CollectedSwords += 1;
                    player.Notify("SwordCollected");
                }

                foreach (CollectibleGold gold in collectedGolds)
                {
                    player.GameMap.Golds.Remove(gold);
                    player.CollectedGolds += 1;
                    player.Notify("GoldCollected");
                }
            }
        }
    }
}

