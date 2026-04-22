using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HUDCompassSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle compass = new Rectangle(612, 156, 15, 15);

    public HUDCompassSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public void Update(GameTime gametime)
    {
    }

    public void SpriteDraw(Vector2 position)
    {
        int scale = 4;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            compass.Width * scale,
            compass.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, compass, Color.White);
    }
}
