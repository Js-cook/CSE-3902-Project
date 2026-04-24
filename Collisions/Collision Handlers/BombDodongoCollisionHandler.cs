using Microsoft.Xna.Framework;

public class BombDodongoCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Bomb bomb = obj1 as Bomb ?? obj2 as Bomb;
        Dodongo dodongo = obj1 as Dodongo ?? obj2 as Dodongo;

        if (bomb != null && dodongo != null)
        {
            // Only apply damage if bomb is a player projectile
            if (!bomb.isPlayerProjectile)
                return;

            // Deal bomb damage to Dodongo (only source of damage for Dodongo)
            dodongo.TakeBombDamage(1);

            // Destroy the bomb on collision
            bomb.OnDodongoConsumption();
        }
    }
}
