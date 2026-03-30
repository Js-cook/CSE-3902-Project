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

            int damageToApply = projectile.DamageValue;
            // If the projectile is not a player projectile, ignore it (don't damage enemies)
            if (!projectile.isPlayerProjectile)
                return;
            
            // Handle Bat, and Gel collision with boomerang
            if ((enemy is Bat || enemy is Gel) && (projectile is Boomerang || projectile is MagicBoomerang))
            {
                damageToApply = 1; // Boomerang does 1 damage to Bats and Gels but 0 to other enemies
            }

            projectile.OnCollision();
            enemy.TakeDamage(damageToApply);

            

        }

    }
}

