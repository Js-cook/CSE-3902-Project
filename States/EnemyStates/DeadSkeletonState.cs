using Enums;
using Microsoft.Xna.Framework;
using System.Threading;

public class DeadSkeletonState : IEnemyState
{
    private Skeleton skeleton;
    private SkeletonSpriteFactory spriteFactory;

    public DeadSkeletonState(Skeleton skeleton, SkeletonSpriteFactory spriteFactory)
    {
        this.skeleton = skeleton;
        this.spriteFactory = spriteFactory;
        skeleton.isDead = true;
            skeleton.HitboxActive = false;
        EffectController.Instance.SpawnDeathCloud(skeleton.position);
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

    public void OnWallCollision(Direction newDir)
    {
        // No movement when dead, so no wall collision logic needed.
    }
}