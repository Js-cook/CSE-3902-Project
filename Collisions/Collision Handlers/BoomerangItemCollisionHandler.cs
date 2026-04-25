using Enums;
using Microsoft.Xna.Framework;

public class BoomerangItemCollisionHandler : ICollisionHandler
{
    private EnemyController enemyController;
    public BoomerangItemCollisionHandler(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle collision)
    {
        Boomerang boomerang = obj1 as Boomerang ?? obj2 as Boomerang;
        PickupItem pickup = obj1 as PickupItem ?? obj2 as PickupItem;

        if (boomerang == null && pickup == null)
            return;

        switch (pickup.ItemType)
        {
            case ItemType.Heart:
                boomerang.player.OnHeartPickup();
                break;
            case ItemType.Rupee:
                boomerang.player.playerInventory.rupees++;
                break;
            case ItemType.Key:
                boomerang.player.playerInventory.keys++;
                break;
            case ItemType.Bomb:
                boomerang.player.playerInventory.bombs++;
                break;
            case ItemType.HeartContainer:
                boomerang.player.OnHeartContainerPickup();
                break;
            case ItemType.WoodenBoomerang:
                boomerang.player.playerInventory.boomerangs++;
                break;
            case ItemType.Map:
                boomerang.player.playerInventory.hasMap = true;
                break;
            case ItemType.Compass:
                boomerang.player.playerInventory.hasCompass = true;
                break;
            case ItemType.Fairy:
                boomerang.player.OnFairyPickup();
                break;
            case ItemType.Clock:
                // Freeze all enemies for 5 seconds (5000 milliseconds)
                if (enemyController != null)
                {
                    enemyController.FreezeEnemies(5000f);
                }
                break;
            case ItemType.TriForcePiece:
                boomerang.player.playerInventory.hasTriForcePiece = true;
                pickup.Position = boomerang.player.position + new Vector2(0, -16); // Position the TriForce piece above the player
                break;
            case ItemType.RedRing:
                boomerang.player.playerInventory.hasRedRing = true;
                break;
            case ItemType.PowerBracelet:
                boomerang.player.playerInventory.hasPowerBracelet = true;
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
