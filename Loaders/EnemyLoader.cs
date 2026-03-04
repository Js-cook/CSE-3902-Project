using Microsoft.Xna.Framework;

/// <summary>
/// Temporary fix to load enemies in a hardcoded way
/// </summary>
/// 
public class EnemyLoader
{
    private EnemyFactory enemyFactory;
    private EnemyController enemyController;

    public EnemyLoader(EnemyFactory enemyFactory, EnemyController enemyController)
    {
        this.enemyFactory = enemyFactory;
        this.enemyController = enemyController;
    }



    /// <summary>
    /// Loads in the enemies and adds them to Enemy Controller's enemy array. Also activates the hitboxes for the loaded enemies
    /// </summary>
    public void LoadFakeLevel()
    {
        //Here, you would call the enmyFactory to load whatever enemies you wnat to load
        //And then you would add those enemies to the EnemyController's enemy array

        enemyController.AddEnemy(enemyFactory.CreateGel(new Vector2(100, 100)));
        enemyController.AddEnemy(enemyFactory.CreateAquamentus(new Vector2(200, 200)));
        enemyController.AddEnemy(enemyFactory.CreateGel(new Vector2(20, 50)));
        enemyController.AddEnemy(enemyFactory.CreateGoriya(new Vector2(300, 300)));

        foreach (var enemy in enemyController.enemyArray)
        {
            enemy.HitboxActive = true;
        }





    }
}