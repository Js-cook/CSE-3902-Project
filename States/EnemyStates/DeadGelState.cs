using Enums;
using Microsoft.Xna.Framework;
using System.Threading;

public class DeadGelState : IEnemyState
{
    private Gel gel;
    private GelSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadGelState(Gel gel, GelSpriteFactory spriteFactory)
    {
        this.gel = gel;
        this.spriteFactory = spriteFactory;
        gel.isDead = true;
            gel.HitboxActive = false;
        EffectController.Instance.SpawnDeathCloud(gel.position);
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