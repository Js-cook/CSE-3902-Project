using Microsoft.Xna.Framework;
using System.Threading;

public class DeadWallmasterState : IEnemyState
{
    private Wallmaster wallmaster;
    private WallmasterSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadWallmasterState(Wallmaster wallmaster, WallmasterSpriteFactory spriteFactory)
    {
        this.wallmaster = wallmaster;
        this.spriteFactory = spriteFactory;
        wallmaster.isDead = true;
            wallmaster.HitboxActive = false;
    }
    public void ChangeDirection()
    {
        // No need for this 
    }
    public void BeDead()
    {

    }
    public void Update(GameTime gameTime)
    {

    }

    public void TakeDamage()
    {
        // No need for this
    }
}