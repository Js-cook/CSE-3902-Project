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
    public event Action BossDeath; // Triggered when Aquamentus dies
    public event Action DodongoDeath;
    private ItemController itemController;
    private Random random;

    // Freeze state for clock item
    private bool isFrozen = false;
    private float freezeTimer = 0f;

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
        // Handle freeze timer
        if (isFrozen)
        {
            freezeTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (freezeTimer <= 0)
            {
                isFrozen = false;
                freezeTimer = 0f;
            }
            return;
        }

        bool removedDead = false;

        int initialCount = enemyArray.Count;

        for (int i = enemyArray.Count - 1; i >= 0; i--)
        {
           
            if (i >= enemyArray.Count) break;

            var enemy = enemyArray[i];
            if (enemy.isDead)
            {
                audioController.PlaySoundEffect(sfx["EnemyDie"], 0.75f);
                enemyArray.RemoveAt(i);
                removedDead = true;

                if (enemy is Aquamentus)
                {
                  
                    BossDeath?.Invoke(); // Trigger boss death event for diamond doors
                }

                if (enemy is Dodongo)
                {
                    DodongoDeath?.Invoke();
                }
                SpawnRandomItem(enemy.position);
            }
            else
            {
                enemy.Update(gameTime);

              
                if (enemyArray.Count != initialCount && i > 0)
                {
                   
                    return;
                }
            }
        }

        // Debug: Show enemy count after removals
        if (removedDead)
        {
            System.Diagnostics.Debug.WriteLine($"*** ENEMY DIED - Remaining enemies: {enemyArray.Count}");
        }

        if (removedDead && enemyArray.Count == 0)
        {
            Console.WriteLine("=== ALL ENEMIES KILLED! FIRING EVENT ===");
            System.Diagnostics.Debug.WriteLine("*** ALL ENEMIES KILLED - FIRING EVENT");
            AllEnemiesKilled?.Invoke();
            Console.WriteLine($"=== AllEnemiesKilled event has {AllEnemiesKilled?.GetInvocationList().Length ?? 0} subscribers ===");
        }
    }
    public void FreezeEnemies(float durationMs)
    {
        isFrozen = true;
        freezeTimer = durationMs;
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






