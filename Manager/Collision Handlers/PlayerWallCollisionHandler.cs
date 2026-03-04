using Microsoft.Xna.Framework;

public class PlayerWallCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        Tile tile = obj1 as Tile ?? obj2 as Tile;

        if (player == null || tile == null)
            return;

        // Only process collision if tile is solid
        if (!tile.IsSolid)
            return;

        // Resolve the collision by pushing player out of the tile
        ResolveCollision(player, tile.Hitbox, intersection);
    }

    private void ResolveCollision(Link player, Rectangle tileHitbox, Rectangle intersection)
    {
        // Push player out based on smallest overlap dimension
        // This prevents player from getting stuck in corners
        // Add a small buffer (1-2 pixels) to create separation from walls
        const int wallBuffer = 2;

        if (intersection.Width < intersection.Height)
        {   
            // Horizontal collision - push left or right
            if (player.Hitbox.Center.X < tileHitbox.Center.X)
            {
                // Player is to the left of tile - push left with buffer
                player.position = new Vector2(
                    tileHitbox.Left - player.Hitbox.Width - wallBuffer,
                    player.position.Y
                );
            }
            else
            {
                // Player is to the right of tile - push right with buffer
                player.position = new Vector2(
                    tileHitbox.Right + wallBuffer,
                    player.position.Y
                );
            }
        }
        else
        {
            // Vertical collision - push up or down
            if (player.Hitbox.Center.Y < tileHitbox.Center.Y)
            {
                // Player is above tile - push up with buffer
                player.position = new Vector2(
                    player.position.X,
                    tileHitbox.Top - player.Hitbox.Height - wallBuffer
                );
            }
            else
            {
                // Player is below tile - push down with buffer
                player.position = new Vector2(
                    player.position.X,
                    tileHitbox.Bottom + wallBuffer
                );
            }
        }
    }
}
