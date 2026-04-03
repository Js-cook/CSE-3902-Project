using Microsoft.Xna.Framework;

public class PlayerEnemyCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;

        if (player == null || enemy == null)
            return;

        // Don't process collision if player is already hurt
        if (player.Hurt)
            return;

        // Don't process collision if enemy is dead
        if (enemy.isDead)
            return;

        // Determine knockback direction based on collision side
        Vector2 knockbackDirection = GetKnockbackDirection(player, enemy, intersection);

        // Apply knockback to player
        ApplyKnockback(player, knockbackDirection);

        // Damage the player
        player.TakeDamage(1); // Each collision with any enemy causes 1 damage, adjust as needed
    }

    private Vector2 GetKnockbackDirection(Link player, IEnemy enemy, Rectangle intersection)
    {
        // Calculate the center of both objects
        Vector2 playerCenter = new Vector2(player.Hitbox.Center.X, player.Hitbox.Center.Y);
        Vector2 enemyCenter = new Vector2(enemy.Hitbox.Center.X, enemy.Hitbox.Center.Y);

        // Direction from enemy to player
        Vector2 direction = playerCenter - enemyCenter;

        // This if block finds the collision axis (Horizontal or Veritcal)
        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision - push left or right
            direction.Y = 0;
        }
        else
        {
            // Vertical collision - push up or down
            direction.X = 0;
        }

        // Normalize and return (Sets the vector to 1 in the direction of the collision)
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }

        return direction;
    }

    private void ApplyKnockback(Link player, Vector2 knockbackDirection)
    {
        // Knockback strength (adjust as needed for game feel)
        float knockbackStrength = 16f;

        // Apply the knockback to player position
        player.position += knockbackDirection * knockbackStrength;
    }
}
