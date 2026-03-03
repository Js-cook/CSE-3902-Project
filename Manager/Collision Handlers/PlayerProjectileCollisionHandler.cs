using Microsoft.Xna.Framework;

public class PlayerProjectileCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;

        if (player == null || projectile == null)
            return;

        // Don't process collision if player is already hurt
        if (player.Hurt)
            return;

        // Don't process collision if projectile is already inactive
        if (!projectile.Active)
            return;

        // Determine knockback direction based on projectile position relative to player
        Vector2 knockbackDirection = GetKnockbackDirection(player, projectile, intersection);

        // Apply knockback to player
        ApplyKnockback(player, knockbackDirection);

        // Damage the player
        player.playerState.BeDamaged();

        // Destroy the projectile (it hit the player)
        projectile.Active = false;
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
