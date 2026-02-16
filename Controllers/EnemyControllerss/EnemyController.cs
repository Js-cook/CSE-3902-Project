using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class EnemyConroller {

    public List<IEnemy> enemyArray { get; set; } = new List<IEnemy>();

    private Gel gel;
    private Bat bat;

    private int index;

    public void LoadContent(ContentManager content, SpriteBatch _spriteBatch, GraphicsDeviceManager _graphics)
    {
        Texture2D enemyTexture = content.Load<Texture2D>("EnemySprites");
        Texture2D bossTexture = content.Load<Texture2D>("BossSprites");
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

        SpiketrapSpriteFactory spiketrapSpriteFactory = new SpiketrapSpriteFactory(enemyTexture, _spriteBatch);
        Spiketrap spiketrap = new Spiketrap(spiketrapSpriteFactory, _graphics);
        enemyArray.Add(spiketrap);

        AquamentusSpriteFactory aquamentusSpriteFactory = new AquamentusSpriteFactory(bossTexture, _spriteBatch);
        Aquamentus aquamentus = new Aquamentus(aquamentusSpriteFactory, _graphics, bossProjectileSpriteFactory);
        enemyArray.Add(aquamentus);



    }

    public void NextEnemy()
    {
        index++;
        if (index >= enemyArray.Count)
        {
            index = 0;
        }
    }

    public void PreviousEnemy()
    {
        index--;
        if (index < 0)
        {
            index = enemyArray.Count - 1;
        }
    }

    public EnemyConroller()
    {
        enemyArray = new List<IEnemy>();
    }

    public void Update(GameTime gameTime)
    {
        enemyArray[index].Update(gameTime);

    }

    public void Draw()
    {
        enemyArray[index].Draw();

    }











}

