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

    double timerMax = 2;
    double timer;

    private Vector2 velocity;
    private Random randInt;

    private GraphicsDeviceManager _graphics;
    public MovingGelState(Gel gel, GelSpriteFactory gelSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.gel = gel;
        this.spriteFactory = gelSpriteFactory;
        timer = 0;

        velocity = new Vector2(1, 0);
        randInt = new Random();
        this._graphics = _graphics;

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

        EnemyHelper.CheckBounds(ref velocity, gel.position, _graphics);



    }

   

}
