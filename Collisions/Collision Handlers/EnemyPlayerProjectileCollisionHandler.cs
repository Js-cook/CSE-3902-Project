using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

public class EnemyPlayerProjectileCollisionHandler : ICollisionHandler
{
    public EnemyPlayerProjectileCollisionHandler()
    {
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;
        if (projectile != null && enemy != null)
        {
            // If the projectile is not a player projectile, ignore it (don't damage enemies)
            if (!projectile.isPlayerProjectile)
                return;

            projectile.OnCollision();
            enemy.TakeDamage(projectile.DamageValue);

            Debug.WriteLine($"Enemy hit! Enemy: {enemy.ToString()} health: {enemy.Health}");
            System.Diagnostics.Debug.WriteLine("Enemy Hit at: " + DateTime.Now.Ticks);

        }

    }
}

