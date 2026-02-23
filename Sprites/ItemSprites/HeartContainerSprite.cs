using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeartContainerSprite : BaseItem
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(24, 0, 16, 16);

    public HeartContainerSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        int scale = 4;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            sourceRectangle.Width * scale,
            sourceRectangle.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}