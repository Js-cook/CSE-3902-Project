using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class EnemyController {

    public List<IEnemy> enemyArray { get; set; } = new List<IEnemy>();

    private int index;

    public void LoadContent(ContentManager content, SpriteBatch _spriteBatch, GraphicsDeviceManager _graphics)
    {
        Texture2D enemyTexture = content.Load<Texture2D>("EnemySprites");
        Texture2D bossTexture = content.Load<Texture2D>("BossSprites");
        Texture2D npcTexture = content.Load<Texture2D>("NPCSprites");
        EnemyProjectileSpriteFactory enemyProjectileSpriteFactory = new EnemyProjectileSpriteFactory(enemyTexture, _spriteBatch);
        BossProjectileSpriteFactory bossProjectileSpriteFactory = new BossProjectileSpriteFactory(bossTexture, _spriteBatch);



        GelSpriteFactory gelSpriteFactory = new GelSpriteFactory(enemyTexture, _spriteBatch);
        Gel gel = new Gel(gelSpriteFactory, _graphics);
        enemyArray.Add(gel);

        BatSpriteFactory batSpriteFactory = new BatSpriteFactory(enemyTexture, _spriteBatch);
        Bat bat = new Bat(batSpriteFactory, _graphics);
        enemyArray.Add(bat);

        GoriyaSpriteFactory goriyaSpriteFactory = new GoriyaSpriteFactory(enemyTexture, _spriteBatch);
        Goriya goriya = new Goriya(goriyaSpriteFactory, _graphics, enemyProjectileSpriteFactory);
        enemyArray.Add(goriya);

        SkeletonSpriteFactory skeletonSpriteFactory = new SkeletonSpriteFactory(enemyTexture, _spriteBatch);
        Skeleton skeleton = new Skeleton(skeletonSpriteFactory, _graphics);
        enemyArray.Add(skeleton);

        WallmasterSpriteFactory wallmasterSpriteFactory = new WallmasterSpriteFactory(enemyTexture, _spriteBatch);
        Wallmaster wallmaster = new Wallmaster(wallmasterSpriteFactory, _graphics);
        enemyArray.Add(wallmaster);

        AquamentusSpriteFactory aquamentusSpriteFactory = new AquamentusSpriteFactory(bossTexture, _spriteBatch);
        Aquamentus aquamentus = new Aquamentus(aquamentusSpriteFactory, _graphics, bossProjectileSpriteFactory);
        enemyArray.Add(aquamentus);

        enemyArray[0].HitboxActive = true; // Set the first enemy's hitbox to active by default
    }

    public void NextEnemy()
    {
        enemyArray[index].HitboxActive
            = false;
        index++;
        if (index >= enemyArray.Count)
        {
            index = 0;
        }
        enemyArray[index].HitboxActive
            = true;

    }

    public void PreviousEnemy()
    {
            enemyArray[index].HitboxActive
                = false;
        index--;
        if (index < 0)
        {
            index = enemyArray.Count - 1;
        }
        enemyArray[index].HitboxActive
            = true;
    }
    
    public void ResetEnemy()
    {
        index = 0;
    }

    public IEnemy CurrentEnemy()
    {
        return enemyArray[index];
    }

    public EnemyController()
    {
        enemyArray = new List<IEnemy>();
    }

    public void Update(GameTime gameTime)
    {
        if (enemyArray.Count == 0)
        {
            return;
            
        }
        if (index < enemyArray.Count && enemyArray.Count > 0)
        {


            if (enemyArray[index].isDead)
            {
                
                enemyArray[index].HitboxActive = false;
                enemyArray.RemoveAt(index);
                if (enemyArray.Count == 0)
                {
                    return;
                }
                if (index >= enemyArray.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                enemyArray[index].HitboxActive = true;
            }

            enemyArray[index].Update(gameTime);
        }
       

    }

    public void Draw()
    {
        if (index < enemyArray.Count && enemyArray.Count > 0)
        {
            enemyArray[index].Draw();
        }
    }
}

