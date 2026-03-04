using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

/// <summary>
/// Loads in the enemies (hardcoded for now) and manages active enemies
/// </summary>
public class EnemyController
{

    public List<IEnemy> enemyArray { get; set; } = new List<IEnemy>();

    public EnemyController()
    {
        enemyArray = new List<IEnemy>();


    }

    public void AddEnemy(IEnemy enemy)
    {
        enemyArray.Add(enemy);
    }



    public void Update(GameTime gameTime)
    {
        foreach (var enemy in enemyArray)
        {
            if (enemy.isDead)
            {
                enemyArray.Remove(enemy);
                break; // Exit the loop to avoid modifying the collection while iterating
            }
            enemy.Update(gameTime);
        }


    }

    public void Draw()
    {
        foreach (var enemy in enemyArray)
        {
            if (enemy.isDead)
            { enemyArray.Remove(enemy);
                break; // Exit the loop to avoid modifying the collection while iterating
            }
            enemy.Draw();
        }
    }
}

