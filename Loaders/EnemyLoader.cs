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

    public void LoadEnemiesFromRoom(XElement roomNode)
    {
        enemyController.enemyArray.Clear();

        var enemiesNode = roomNode.Element("Enemies");
        if (enemiesNode == null)
            return;

        foreach (var enemyElement in enemiesNode.Elements("Enemy"))
        {
            string type = enemyElement.Attribute("type")?.Value;
            float x = float.Parse(enemyElement.Attribute("x")?.Value ?? "0");
            float y = float.Parse(enemyElement.Attribute("y")?.Value ?? "0");

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