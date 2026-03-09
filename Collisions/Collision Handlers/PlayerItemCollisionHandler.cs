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
                player.CurrentHealth = Math.Min(player.CurrentHealth + 2, player.MaxHealth);
                break;
            case ItemType.Rupee:
                player.RupeeCount++;
                break;
            case ItemType.Key:
                player.KeyCount++;
                break;
            case ItemType.Bomb:
                player.BombCount++;
                break;
            case ItemType.HeartContainer:
                player.MaxHealth += 2;
                player.CurrentHealth = player.MaxHealth;
                break;
            case ItemType.Fairy:
                player.CurrentHealth = player.MaxHealth;
                break;
            default:
                break;
        }

        pickup.HitboxActive = false;
    }
}
