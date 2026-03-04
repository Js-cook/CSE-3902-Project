using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public static class CollisionRegistry
{
    public static void Initialize(CollisionManager collisionManager)
    {
        RegisterEnemyProjectileCollisions(collisionManager);
        RegisterPlayerCollisions(collisionManager);


    }

    private static void RegisterEnemyProjectileCollisions(CollisionManager collisionManager)
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

    private static void RegisterPlayerCollisions(CollisionManager collisionManager)
    {
        // Create shared handler instances
        PlayerEnemyCollisionHandler playerEnemyHandler = new PlayerEnemyCollisionHandler();
        PlayerProjectileCollisionHandler playerProjectileHandler = new PlayerProjectileCollisionHandler();
        PlayerWallCollisionHandler playerWallHandler = new PlayerWallCollisionHandler();

        // Register Player vs Enemy collisions for all enemy types
        collisionManager.RegisterHandler(typeof(Link), typeof(Bat), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Gel), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Goriya), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Skeleton), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Wallmaster), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Spiketrap), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Aquamentus), playerEnemyHandler);

        // Register Player vs Enemy Projectiles  // ← ADD THIS SECTION
        collisionManager.RegisterHandler(typeof(Link), typeof(GoriyaBoomerang), playerProjectileHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(AquamentusFireball), playerProjectileHandler);

        // Register Player vs Tiles (walls, blocks, etc.)  // ← ADD THIS SECTION
        collisionManager.RegisterHandler(typeof(Link), typeof(Tile), playerWallHandler);


    }

}