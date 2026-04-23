using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PowerBraceletSprite : BaseItem
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle currentFrame = new Rectangle(176, 1, 8, 15);

    public PowerBraceletSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gametime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        int scale = Settings.Instance.scale;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            currentFrame.Width * scale,
            currentFrame.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White);
    }
}