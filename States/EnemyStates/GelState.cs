using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class MovingGelState : IEnemyState
{
    private Gel gel;
    private GelSpriteFactory spriteFactory;

    double timerMax = 5;
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
        // No need for this 
    }

    public void BeDead()
    {

        //No need for this
        
    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        gel.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            velocity = new Vector2(randInt.Next(0, 2), randInt.Next(0, 2));
            timer = 0;
        }
        


    }   

    
}
