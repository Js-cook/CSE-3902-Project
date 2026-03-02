using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public static class CollisionRegistry
{
    public static void Initialize(CollisionManager collisionManager)
    {
        // Get all types in your project assembly. Citation: GEMINI AI
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        var enemyTypes = allTypes.Where(t => typeof(IEnemy).IsAssignableFrom(t) && !t.IsInterface);
        var projectileTypes = allTypes.Where(t => typeof(IProjectile).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var eType in enemyTypes)
        {
            foreach (var pType in projectileTypes)
            {
                collisionManager.RegisterHandler(eType, pType, new EnemyProjectileCollisionHandler());
            }
        }
    }

}