using Enums;
using Microsoft.Xna.Framework;
using System;

public class KnockedBackGoriyaState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;
    
    private Vector2 knockbackVelocity;
    private double knockbackTimer;
    private double knockbackTimerMax;
    private Direction previousDirection;

    public KnockedBackGoriyaState(Goriya goriya, GoriyaSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Direction knockbackDirection, Direction previousDirection)
    {
        this.goriya = goriya;
        this.spriteFactory = spriteFactory;
        this._graphics = _graphics;
        this.previousDirection = previousDirection;
        
        knockbackTimerMax = Settings.Instance.GoriyaKnockbackDuration;
        knockbackTimer = 0;
        
        // Set knockback velocity based on direction (opposite of attack direction)
        knockbackVelocity = GetKnockbackVelocity(knockbackDirection);
        
        // Use the damaged sprite during knockback
        goriya.Sprite = spriteFactory.CreateDamagedGoriyaSprite(goriya.position, previousDirection);
    }

    private Vector2 GetKnockbackVelocity(Direction knockbackDirection)
    {
        float speed = Settings.Instance.GoriyaKnockbackSpeed;


        // AI Generated Code using Claude Haiku 4.5: a cleaner way to 
        // determine knockback velocity based on direction using a switch expression. 
        // Essentially, it is a switch statement but it returns a value directly
        // from each case which makes the code more concise and easier to read.
        return knockbackDirection switch
        {
            Direction.UP => new Vector2(0, -speed),
            Direction.DOWN => new Vector2(0, speed),
            Direction.LEFT => new Vector2(-speed, 0),
            Direction.RIGHT => new Vector2(speed, 0),
            _ => Vector2.Zero
        };
    }

    public void Update(GameTime gameTime)
    {
        knockbackTimer += gameTime.ElapsedGameTime.TotalSeconds;
        
        // Apply knockback movement
        goriya.position += knockbackVelocity;

        // Check if knockback duration is complete
        if (knockbackTimer >= knockbackTimerMax)
        {
            ReturnToPreviousState();
        }
    }

    private void ReturnToPreviousState()
    {
        // Transition back to the appropriate moving state based on previous direction
        switch (previousDirection)
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

    public void ChangeDirection()
    {
        // No direction changes during knockback
    }

    public void BeDead()
    {
        // No death during knockback
    }

    public void FireBoomerang()
    {
        // No boomerang firing during knockback
    }

    public void TakeDamage()
    {
        // Ignore additional damage during knockback (already in damaged/knockback state)
    }

    public void OnWallCollision(Direction newDir)
    {
        // No wall collision logic needed during knockback
    }
}
