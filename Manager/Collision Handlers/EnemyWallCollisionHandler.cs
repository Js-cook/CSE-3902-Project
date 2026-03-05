using Microsoft.Xna.Framework;

public class EnemyWallCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        Tile tile = obj1 as Tile ?? obj2 as Tile;

        if (enemy == null || tile == null)
            return;

        // Only process collision if tile is solid
        if (!tile.IsSolid)
            return;

        // Resolve the collision by pushing player out of the tile
        ResolveCollision(enemy, tile.Hitbox, intersection);
    }

    private void ResolveCollision(IEnemy enemy, Rectangle tileHitbox, Rectangle intersection)
    {
        //TODO: THIS WORKS FOR NOW BUT NEED TO CHNAGE STATE OF ENEMY


        // Push player out based on smallest overlap dimension. T

        // This prevents player from getting stuck in corners
        // Add a small buffer (1-2 pixels)  to create separation from walls 
        const int wallBuffer = 2;

        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision - push left or right
            if (enemy.Hitbox.Center.X < tileHitbox.Center.X)
            {
                // Player is to the left of tile - push left with buffer
                enemy.position = new Vector2(
                    tileHitbox.Left - enemy.Hitbox.Width - wallBuffer,
                    enemy.position.Y
                );
            }
            else
            {
                // Player is to the right of tile - push right with buffer
                enemy.position = new Vector2(
                    tileHitbox.Right + wallBuffer,
                    enemy.position.Y
                );
            }
        }
        else
        {
            // Vertical collision - push up or down
            if (enemy.Hitbox.Center.Y < tileHitbox.Center.Y)
            {
                // Player is above tile - push up with buffer
                enemy.position = new Vector2(
                    enemy.position.X,
                    tileHitbox.Top - enemy.Hitbox.Height - wallBuffer
                );
            }
            else
            {
                // Player is below tile - push down with buffer
                enemy.position = new Vector2(
                        enemy.position.X,
                    tileHitbox.Bottom + wallBuffer
                );
            }
        }
    }
}
