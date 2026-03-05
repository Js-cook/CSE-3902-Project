using Enums;
using Microsoft.Xna.Framework;
using System.Threading;

public class DeadGoriyaState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    public DeadGoriyaState(Goriya goriya, GoriyaSpriteFactory spriteFactory)
    {
        this.goriya = goriya;
        this.spriteFactory = spriteFactory;
        goriya.isDead = true; // This is the reason for this state, to set the isDead flag to true when the Goriya dies
        goriya.HitboxActive = false; // Deactivate hitbox when dead
    }
    public void ChangeDirection()
    {
        // No need for this 
    }
    public void BeDead()
    {
        // Maybe this can be useful
    }
    public void Update(GameTime gameTime)
    {
        // Maybe an animation can be played here
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