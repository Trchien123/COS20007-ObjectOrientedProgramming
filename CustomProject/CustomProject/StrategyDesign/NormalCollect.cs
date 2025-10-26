using CustomProject.GameObjects;
using SplashKitSDK;

namespace CustomProject.StrategyDesign
{
    public class NormalCollect : ICollectStrategy
    {
        public void Collect(Player player)
        {
            if (!player.IsDead)
            {
                List<CollectibleGold> collectedGolds = new List<CollectibleGold>();

                foreach (CollectibleGold gold in player.GameMap.Golds)
                {
                    if (SplashKit.BitmapCollision(player.Image, player.X, player.Y, gold.Image, gold.X, gold.Y))
                    {
                        collectedGolds.Add(gold);
                    }
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
