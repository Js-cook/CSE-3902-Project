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
    double timerMax = 2;
    double timer;
    private Vector2 velocity;
    private Random randInt;
    GraphicsDeviceManager _graphics;
    public MovingBatState(Bat bat, BatSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        this.bat = bat;
        this.spriteFactory = spriteFactory;
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
    public void Update(GameTime gameTime)
    {
        bat.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            velocity = new Vector2(randInt.Next(0, 2), randInt.Next(0, 2));
            timer = 0;
        }

        EnemyHelper.CheckBounds(ref velocity, bat.position, _graphics);


    }

   
}
