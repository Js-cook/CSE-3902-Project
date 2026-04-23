using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;


public static class EnemyHelper { 

    public static void CheckBounds(ref Vector2 velocity, Vector2 position, GraphicsDeviceManager _graphics)
    {
         
    
        if (position.X < 0)
        {

            velocity.X *= -1;
        }
        else if (position.X > _graphics.GraphicsDevice.Viewport.Width) // Assuming the game width is 800
        {

            velocity.X *= -1;
        }
        if (position.Y < 0)
        {

            velocity.Y *= -1;
        }
        else if (position.Y > _graphics.GraphicsDevice.Viewport.Height) // Assuming the game height is 600
        {

            velocity.Y *= -1;
        }
    
    }

    public static bool CheckBounds(Vector2 position, GraphicsDeviceManager _graphics)
    {
        bool ret = false;
        if (position.X < 0)
        {

            ret = true;
        }
        else if (position.X > _graphics.GraphicsDevice.Viewport.Width) // Assuming the game width is 800
        {

            ret = true;
        }
        if (position.Y < 0)
        {

            ret = true;
        }
        else if (position.Y > _graphics.GraphicsDevice.Viewport.Height) // Assuming the game height is 600
        {

            ret = true;
        }

        return ret;
    }

    public static Direction GetDirection(Vector2 velocity)
    {
        if (velocity.X > 0)
        {
            return Direction.RIGHT;
        }
        else if (velocity.X < 0)
        {
            return Direction.LEFT;
        }
        else if (velocity.Y > 0)
        {
            return Direction.DOWN;
        }
        else
        {
            return Direction.UP;
        }
        
    }

}
