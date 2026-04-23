using Microsoft.Xna.Framework;


/// <summary>
/// Factory class for creating enemy instances. It takes in the necessary sprite factories and graphics device manager to create enemies with the correct sprites and graphics settings.
/// </summary>
public class EnemyFactory
{
    private EnemyMasterSpriteFactory enemyMasterSpriteFactory;
    private EnemyProjectileSpriteFactory enemyProjectileSpriteFactory;
    private GraphicsDeviceManager _graphics;
    private BossProjectileSpriteFactory bossProjectileSpriteFactory;
    public EnemyFactory(GraphicsDeviceManager _graphics, EnemyMasterSpriteFactory enemyMasterSpriteFactory)
    {
        this.enemyProjectileSpriteFactory = enemyMasterSpriteFactory.enemyProjectileSpriteFactory;
        this._graphics = _graphics;
        this.enemyMasterSpriteFactory = enemyMasterSpriteFactory;
        bossProjectileSpriteFactory = enemyMasterSpriteFactory.bossProjectileSpriteFactory;
    }

    public Gel CreateGel(Vector2 startPos)
    {
        return new Gel(enemyMasterSpriteFactory.gelSpriteFactory, _graphics, startPos);
    }
    
    public Bat CreateBat(Vector2 startPos)
    {
        return new Bat(enemyMasterSpriteFactory.batSpriteFactory, _graphics, startPos);
    }
    
    public Goriya CreateGoriya(Vector2 startPos)
    {
        return new Goriya(enemyMasterSpriteFactory.goriyaSpriteFactory, _graphics, enemyProjectileSpriteFactory, startPos);
    }
    
    public Skeleton CreateSkeleton(Vector2 startPos)
    {
        return new Skeleton(enemyMasterSpriteFactory.skeletonSpriteFactory, _graphics, startPos);
    }
    
    public Wallmaster CreateWallmaster(Vector2 startPos)
    {
        return new Wallmaster(enemyMasterSpriteFactory.wallmasterSpriteFactory, startPos);
    }
    
    public Aquamentus CreateAquamentus(Vector2 startPos)
    {
        return new Aquamentus(enemyMasterSpriteFactory.aquamentusSpriteFactory, _graphics, bossProjectileSpriteFactory, startPos);
    }

    public OldMan CreateOldMan(Vector2 startPos)
    {
        return new OldMan(enemyMasterSpriteFactory.oldManSpriteFactory, _graphics, startPos);
    }
    
    public Dodongo CreateDodongo(Vector2 startPos)
    {
        return new Dodongo(enemyMasterSpriteFactory.dodongoSpriteFactory, _graphics, startPos);
    }
}