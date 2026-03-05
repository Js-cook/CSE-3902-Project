using Microsoft.Xna.Framework;
using System.Threading;

public class DeadBatState : IEnemyState
{
    private Bat bat;
    private BatSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadBatState(Bat bat, BatSpriteFactory spriteFactory)
    {
        this.bat = bat;
        this.spriteFactory = spriteFactory;
        bat.isDead = true;
        bat.HitboxActive = false;

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

    public void OnWallCollision()
    {
        // No movement when dead, so no wall collision logic needed.
    }
}