using Microsoft.Xna.Framework;

public class EnemySpikeCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        SpikeTile spike = obj1 as SpikeTile ?? obj2 as SpikeTile;

        if (enemy == null || spike == null)
            return;

        if (!spike.HitboxActive)
            return;

        enemy.TakeDamage(1);
    }
}