using Enums;
using Microsoft.Xna.Framework;
using System.Threading;

public class DeadAquamentusState : IEnemyState
{
    private Aquamentus aquamentus;
    private AquamentusSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadAquamentusState(Aquamentus aquamentus, AquamentusSpriteFactory spriteFactory)
    {
        this.aquamentus = aquamentus;
        this.spriteFactory = spriteFactory;
        aquamentus.isDead = true;
            aquamentus.HitboxActive = false;
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
        // No need for this
    }
}