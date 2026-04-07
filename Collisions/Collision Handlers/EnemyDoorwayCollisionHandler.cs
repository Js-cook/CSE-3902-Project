using Enums;
using Microsoft.Xna.Framework;

public class EnemyDoorwayCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;

        if (enemy == null || doorway == null)
            return;


        // Resolve the collision by pushing player out of the tile
        ResolveCollision(enemy, doorway.Hitbox, intersection);
    }

    private void ResolveCollision(IEnemy enemy, Rectangle tileHitbox, Rectangle intersection)
    {

        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision - push left or right
            if (enemy.Hitbox.Center.X < tileHitbox.Center.X)
            {
                // Player is to the left of tile - push left with buffer
                enemy.OnWallCollision(Direction.LEFT);
            }
            else
            {
                // Player is to the right of tile - push right with buffer
                enemy.OnWallCollision(Direction.RIGHT)
;
            }
        }
        else
        {
            // Vertical collision - push up or down
            if (enemy.Hitbox.Center.Y < tileHitbox.Center.Y)
            {
                enemy.OnWallCollision(Direction.UP);

            }
            else
            {
                enemy.OnWallCollision(Direction.DOWN);
            }
        }
    }
}
