using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HUDCursorSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle cursor = new Rectangle(654, 108, 8, 8);

    public HUDCursorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public void Update(GameTime gametime)
    {
    }

    public void SpriteDraw(Vector2 position)
    {
        int scale = 6;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            cursor.Width * scale,
            cursor.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, cursor, Color.White);
    }
}