using Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DamagedSkeletonState : IEnemyState
{
    private Skeleton skeleton;
    private SkeletonSpriteFactory spriteFactory;

    double timerMax = 1;
    double timer;

    public DamagedSkeletonState(Skeleton skeleton, SkeletonSpriteFactory spriteFactory)
    {
        this.skeleton = skeleton;
        this.spriteFactory = spriteFactory;
        skeleton.Sprite = spriteFactory.CreateDamagedSkeletonSprite(skeleton.position);
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
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if(timer >= timerMax)
        {
            skeleton.ChangeState(new MovingSkeletonState(skeleton, spriteFactory));
        }
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
