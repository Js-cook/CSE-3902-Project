using Microsoft.Xna.Framework;
using System;

public class UpMovingGoriyaState : IEnemyState
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
    public bool isAttacking = false;


    private GraphicsDeviceManager _graphics;
    public UpMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateUpMovingGoriyaSprite(goriya.position);
        timer = 0;

        shootTimer = 0;

        velocity = new Vector2(0, -1) * speed;
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
                goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Up
            case 1:
                goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Right
            case 2:
                goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
        }

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        goriya.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }

        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
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

        if (velocity.Y > 0)
        {
            goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "up");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "up");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

}
