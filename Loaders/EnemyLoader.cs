using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class EnemyLoader
{
    private EnemyFactory enemyFactory;
    private EnemyController enemyController;
    private Dictionary<string, Func<Vector2, IEnemy>> enemyMap;

    public EnemyLoader(EnemyFactory enemyFactory, EnemyController enemyController)
    {
        this.enemyFactory = enemyFactory;
        this.enemyController = enemyController;

        enemyMap = new Dictionary<string, Func<Vector2, IEnemy>>()
        {
            { "Gel", enemyFactory.CreateGel },
            { "Goriya", enemyFactory.CreateGoriya },
            { "Aquamentus", enemyFactory.CreateAquamentus },
            { "Skeleton", enemyFactory.CreateSkeleton },
            { "Bat", enemyFactory.CreateBat },
            { "OldMan", enemyFactory.CreateOldMan },
            { "WallmasterManager", enemyFactory.CreateWallmaster}


        };
    }
    public void ClearEnemies()
    {
        enemyController.enemyArray.Clear();
    }

    public void LoadEnemiesFromRoom(List<EnemyDefinition> enemies, Link player, RoomManager roomManager)
    {
        enemyController.enemyArray.Clear();

        if (enemies == null || enemies.Count == 0)
            return;

        const int tileSize = 32 * 2;
        const int hudHeight = 112 * 2;
        const int wallOffset = 64;
        Vector2 gridOffset = new Vector2(wallOffset * 2, hudHeight + wallOffset * 2);

        // Build the room boundary rectangle
        Rectangle roomBounds = new Rectangle(
            (int)gridOffset.X,
            (int)gridOffset.Y,
            12 * tileSize,
            7 * tileSize
        );

        foreach (var enemyDef in enemies)
        {
            if (enemyDef.Type == "WallmasterManager")
            {
                // Create a local reference to the parameter you just passed in
                // This ensures the lambda captures the ACTIVE instance, not the variable in Game1
                RoomManager currentManager = roomManager;
                Link currentPlayer = player;

                WallmasterManager manager = new WallmasterManager(roomBounds, currentPlayer, enemyFactory);

                // Use the LOCAL variables in the lambda
                manager.OnResetDungeon = () =>
                {
                    if (currentManager != null && currentPlayer != null)
                    {
                        currentManager.ResetDungeon(currentPlayer);
                    }
                    else
                    {
                        // This will print to your Output window if something is still wrong
                        System.Diagnostics.Debug.WriteLine("Wallmaster tried to reset, but Manager/Player was NULL!");
                    }
                };

                manager.InitializeHands(enemyDef.count);
                enemyController.AddEnemy(manager);
                continue;
            }

            float x = gridOffset.X + (enemyDef.X * tileSize);
            float y = gridOffset.Y + (enemyDef.Y * tileSize);

            Vector2 position = new Vector2(x, y);

            if (enemyDef.Type != null && enemyMap.ContainsKey(enemyDef.Type))
            {
                IEnemy enemy = enemyMap[enemyDef.Type](position);
                enemy.HitboxActive = true;
                enemyController.AddEnemy(enemy);
            }
        }
    }
}