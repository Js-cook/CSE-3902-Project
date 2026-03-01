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
}