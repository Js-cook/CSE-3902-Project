using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Enums;

/// <summary>
/// Loads in the enemies (hardcoded for now) and manages active enemies
/// </summary>
public class EnemyController
{

    public List<IEnemy> enemyArray { get; set; } = new List<IEnemy>();
    
    private Dictionary<string, SoundEffect> sfx;
    private AudioController audioController = new();
    public event Action AllEnemiesKilled;
    private ItemController itemController;
    private Random random;

    public EnemyController(Dictionary<string, SoundEffect> sfx, ItemController itemController)
    {
        enemyArray = new List<IEnemy>();
        this.sfx = sfx;
        this.itemController = itemController;
        random = new Random();

    }

    public void AddEnemy(IEnemy enemy)
    {
        enemyArray.Add(enemy);
    }



    public void Update(GameTime gameTime)
    {
        bool removedDead = false;
        for (int i = enemyArray.Count - 1; i >= 0; i--)
        {
            var enemy = enemyArray[i];
            if (enemy.isDead)
            {
                audioController.PlaySoundEffect(sfx["EnemyDie"], 0.75f);
                enemyArray.RemoveAt(i); // Remove after playing sound
                removedDead = true;
                SpawnRandomItem(enemy.position);
                
            }
            else
            {
                enemy.Update(gameTime);
            }
        }

        if (removedDead && enemyArray.Count == 0)
        {
            AllEnemiesKilled?.Invoke();
        }
    }

    public void Draw()
    {
        foreach (var enemy in enemyArray)
        {

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

    private void SpawnRandomItem(Vector2 position)
    {
        int roll = random.Next(0, 101);

        if (roll < 50)
        {
            itemController.SpawnItem(ItemType.Heart, position); // Example position
        }
        else if (roll < 75)
        {
            itemController.SpawnItem(ItemType.Rupee, position); // Example position
        }
        else if (roll < 90)
        {
            itemController.SpawnItem(ItemType.Key, position); // Example position
        }
        else if (roll < 95)
        {
            itemController.SpawnItem(ItemType.Fairy, position); // Example position
        }
    }
}






