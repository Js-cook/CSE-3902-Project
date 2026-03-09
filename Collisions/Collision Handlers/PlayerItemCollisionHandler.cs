using Enums;
using System;
using Microsoft.Xna.Framework;

public class PlayerItemCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable playerCollidable, ICollidable itemCollidable, Rectangle intersection)
    {
        if (playerCollidable is not Link player || itemCollidable is not PickupItem pickup || !pickup.HitboxActive)
        {
            return;
        }

        switch (pickup.ItemType)
        {
            case ItemType.Heart:
                player.playerInventory.currentHearts = Math.Min(player.playerInventory.currentHearts + 2, player.playerInventory.maxHearts);
                break;
            case ItemType.Rupee:
                player.playerInventory.rupees++;
                break;
            case ItemType.Key:
                player.playerInventory.keys++;
                break;
            case ItemType.Bomb:
                player.playerInventory.items++;
                break;
            case ItemType.HeartContainer:
                player.playerInventory.maxHearts += 2;
                player.playerInventory.currentHearts = player.playerInventory.maxHearts;
                break;
            case ItemType.Fairy:
                player.playerInventory.currentHearts = player.playerInventory.maxHearts;
                break;
            default:
                break;
        }

        pickup.HitboxActive = false;
    }
}
