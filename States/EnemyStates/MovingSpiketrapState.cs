using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingSpiketrapState : IEnemyState
{
    private Spiketrap spiketrap;
    private SpiketrapSprite spriteFactory;

    double timerMax = 5;
    double timer;

    private Vector2 velocity;
    private Random randInt;

    private GraphicsDeviceManager _graphics;
    public MovingSpiketrapState(Spiketrap spiketrap, SpiketrapSprite spiketrapSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.spiketrap = spiketrap;
        this.spriteFactory = spiketrapSpriteFactory;
        timer = 0;

        velocity = new Vector2(1, 0);
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        // No need for this 
    }

    public void ChangeDirection(ref Vector2 velocity)
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
        spiketrap.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection(ref velocity);
            timer = 0;
        }

        EnemyHelper.CheckBounds(ref velocity, spiketrap.position, _graphics);



    }



}
