using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingGelState : IEnemyState
{
    private Gel gel;
    private GelSpriteFactory spriteFactory;

    double directionTimerMax = 2;
    double timer;

    private Vector2 velocity;
    private Random randInt;

   
    public MovingGelState(Gel gel, GelSpriteFactory gelSpriteFactory)
    {
        this.gel = gel;
        this.spriteFactory = gelSpriteFactory;
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
        gel.position += velocity;
        UpdateDirectionChangeTimer(gameTime);

       



    }

    public void TakeDamage()
    {
        if (gel.Health <= 0)
        {
            gel.gelState = new DeadGelState(gel, spriteFactory);
        }

    }

    private void UpdateDirectionChangeTimer(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= directionTimerMax)
        {
            ChangeDirection();
            timer = 0;
        }
    }


}
