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

}
