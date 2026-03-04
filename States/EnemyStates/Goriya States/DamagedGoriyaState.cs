using Enums;
using Microsoft.Xna.Framework;
using System;

public class DamagedGoriyaState : IEnemyState
{


    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double timerMax = 5;
    double timer;
    int speed = 2;

    double shootTimerMax = 3;
    double shootTimer;

    private Vector2 velocity;
    private Random randInt;


    private GraphicsDeviceManager _graphics;
    public DamagedGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateDamagedGoriyaSprite(goriya.position);
        timer = 0;

        shootTimer = 0;

        
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
       // No need for this

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            Direction dir = EnemyHelper.GetDirection(velocity);
            switch (dir)
            {
                case Direction.UP:
                    goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case Direction.DOWN:
                    goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case Direction.LEFT:
                    goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case Direction.RIGHT:
                    goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
            }
        }
        EnemyHelper.CheckBounds(ref velocity, goriya.position, _graphics);
        ChangeState(); // This will adjust the state if the velocity changes due to bounds checking, ensuring the correct sprite is displayed.
    }

    private void ChangeState()
    {
        if (velocity.X < 0)
        {
            goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.X > 0)
        {
            goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.Y < 0)
        {
            goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
        }

    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "down");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "down");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

    public void TakeDamage()
    {
        // No need for this, as Goriya is already in a damaged state. If we wanted to implement a knockback effect, we could modify the velocity here.
    }

}