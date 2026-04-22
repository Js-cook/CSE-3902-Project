using Microsoft.Xna.Framework;

public class SpikeWallCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Tile tile = obj1 as Tile ?? obj2 as Tile;
        SpikeTile spike = obj1 as SpikeTile ?? obj2 as SpikeTile;

        if (tile == null || spike == null)
            return;

        if (!spike.HitboxActive)
            return;

        if (!tile.IsSolid)
            return;

        spike.OnWallCollision();

      




    }
}