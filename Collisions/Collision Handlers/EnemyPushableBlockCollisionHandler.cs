using Enums;
using Microsoft.Xna.Framework;

public class EnemyPushableBlockCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        PushableBlock block = obj1 as PushableBlock ?? obj2 as PushableBlock;

        if (enemy == null || block == null)
            return;

        ResolveCollision(enemy, block.Hitbox, intersection);
    }

    private void ResolveCollision(IEnemy enemy, Rectangle blockHitbox, Rectangle intersection)
    {
        if (intersection.Width < intersection.Height)
        {
            if (enemy.Hitbox.Center.X < blockHitbox.Center.X)
            {
                enemy.OnWallCollision(Direction.LEFT);
            }
            else
            {
                enemy.OnWallCollision(Direction.RIGHT);
            }
        }
        else
        {
            if (enemy.Hitbox.Center.Y < blockHitbox.Center.Y)
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
