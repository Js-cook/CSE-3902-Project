using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class OpenDoorSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(848, 11, 32, 32);

    public OpenDoorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}
