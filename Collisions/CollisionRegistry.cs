using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public static class CollisionRegistry
{
    public static void Initialize(CollisionManager collisionManager, RoomManager roomManager, TileFactory tileFactory)
    {
        RegisterEnemyPlayerProjectileCollisions(collisionManager);
        RegisterEnemyWallAndDoorwayCollisions(collisionManager);
        RegisterPlayerCollisions(collisionManager, roomManager, tileFactory);
        RegisterPlayerItemCollisions(collisionManager);
        RegisterProjectileWallCollisions(collisionManager);
        RegisterFairyWallCollision(collisionManager);


    }

    private static void RegisterEnemyPlayerProjectileCollisions(CollisionManager collisionManager)
    {
        // Get all types in your project assembly. Citation: GEMINI AI
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        //TODO - Explanation needed
        var enemyTypes = allTypes.Where(t => typeof(IEnemy).IsAssignableFrom(t) && !t.IsInterface);
        var projectileTypes = allTypes.Where(t => typeof(IProjectile).IsAssignableFrom(t) && !t.IsInterface);
        foreach (var eType in enemyTypes)
        {
            foreach (var pType in projectileTypes)
            {
                collisionManager.RegisterHandler(eType, pType, new EnemyPlayerProjectileCollisionHandler());
            }
        }
    }

    private static void RegisterProjectileWallCollisions(CollisionManager collisionManager)
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();
        var projectileTypes = allTypes.Where(t => typeof(IProjectile).IsAssignableFrom(t) && !t.IsInterface);
        foreach (var pType in projectileTypes)
        {
            collisionManager.RegisterHandler(pType, typeof(Tile), new ProjectileWallCollisionHandler());
        }
    }

    private static void RegisterEnemyWallAndDoorwayCollisions(CollisionManager collisionManager)
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();
        var enemyTypes = allTypes.Where(t => typeof(IEnemy).IsAssignableFrom(t) && !t.IsInterface);
        // Get all types in your project assembly. Citation: GEMINI AI
        foreach (var eType in enemyTypes)
        {
            collisionManager.RegisterHandler(eType, typeof(Tile), new EnemyWallCollisionHandler());
            collisionManager.RegisterHandler(eType, typeof(SpikeTile), new EnemySpikeCollisionHandler());
            collisionManager.RegisterHandler(eType, typeof(Doorway), new EnemyDoorwayCollisionHandler());
        }


    }

    private static void RegisterPlayerCollisions(CollisionManager collisionManager, RoomManager roomManager, TileFactory tileFactory)
    {
        // Create shared handler instances
        PlayerEnemyCollisionHandler playerEnemyHandler = new PlayerEnemyCollisionHandler();
        PlayerEnemyProjectileCollisionHandler playerProjectileHandler = new PlayerEnemyProjectileCollisionHandler();
        PlayerWallCollisionHandler playerWallHandler = new PlayerWallCollisionHandler();
        PlayerSpikeCollisionHandler playerSpikeHandler = new PlayerSpikeCollisionHandler();
        PlayerTreasureChestCollisionHandler playerChestHandler = new PlayerTreasureChestCollisionHandler();
        PlayerDoorwayCollisionHandler playerDoorwayHandler = new PlayerDoorwayCollisionHandler(roomManager, tileFactory);
        // Register Player vs Enemy collisions for all enemy types
        collisionManager.RegisterHandler(typeof(Link), typeof(Bat), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Gel), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Goriya), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Skeleton), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Wallmaster), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Spiketrap), playerEnemyHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Aquamentus), playerEnemyHandler);

        // Register Player vs Enemy Projectiles
        collisionManager.RegisterHandler(typeof(Link), typeof(GoriyaBoomerang), playerProjectileHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(AquamentusFireball), playerProjectileHandler);

        // Register Player vs Tiles (walls, blocks, etc.)
        collisionManager.RegisterHandler(typeof(Link), typeof(Tile), playerWallHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(SpikeTile), playerSpikeHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(TreasureChest), playerChestHandler);
        collisionManager.RegisterHandler(typeof(Link), typeof(Doorway), playerDoorwayHandler);

    }

    // Register Player and Items Collisions
    private static void RegisterPlayerItemCollisions(CollisionManager collisionManager)
    {
        collisionManager.RegisterHandler(typeof(Link), typeof(PickupItem), new PlayerItemCollisionHandler());

    }

    private static void RegisterFairyWallCollision(CollisionManager collisionManager)
    {

        collisionManager.RegisterHandler(typeof(PickupItem), typeof(Tile), new FairyWallCollisionHandler());

    }


   

}