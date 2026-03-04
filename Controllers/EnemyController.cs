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

    public List<IProjectile> GetAllEnemyProjectiles()
    {
        List<IProjectile> projectiles = new List<IProjectile>();

        foreach (var enemy in enemyArray)
        {
            // Check if it's a Goriya with a boomerang
            if (enemy is Goriya goriya)
            {
                if (goriya.goriyaBoomerang != null && goriya.goriyaBoomerang.Active)
                {
                    projectiles.Add(goriya.goriyaBoomerang);
                }
            }

            // Check if it's Aquamentus with fireballs
            if (enemy is Aquamentus aquamentus)
            {
                if (aquamentus.topFireball != null && aquamentus.topFireball.Active)
                    projectiles.Add(aquamentus.topFireball);
                if (aquamentus.middleFireball != null && aquamentus.middleFireball.Active)
                    projectiles.Add(aquamentus.middleFireball);
                if (aquamentus.bottomFireball != null && aquamentus.bottomFireball.Active)
                    projectiles.Add(aquamentus.bottomFireball);
            }
        }

        return projectiles;
    }
}





