using Microsoft.Xna.Framework;
using System;

public class ProjectileDoorwayCollisionHandler : ICollisionHandler
{
    public ProjectileDoorwayCollisionHandler()
    {
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;



        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;
        if (projectile == null || doorway == null)
            return;


        if (projectile != null && doorway != null)
        {
            if (projectile is Fireball fireball)
            {
                fireball.HitWall = true;
            }

            projectile.OnCollision();


        }

    }
}

