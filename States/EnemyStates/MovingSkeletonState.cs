using Enums;
using Microsoft.Xna.Framework;
using System;


public class MovingSkeletonState : IEnemyState
{
    private Skeleton skeleton;
    private SkeletonSpriteFactory spriteFactory;

    double timerMax = 2;
    double timer;

    private Vector2 velocity;
    private Random randInt;

    public MovingSkeletonState(Skeleton skeleton, SkeletonSpriteFactory skeletonSpriteFactory)
    {
        this.skeleton = skeleton;
        spriteFactory = skeletonSpriteFactory;
        timer = 0;

        velocity = new Vector2(1, 0);
        randInt = new Random();
       

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(4);

        switch (choice)
        {
            // Down
            case 0:
                velocity = new Vector2(0, 1);
                break;
            // Up
            case 1:
                velocity = new Vector2(0, -1);
                break;
            // Right
            case 2:
                velocity = new Vector2(1, 0);
                break;
            // Left
            case 3:
                velocity = new Vector2(-1, 0);
                break;

        }
    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        skeleton.position += velocity;
        UpdateDirectionTimer(gameTime);
    }
    public void TakeDamage()
    {
        if (skeleton.Health <= 0)
        {
            skeleton.skeletonState = new DeadSkeletonState(skeleton, spriteFactory);
        }
    }

    private void UpdateDirectionTimer(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }
    }

    public void OnWallCollision(Direction newDir)
    {
        switch (newDir)
        {
            case Direction.UP:
                velocity = new Vector2(velocity.X, -Math.Abs(velocity.Y)); // Move down (away from UP wall)
                break;
            case Direction.DOWN:
                velocity = new Vector2(velocity.X, Math.Abs(velocity.Y)); // Move up (away from DOWN wall)
                break;
            case Direction.LEFT:
                velocity = new Vector2(-Math.Abs(velocity.X), velocity.Y); // Move right (away from LEFT wall)
                break;
            case Direction.RIGHT:
                velocity = new Vector2(Math.Abs(velocity.X), velocity.Y); // Move left (away from RIGHT wall)
                break;
        }

        timer = 0;
        // Reverse direction upon wall collision
    }



}
