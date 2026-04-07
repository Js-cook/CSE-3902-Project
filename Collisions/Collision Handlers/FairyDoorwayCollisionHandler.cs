using Enums;
using Microsoft.Xna.Framework;

public class FairyDoorwayCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        PickupItem fairy = obj1 as PickupItem ?? obj2 as PickupItem;
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;

        if (fairy == null || doorway == null)
            return;

       
        // Resolve the collision by pushing player out of the tile
        ResolveCollision(fairy, doorway.Hitbox, intersection);
    }

    private void ResolveCollision(PickupItem fairy, Rectangle tileHitbox, Rectangle intersection)
    {



        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision - push left or right
            if (fairy.Hitbox.Center.X < tileHitbox.Center.X)
            {

                fairy.FairyOnWallCollision(Direction.LEFT);
            }
            else
            {
                fairy.FairyOnWallCollision(Direction.RIGHT)
;
            }
        }
        else
        {
            // Vertical collision - push up or down
            if (fairy.Hitbox.Center.Y < tileHitbox.Center.Y)
            {
                fairy.FairyOnWallCollision(Direction.UP);

            }
            else
            {
                fairy.FairyOnWallCollision(Direction.DOWN);
            }
        }
    }
}
