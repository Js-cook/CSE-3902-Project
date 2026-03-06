using Microsoft.Xna.Framework;
using System;

public class ProjectileWallCollisionHandler : ICollisionHandler
{
    public ProjectileWallCollisionHandler()
    {
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Tile tile = obj1 as Tile ?? obj2 as Tile;

       

        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;
        if (projectile == null || tile == null)
            return;

        // Only process collision if tile is solid
        if (!tile.IsSolid)
            return;


        if (projectile != null && tile != null)
        { 

            projectile.OnCollision();
            

        }

    }
}

