using Microsoft.Xna.Framework;

public class SpikeDoorwayCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;
        SpikeTile spike = obj1 as SpikeTile ?? obj2 as SpikeTile;

        if (doorway == null || spike == null)
            return;

        if (!spike.HitboxActive)
            return;

       

        spike.OnWallCollision();






    }
}