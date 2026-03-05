using Enums;
using Microsoft.Xna.Framework;
using System;

public class DamagedGoriyaState : IEnemyState
{


    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double timerMax = 5;
    double timer;

    private Vector2 velocity;
   


    private GraphicsDeviceManager _graphics;
    public DamagedGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateDamagedGoriyaSprite(goriya.position);
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

    public void Update(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            Direction dir = EnemyHelper.GetDirection(velocity);
            switch (dir)
            {
                case Direction.UP:
                    goriya.ChangeState(new UpMovingGoriyaState(goriya, spriteFactory, _graphics));
                    break;
                case Direction.DOWN:
                    goriya.ChangeState(new DownMovingGoriyaState(goriya, spriteFactory, _graphics));
                    break;
                case Direction.LEFT:
                    goriya.ChangeState(new LeftMovingGoriyaState(goriya, spriteFactory, _graphics));
                    break;
                case Direction.RIGHT:
                    goriya.ChangeState(new RightMovingGoriyaState(goriya, spriteFactory, _graphics));
                    break;
            }
        }
       
    }



    public void FireBoomerang()
    {
        goriya.ChangeState(new GoriyaAttackState(goriya, spriteFactory, _graphics, Direction.DOWN));
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, Direction.UP);
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

    public void TakeDamage()
    {
        // No need for this, as Goriya is already in a damaged state. If we wanted to implement a knockback effect, we could modify the velocity here.
    }

    public void OnWallCollision(Direction newDir)
    {
        // No movement when damaged, so no wall collision logic needed.
    }
}