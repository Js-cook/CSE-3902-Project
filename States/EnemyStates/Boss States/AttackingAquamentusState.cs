using Microsoft.Xna.Framework;
using System;

public class AttackingAquamentusState : IEnemyState
{
    private Aquamentus aquamentus;
    private AquamentusSpriteFactory spriteFactory;

    double timerMax = 1;
    double timer;

    private Vector2 velocity;
    private Random randInt;

    private GraphicsDeviceManager _graphics;
    public AttackingAquamentusState(Aquamentus aquamentus, AquamentusSpriteFactory aquamentusSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.aquamentus = aquamentus;
        this.spriteFactory = aquamentusSpriteFactory;
        timer = 0;

        velocity = new Vector2(1, 0);
        randInt = new Random();
        this._graphics = _graphics;

        aquamentus.topFireball.ResetFireball(aquamentus.position);
        aquamentus.middleFireball.ResetFireball(aquamentus.position);
        aquamentus.bottomFireball.ResetFireball(aquamentus.position);
        aquamentus.topFireball.Activate();
        aquamentus.middleFireball.Activate();
        aquamentus.bottomFireball.Activate();
    }

    public void ChangeDirection()
    {
        // No need for this 
    }

    public void ChangeDirection(ref Vector2 velocity)
    {
        // No need for this
    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        // Keep it moving forward and backward between the bounds of the screen, no shooting timer 
        aquamentus.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            velocity = -velocity;
            timer = 0;
        }

        if (!aquamentus.topFireball.Active && !aquamentus.middleFireball.Active && !aquamentus.bottomFireball.Active)
        {
            aquamentus.ChangeState(new MovingAquamentusState(aquamentus, spriteFactory, _graphics));
        }

        EnemyHelper.CheckBounds(ref velocity, aquamentus.position, _graphics);

    }

    public void TakeDamage()
    {
        if (aquamentus.Health <= 0)
        {
            
            aquamentus.ChangeState(new DeadAquamentusState(aquamentus, spriteFactory));
        }
        

    }

    public void OnWallCollision()
    {
               velocity = -velocity;
    }


}