using Microsoft.Xna.Framework;

public class ProjectilePushableBlockCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;
        PushableBlock block = obj1 as PushableBlock ?? obj2 as PushableBlock;

        if (projectile == null || block == null)
            return;

        if (projectile is Fireball fireball)
        {
            fireball.HitWall = true;
        }

        projectile.OnCollision();
    }
}
