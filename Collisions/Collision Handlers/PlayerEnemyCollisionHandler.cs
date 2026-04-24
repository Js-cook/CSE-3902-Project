using Microsoft.Xna.Framework;
using System;

public class PlayerEnemyCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;

        if (player == null || enemy == null)
            return;

        if(DetermineSuccessfulPlayerAttack(player, enemy, intersection))
        {
            ApplyKnockback(enemy, -1 * GetKnockbackDirection(player, enemy, intersection));
            int enemyDamageToTake;
            _ = player.playerInventory.hasPowerBracelet == true ? enemyDamageToTake = 1 : enemyDamageToTake = 2;
            enemy.TakeDamage(enemyDamageToTake); 
            return; 
        }

        // Don't process collision if player is already hurt
        if (player.Hurt)
            return;

        // Don't process collision if enemy is dead
        if (enemy.isDead)
            return;

        if (enemy is WallmasterManager)
            return;

        // 3. SPECIAL CASE: Wallmaster Grab
        if (enemy is Wallmaster wallmaster)
        {
            // Call a new helper method on the Wallmaster to handle the state changes
            wallmaster.GrabPlayer(player);

            // Return immediately! We do NOT want standard knockback or standard damage.
            return;
        }

        // 4. SPECIAL CASE: OldMan NPC, No damage or collision
        if (enemy is OldMan)
        {
            return;
        }

        // Determine knockback direction based on collision side
        Vector2 knockbackDirection = GetKnockbackDirection(player, enemy, intersection);

        // Apply knockback to player
        ApplyKnockback(player, knockbackDirection);

        // Damage the player
        int damageToTake;
        _ = player.playerInventory.hasRedRing == true ? damageToTake = 1 : damageToTake = 2;
        player.TakeDamage(damageToTake); // Each collision with any enemy causes 1 damage, adjust as needed
    }

    private bool DetermineSuccessfulPlayerAttack(Link player, IEnemy enemy, Rectangle intersection)
    {
        bool res = false;
        Vector2 playerCenter = new Vector2(player.Hitbox.Center.X, player.Hitbox.Center.Y);
        Vector2 enemyCenter = new Vector2(enemy.Hitbox.Center.X, enemy.Hitbox.Center.Y);

        Vector2 direction = playerCenter - enemyCenter;

        if(enemy is Dodongo)
        {
            return false;
        }

        if(Math.Abs(direction.X) < Math.Abs(direction.Y))
        {
            // vertical collision
            if(direction.Y < 0)
            {
                // player is above enemy
                res = player.playerState is DownAttackingPlayerState;
            } else
            {
                res = player.playerState is UpAttackingPlayerState;
            }
        } else if(Math.Abs(direction.X) > Math.Abs(direction.Y))
        {
            // horizontal collision
            if(direction.X < 0)
            {
                // player is left of enemy
                res = player.playerState is RightAttackingPlayerState;
            } else
            {
                res = player.playerState is LeftAttackingPlayerState;
            }
        } else
        {
            // weird edge case just give it to the player
            //res = true;
        }

        return res;
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
        float knockbackStrength = 32f;

        // Apply the knockback to player position
        player.position += knockbackDirection * knockbackStrength;
    }

    private void ApplyKnockback(IEnemy enemy, Vector2 knockbackDirection)
    {
        float knockbackStrength = 32f;
        enemy.position += knockbackDirection * knockbackStrength;
    }
}
