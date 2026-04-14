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
                player.OnHeartPickup();
                break;
            case ItemType.Rupee:
                player.playerInventory.rupees++;
                break;
            case ItemType.Key:
                player.playerInventory.keys++;
                break;
            case ItemType.Bomb:
                player.playerInventory.bombs++;
                break;
            case ItemType.HeartContainer:
                player.OnHeartContainerPickup();
                break;
            case ItemType.Map:
                player.playerInventory.hasMap = true;
                break;
            case ItemType.Compass:
                player.playerInventory.hasCompass = true;
                break;
            case ItemType.Fairy:
                player.OnFairyPickup();
                break;
            case ItemType.TriForcePiece:
                player.playerInventory.hasTriForcePiece = true;
                pickup.Position = player.position + new Vector2(0, -16); // Position the TriForce piece above the player
                break;
            default:
                break;
        }


        pickup.HitboxActive = false;
    }
}
