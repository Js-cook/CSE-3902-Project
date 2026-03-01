using Microsoft.Xna.Framework;

public class BatBoomerangCollisionHandler : ICollisionHandler
{
    public BatBoomerangCollisionHandler()
    {
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Bat bat = obj1 as Bat ?? obj2 as Bat;
        Boomerang boomerang = obj1 as Boomerang ?? obj2 as Boomerang;
        if (boomerang != null && bat != null)
        {
            bat.TakeDamage(boomerang.DamageValue);
        }

    }
}

    