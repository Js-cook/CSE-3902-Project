using Enums;
using Microsoft.Xna.Framework;
using System;

public class MovingDodongoState : IEnemyState
{
    private Dodongo dodongo;
    private DodongoSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;

    private Vector2 velocity;
    private Random randInt;

    // Random direction change timer
    private double directionChangeTimer = 0;
    private double directionChangeInterval = 6.0; // Change direction every 6 seconds on average (less frequent turning)
    private double directionChangeVariance = 2.0; // Variance in direction change timing

    public MovingDodongoState(Dodongo dodongo, DodongoSpriteFactory dodongoSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.dodongo = dodongo;
        this.spriteFactory = dodongoSpriteFactory;
        this._graphics = _graphics;
        this.randInt = new Random();

        // Restore the moving sprite when transitioning back to this state
        dodongo.Sprite = dodongoSpriteFactory.CreateMovingDodongoSprite(dodongo.position, dodongo.CurrentDirection);

        // Initialize velocity based on current direction
        velocity = GetVelocityForDirection(dodongo.CurrentDirection);

        // Random initial direction change interval
        ResetDirectionChangeTimer();
    }

    private void ResetDirectionChangeTimer()
    {
        directionChangeTimer = directionChangeInterval + (randInt.NextDouble() - 0.5) * directionChangeVariance;
    }

    private Vector2 GetVelocityForDirection(Direction direction)
    {
        return direction switch
        {
            Direction.UP => new Vector2(0, -dodongo.Speed),
            Direction.DOWN => new Vector2(0, dodongo.Speed),
            Direction.LEFT => new Vector2(-dodongo.Speed, 0),
            Direction.RIGHT => new Vector2(dodongo.Speed, 0),
            _ => Vector2.Zero
        };
    }

    private Direction GetRandomDirection()
    {
        return (Direction)randInt.Next(0, 4);
    }

    public void ChangeDirection()
    {
        // Pick a random direction
        Direction newDirection = GetRandomDirection();
        ChangeToDirection(newDirection);
    }

    private void ChangeToDirection(Direction newDirection)
    {
        if (dodongo.CurrentDirection != newDirection)
        {
            dodongo.CurrentDirection = newDirection;

            // Update sprite to match new direction
            if (dodongo.Sprite is MovingDodongoSprite movingSprite)
            {
                movingSprite.ChangeDirection(newDirection);
            }

            // Update velocity
            velocity = GetVelocityForDirection(newDirection);

            ResetDirectionChangeTimer();
        }
    }

    public void BeDead()
    {
        // No need for this
    }

    public void TakeDamage()
    {
        // Switch to damaged state
        dodongo.ChangeState(new DamagedDodongoState(dodongo, spriteFactory, _graphics, dodongo.CurrentDirection));
    }

    public void OnWallCollision(Direction collisionDir)
    {
        // Change to a new random direction when hitting a wall
        ChangeDirection();
    }

    public void Update(GameTime gameTime)
    {
        // Move dodongo in current direction
        dodongo.position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Update direction change timer
        directionChangeTimer -= gameTime.ElapsedGameTime.TotalSeconds;
        if (directionChangeTimer <= 0)
        {
            // Randomly change direction
            ChangeDirection();
        }

        if (EnemyHelper.CheckBounds(dodongo.position, _graphics))
        {
            ChangeDirection();
        }
    }
}