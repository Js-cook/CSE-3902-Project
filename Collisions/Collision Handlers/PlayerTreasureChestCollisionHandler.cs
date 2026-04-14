using Enums;
using Microsoft.Xna.Framework;

public class PlayerTreasureChestCollisionHandler : ICollisionHandler
{
    private ItemController itemController;

    public PlayerTreasureChestCollisionHandler(ItemController itemController)
    {
        this.itemController = itemController;
    }

    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        TreasureChest chest = obj1 as TreasureChest ?? obj2 as TreasureChest;

        if (player == null || chest == null)
            return;

        if (!chest.HitboxActive)
            return;

        if (!chest.IsOpened)
        {
            ItemType? drop = chest.OpenAndGetRandomDrop();

            if (drop.HasValue)
            {
                itemController.SpawnItem(drop.Value, chest.Position);
            }
        }

        ResolveCollision(player, chest.Hitbox, intersection);
    }

    private void ResolveCollision(Link player, Rectangle chestHitbox, Rectangle intersection)
    {
        const int wallBuffer = 2;

        if (intersection.Width < intersection.Height)
        {
            if (player.Hitbox.Center.X < chestHitbox.Center.X)
            {
                player.position = new Vector2(
                    chestHitbox.Left - player.Hitbox.Width - wallBuffer,
                    player.position.Y
                );
            }
            else
            {
                player.position = new Vector2(
                    chestHitbox.Right + wallBuffer,
                    player.position.Y
                );
            }
        }
        else
        {
            if (player.Hitbox.Center.Y < chestHitbox.Center.Y)
            {
                player.position = new Vector2(
                    player.position.X,
                    chestHitbox.Top - player.Hitbox.Height - wallBuffer
                );
            }
            else
            {
                player.position = new Vector2(
                    player.position.X,
                    chestHitbox.Bottom + wallBuffer
                );
            }
        }
    }
}