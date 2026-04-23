using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HUDRedRingSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle ring = new Rectangle(549, 156, 8, 15);

    public HUDRedRingSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public void Update(GameTime gametime)
    {
    }

    public void SpriteDraw(Vector2 position)
    {
        int scale = 5;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            ring.Width * scale,
            ring.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, ring, Color.White);
    }
}
