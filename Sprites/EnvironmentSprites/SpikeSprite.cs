using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpikeSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(164, 59, 16, 16);

    public SpikeSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gametime)
    {
        //static
    }
    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle(
           (int)position.X,
           (int)position.Y,
           16 * Settings.Instance.scale,
           16 * Settings.Instance.scale
       );

        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}