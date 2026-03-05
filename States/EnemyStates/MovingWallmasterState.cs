using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingWallmasterState : IEnemyState
{
    private Wallmaster wallmaster;
    private WallmasterSpriteFactory spriteFactory;

    double timerMax = 2;
    double timer;

    private Vector2 velocity;
    private Random randInt;

    public MovingWallmasterState(Wallmaster wallmaster, WallmasterSpriteFactory wallmasterSpriteFactory)
    {
        this.wallmaster = wallmaster;
        spriteFactory = wallmasterSpriteFactory;
        timer = 0;

        velocity = new Vector2(1, 0);
        randInt = new Random();

    }

    public void ChangeDirection()
    {
        switch (randInt.Next(4))
        {
            case 0:
                velocity = new Vector2(1, 0);
                break;
            case 1:
                velocity = new Vector2(-1, 0);
                break;
            case 2:
                velocity = new Vector2(0, 1);
                break;
            case 3:
                velocity = new Vector2(0, -1);
                break;
        }
    }  

   
    public void BeDead()
    {
        //No need for this
    }

    public void Update(GameTime gameTime)
    {
        wallmaster.position += velocity;
        UpdateDirectionTimer(gameTime);
    }

    public void TakeDamage()
    {
              
        if (wallmaster.Health <= 0)
        {
            wallmaster.wallmasterState = new DeadWallmasterState(wallmaster, spriteFactory);
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
        velocity = -velocity; // Reverse direction upon wall collision
    }




}
