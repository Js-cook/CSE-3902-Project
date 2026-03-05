using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingBatState : IEnemyState
{
    private Bat bat;
    private BatSpriteFactory spriteFactory;
    double directionTimerMax = 2;
    double timer;
    private Vector2 velocity;
    private Random randInt;
    
    public MovingBatState(Bat bat, BatSpriteFactory spriteFactory)
    {
        this.bat = bat;
        this.spriteFactory = spriteFactory;
        timer = 0;
        velocity = new Vector2(1, 0);
        randInt = new Random();
        

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
            velocity = new Vector2(randInt.Next(0, 2), randInt.Next(0, 2));
            timer = 0;
        }
    }

    public void OnWallCollision()
    {
        velocity = -velocity; // Reverse direction upon wall collision
    }


}
