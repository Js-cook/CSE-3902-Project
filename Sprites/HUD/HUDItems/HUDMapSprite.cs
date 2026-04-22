using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HUDMapSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle map = new Rectangle(601, 156, 8, 15);

    public HUDMapSprite(Texture2D texture, SpriteBatch spriteBatch)
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
            map.Width * scale,
            map.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, map, Color.White);
    }
}