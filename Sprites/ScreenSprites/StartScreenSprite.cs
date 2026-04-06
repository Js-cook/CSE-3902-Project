using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartScreenSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    public StartScreenSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public void Update(GameTime gametime)
    {
    }

    public void SpriteDraw(Vector2 position)
    {
        Rectangle destination = new Rectangle(0, 0, 1025, 928); // ideally pass the graphics preferred width and height so its slightly dynamic
        spriteBatch.Draw(texture, destination, Color.White);
    }
}