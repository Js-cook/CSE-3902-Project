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
            { "Aquamentus", enemyFactory.CreateAquamentus }
            
        };
    }
    public void ClearEnemies()
    {
        enemyController.enemyArray.Clear();
    }

    public void LoadEnemiesFromRoom(XElement roomNode)
    {
        enemyController.enemyArray.Clear();

        var enemiesNode = roomNode.Element("Enemies");
        if (enemiesNode == null)
            return;

        foreach (var enemyElement in enemiesNode.Elements("Enemy"))
        {
            string type = enemyElement.Attribute("type")?.Value;

            string xSrc = enemyElement.Attribute("x")?.Value;
            string ySrc = enemyElement.Attribute("y")?.Value;

            const int tileSize = 32 * 2;
            const int hudHeight = 112 * 2;
            const int wallOffset = 64;
            Vector2 gridOffset = new Vector2(wallOffset * 2, hudHeight + wallOffset * 2);

            float x = gridOffset.X + (int.Parse(xSrc) * tileSize);
            float y = gridOffset.Y + (int.Parse(ySrc) * tileSize);

            Vector2 position = new Vector2(x, y);

            if (type != null && enemyMap.ContainsKey(type))
            {
                IEnemy enemy = enemyMap[type](position);
                enemy.HitboxActive = true;
                enemyController.AddEnemy(enemy);
            }
        }
    }
}