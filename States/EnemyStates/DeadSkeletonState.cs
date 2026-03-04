using Microsoft.Xna.Framework;
using System.Threading;

public class DeadSkeletonState : IEnemyState
{
    private Skeleton skeleton;
    private SkeletonSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadSkeletonState(Skeleton skeleton, SkeletonSpriteFactory spriteFactory)
    {
        this.skeleton = skeleton;
        this.spriteFactory = spriteFactory;
        skeleton.isDead = true;
            skeleton.HitboxActive = false;
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