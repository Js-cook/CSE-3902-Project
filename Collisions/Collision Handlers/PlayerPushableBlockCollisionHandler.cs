using Microsoft.Xna.Framework;

public class PlayerPushableBlockCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        PushableBlock block = obj1 as PushableBlock ?? obj2 as PushableBlock;

        if (player == null || block == null)
            return;

        // If already pushed, treat it like a solid wall (no pushing, just collision)
        if (block.HasBeenPushed)
        {
            ResolvePlayerCollision(player, block.Hitbox, intersection);
            return;
        }

        int pushDirection = PushableBlock.GetDirectionFromPositions(player.Hitbox, block.Hitbox);

        bool pushSucceeded = block.TryPush(pushDirection);

        if (!pushSucceeded)
        {
            ResolvePlayerCollision(player, block.Hitbox, intersection);
        }
    }

    private void ResolvePlayerCollision(Link player, Rectangle blockHitbox, Rectangle intersection)
    {
        const int wallBuffer = 2;

        if (intersection.Width < intersection.Height)
        {
            if (player.Hitbox.Center.X < blockHitbox.Center.X)
            {
                player.position = new Vector2(
                    blockHitbox.Left - player.Hitbox.Width - wallBuffer,
                    player.position.Y
                );
            }
            else
            {
                player.position = new Vector2(
                    blockHitbox.Right + wallBuffer,
                    player.position.Y
                );
            }
        }
        else
        {
            if (player.Hitbox.Center.Y < blockHitbox.Center.Y)
            {
                player.position = new Vector2(
                    player.position.X,
                    blockHitbox.Top - player.Hitbox.Height - wallBuffer
                );
            }
            else
            {
                player.position = new Vector2(
                    player.position.X,
                    blockHitbox.Bottom + wallBuffer
                );
            }
        }
    }
}
