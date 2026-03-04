using Microsoft.Xna.Framework;
using System.Threading;

public class DeadGoriyaState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    int timer = 0;
    int timerMax = 5;
    public DeadGoriyaState(Goriya goriya, GoriyaSpriteFactory spriteFactory)
    {
        this.goriya = goriya;
        this.spriteFactory = spriteFactory;
        goriya.isDead = true;
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