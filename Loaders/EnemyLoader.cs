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
            { "Bat", enemyFactory.CreateBat }

        };
    }
    public void ClearEnemies()
    {
        enemyController.enemyArray.Clear();
    }

    public void LoadEnemiesFromRoom(List<EnemyDefinition> enemies)
    {
        enemyController.enemyArray.Clear();

        if (enemies == null || enemies.Count == 0)
            return;

        const int tileSize = 32 * 2;
        const int hudHeight = 112 * 2;
        const int wallOffset = 64;
        Vector2 gridOffset = new Vector2(wallOffset * 2, hudHeight + wallOffset * 2);

        foreach (var enemyDef in enemies)
        {
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