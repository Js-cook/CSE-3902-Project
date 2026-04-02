using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Enums;

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

            // Apply knockback to Goriya enemies
            if (enemy is Goriya goriya && !(projectile is Boomerang || projectile is MagicBoomerang))
            {
                Direction knockbackDirection = CalculateKnockbackDirection(goriya, intersection);
                goriya.TakeKnockback(knockbackDirection);
            }

        }

    }

    private Direction CalculateKnockbackDirection(Goriya goriya, Rectangle intersection)
    {
        // Determine knockback direction based on collision intersection
        // The knockback should push the enemy away from the projectile origin

        // Calculate center points
        float goriyaCenterX = goriya.position.X + goriya.Hitbox.Width / 2f;
        float goriyaCenterY = goriya.position.Y + goriya.Hitbox.Height / 2f;

        float intersectionCenterX = intersection.X + intersection.Width / 2f;
        float intersectionCenterY = intersection.Y + intersection.Height / 2f;

        // Calculate differences to determine which direction to knock back
        float diffX = goriyaCenterX - intersectionCenterX;
        float diffY = goriyaCenterY - intersectionCenterY;

        // Use absolute values to determine the dominant direction
        float absDiffX = Math.Abs(diffX);
        float absDiffY = Math.Abs(diffY);

        // Determine primary knockback direction
        if (absDiffX > absDiffY)
        {
            // More horizontal knockback
            return diffX > 0 ? Direction.RIGHT : Direction.LEFT;
        }
        else
        {
            // More vertical knockback
            return diffY > 0 ? Direction.DOWN : Direction.UP;
        }
    }
}

