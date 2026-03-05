using Enums;
using Microsoft.Xna.Framework;
using System;

public class RightMovingGoriyaState : IEnemyState
{


    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double changeDirectionTimerMax = 5;
    double directionTimer;
    int speed = 2;

    double shootTimerMax = 3;
    double shootTimer;

    private Vector2 velocity;
    private Random randInt;


    private GraphicsDeviceManager _graphics;
    public RightMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateRightMovingGoriyaSprite(goriya.position);
        directionTimer = 0;
        shootTimer = 0;

        velocity = new Vector2(1, 0) * speed;
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(3);

        switch (choice)
        {
            // Down
            case 0:
                goriya.ChangeState(new DownMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
            // Up
            case 1:
                goriya.ChangeState(new UpMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
            // Left
            case 2:
                goriya.ChangeState(new LeftMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
        }

    }

    public void BeDead()
    {
    }

    public void Update(GameTime gameTime)
    {
        goriya.position += velocity; // Move the Goriya according to its velocity 
        UpdateDirectionChangeTimer(gameTime); // Handle direction change logic
        UpdateShootTimer(gameTime); // Handle shooting logic
    }


    public void FireBoomerang()
    {
        goriya.ChangeState(new GoriyaAttackState(goriya, spriteFactory, _graphics, Direction.RIGHT));
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, Direction.RIGHT);
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

    public void TakeDamage()
    {
        if (goriya.Health > 0)
        {
            goriya.goriyaState = new DamagedGoriyaState(goriya, spriteFactory, _graphics, Direction.RIGHT);
        }
        else
        {
            goriya.goriyaState = new DeadGoriyaState(goriya, spriteFactory);
        }
    }


    private void UpdateShootTimer(GameTime gameTime)
    {
        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
        }
    }

    private void UpdateDirectionChangeTimer(GameTime gameTime)
    {
        directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (directionTimer >= changeDirectionTimerMax)
        {
            ChangeDirection();
            directionTimer = 0;
        }
    }

    public void OnWallCollision()
    {
        velocity = -velocity; // Reverse direction upon wall collision
    }

    public void OnWallCollision(Direction newDir)
    {
        switch (newDir)
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
        }
    }
}