using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingBatState : IEnemyState
{
    private Bat bat;
    private BatSpriteFactory spriteFactory;
    double directionTimerMax = .5;
    double timer;
    private Vector2 velocity;
    private Random randInt;
    
    public MovingBatState(Bat bat, BatSpriteFactory spriteFactory)
    {
        this.bat = bat;
        this.spriteFactory = spriteFactory;
        timer = 0;
        SetVelocity(new Vector2(1, 0));
        randInt = new Random();
        

    }
    public void ChangeDirection()
    {
        // No need for this 
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        velocity = newVelocity * Settings.Instance.BatSpeed;
    }
    public void BeDead()
    {
        //No need for this
        
    }
    public void Update(GameTime gameTime)
    {
        bat.position += velocity; // Updates position
        UpdateDirectionChangeTimer(gameTime); // Handle direction change logic
    }

    public void TakeDamage()
    {
        if (bat.Health <= 0)
        {
            bat.batState = new DeadBatState(bat, spriteFactory);
        }
    }

    private void UpdateDirectionChangeTimer(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= directionTimerMax)
        {
            SetVelocity(new Vector2(randInt.Next(0, 2), randInt.Next(0, 2))); // Randomly change direction but cannot be (0,0)

            timer = 0;
        }
    }

    public void OnWallCollision(Direction newDir)
    {
        
        switch (newDir)
        {
            case Direction.UP:
                
                velocity = new Vector2(velocity.X, -Math.Abs(velocity.Y)); // Move down

                break;
            case Direction.DOWN:
                velocity = new Vector2(velocity.X, Math.Abs(velocity.Y)); // Move up
                break;
            case Direction.LEFT:
                velocity = new Vector2(-Math.Abs(velocity.X), velocity.Y); // Move right

                break;
            case Direction.RIGHT:
                velocity = new Vector2(Math.Abs(velocity.X), velocity.Y); // Move left
                break;
        }
        timer = 0; // Reset timer to change direction sooner after collision
    }


}
