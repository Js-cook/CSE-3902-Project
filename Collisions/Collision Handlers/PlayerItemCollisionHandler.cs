using Enums;
using System;
using Microsoft.Xna.Framework;

public class PlayerItemCollisionHandler : ICollisionHandler
{
    private EnemyController enemyController;

    public PlayerItemCollisionHandler(EnemyController enemyController = null)
    {
        this.enemyController = enemyController;
    }

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
            case ItemType.WoodenBoomerang:
                player.playerInventory.boomerangs++;
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
            case ItemType.Clock:
                // Freeze all enemies for 5 seconds (5000 milliseconds)
                if (enemyController != null)
                {
                    enemyController.FreezeEnemies(5000f);
                }
                break;
            case ItemType.TriForcePiece:
                player.playerInventory.hasTriForcePiece = true;
                pickup.Position = player.position + new Vector2(0, -16); // Position the TriForce piece above the player
                break;
            case ItemType.RedRing:
                player.playerInventory.hasRedRing = true;
                break;
            default:
                break;
        }


        pickup.HitboxActive = false;
        // Mark the item as acquired in the room definition so it won't respawn
        try
        {
            if (pickup.RoomRow >= 0 && pickup.RoomCol >= 0)
            {
                var room = RoomsRepository.GetRoom(pickup.RoomRow, pickup.RoomCol);
                if (room != null && room.PickupItems != null)
                {
                    var def = room.PickupItems.Find(i => i.X == pickup.GridX && i.Y == pickup.GridY && i.Type == pickup.ItemType);
                    if (def != null)
                    {
                        def.Acquired = true;
                    }
                }
            }
        }
        catch (System.Exception)
        {
            // best-effort: do not crash if repository lookup fails
        }
    }
}
