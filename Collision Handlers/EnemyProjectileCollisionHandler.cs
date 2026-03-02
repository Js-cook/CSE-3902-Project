using Microsoft.Xna.Framework;

public class EnemyProjectileCollisionHandler : ICollisionHandler
{
    public EnemyProjectileCollisionHandler()
    {
    }
    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        IEnemy enemy = obj1 as IEnemy ?? obj2 as IEnemy;
        IProjectile projectile = obj1 as IProjectile ?? obj2 as IProjectile;
        if (projectile != null && enemy != null)
        {
           
            projectile.OnCollision();
            enemy.TakeDamage(projectile.DamageValue);
            
        }

    }
}

