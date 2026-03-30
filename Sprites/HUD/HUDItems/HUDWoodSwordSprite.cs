using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HUDWoodSwordSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sword = new Rectangle(1, 154, 7, 15);

    public HUDWoodSwordSprite(Texture2D texture, SpriteBatch spriteBatch)
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
            sword.Width * scale,
            sword.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, sword, Color.White);
    }
}