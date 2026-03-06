using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


/// <summary>
/// Loads all the textures and initializes the individual sprite factories for enemies to be used by the EnemyFactory to create individaul enemy instances
/// </summary>

public class EnemyMasterSpriteFactory
{
    // These need to be public properties so Levell loader can see them
    public GelSpriteFactory gelSpriteFactory { get; private set; }
    public BatSpriteFactory batSpriteFactory { get; private set; }
    public GoriyaSpriteFactory goriyaSpriteFactory { get; private set; }
    public SkeletonSpriteFactory skeletonSpriteFactory { get; private set; }
    public WallmasterSpriteFactory wallmasterSpriteFactory { get; private set; }
    public AquamentusSpriteFactory aquamentusSpriteFactory { get; private set; }

    public EnemyProjectileSpriteFactory enemyProjectileSpriteFactory { get; private set; }

    public BossProjectileSpriteFactory bossProjectileSpriteFactory { get; private set; }

    public EffectSpriteFactory effectSpriteFactory { get; private set; }

    public EnemyMasterSpriteFactory()
    {
        // Empty constructor
    }
    public void LoadContent(ContentManager content, SpriteBatch _spriteBatch, GraphicsDeviceManager _graphics)
    {
        Texture2D enemyTexture = content.Load<Texture2D>("EnemySprites");
        Texture2D bossTexture = content.Load<Texture2D>("BossSprites");
        Texture2D npcTexture = content.Load<Texture2D>("NPCSprites");
        

        gelSpriteFactory = new GelSpriteFactory(enemyTexture, _spriteBatch);

        batSpriteFactory = new BatSpriteFactory(enemyTexture, _spriteBatch);
            
        goriyaSpriteFactory = new GoriyaSpriteFactory(enemyTexture, _spriteBatch);
       
        skeletonSpriteFactory = new SkeletonSpriteFactory(enemyTexture, _spriteBatch);
        
        wallmasterSpriteFactory = new WallmasterSpriteFactory(enemyTexture, _spriteBatch);
        
        aquamentusSpriteFactory = new AquamentusSpriteFactory(bossTexture, _spriteBatch);
        bossProjectileSpriteFactory = new BossProjectileSpriteFactory(bossTexture, _spriteBatch);
        enemyProjectileSpriteFactory = new EnemyProjectileSpriteFactory(enemyTexture, _spriteBatch);
        




    }

  
}