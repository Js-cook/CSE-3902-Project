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

    private GraphicsDeviceManager _graphics;
    public MovingWallmasterState(Wallmaster wallmaster, WallmasterSpriteFactory wallmasterSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.wallmaster = wallmaster;
        this.spriteFactory = wallmasterSpriteFactory;
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
        wallmaster.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection(ref velocity);
            timer = 0;
        }

        EnemyHelper.CheckBounds(ref velocity, wallmaster.position, _graphics);



    }




}
