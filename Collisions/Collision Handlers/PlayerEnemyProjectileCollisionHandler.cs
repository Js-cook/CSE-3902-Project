using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

public class PlayerEnemyProjectileCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {

        Link player = obj1 as Link ?? obj2 as Link;
        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;

        if (player == null || projectile == null)
            return;

        // Don't process collision if player is already hurt or if projectile is inactive
        if (player.Hurt)
            return;
        if (!projectile.Active)
            return;

        Vector2 knockbackDirection = GetKnockbackDirection(player, projectile, intersection);
        ApplyKnockback(player, knockbackDirection);


        // If projectile is goriya boomerang, it should stun player
        if (projectile is not GoriyaBoomerang)
        {
            int damageToTake = projectile.DamageValue;
            _ = player.playerInventory.hasRedRing ? (damageToTake /= 2) : damageToTake;
            player.TakeDamage(damageToTake);
        }
        else
        {
            player.StunPlayer();
        }
        projectile.Active = false; // Deactivate projectile after collision
    }

    private Vector2 GetKnockbackDirection(Link player, IProjectile projectile, Rectangle intersection)
    {
        // Calculate the center of both objects
        Vector2 playerCenter = new Vector2(player.Hitbox.Center.X, player.Hitbox.Center.Y);
        Vector2 projectileCenter = new Vector2(projectile.Hitbox.Center.X, projectile.Hitbox.Center.Y);

        // Direction from projectile to player (push player away from projectile)
        Vector2 direction = playerCenter - projectileCenter;

        // Determine primary collision axis based on intersection dimensions
        // Narrower dimension = primary collision axis
        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision - push left or right only
            direction.Y = 0;
        }
        else
        {
            // Vertical collision - push up or down only
            direction.X = 0;
        }

        // Normalize to get unit vector (or return zero if no direction)
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }

        return direction;
    }

    private void ApplyKnockback(Link player, Vector2 knockbackDirection)
    {
        // Knockback strength - lighter than enemy collision since projectiles are smaller
        float knockbackStrength = 12f;

        // Apply the knockback to player position
        player.position += knockbackDirection * knockbackStrength;
    }
}
