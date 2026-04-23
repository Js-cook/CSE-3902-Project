using Microsoft.Xna.Framework;

public class PlayerSpikeCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        SpikeTile spike = obj1 as SpikeTile ?? obj2 as SpikeTile;

        if (player == null || spike == null)
            return;

        if (!spike.HitboxActive)
            return;

        if (!player.Hurt)
        {
            int damageToTake = (int)spike.DamageValue;
            _ = player.playerInventory.hasRedRing ? (damageToTake /= 2) : damageToTake;
            player.TakeDamage(damageToTake);
        }
    }
}