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
    private int direction;

    private Rectangle sourceRectangleTop = new Rectangle(848, 11, 32, 32);
    private Rectangle sourceRectangleBottom = new Rectangle(848, 110, 32, 32);
    private Rectangle sourceRectangleLeft = new Rectangle(848, 44, 32, 32);
    private Rectangle sourceRectangleRight = new Rectangle(848, 77, 32, 32);

    public OpenDoorSprite(Texture2D texture, SpriteBatch spriteBatch, int direction)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.direction = direction;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32 * Settings.Instance.scale, 32 * Settings.Instance.scale);
        switch (direction)
        {
            case 0:
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangleTop, Color.White);
                break;
            case 1:
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangleRight, Color.White);
                break;
            case 2:
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangleBottom, Color.White);
                break;
            case 3:
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangleLeft, Color.White);
                break;
            default:
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangleTop, Color.White);
                break;
        }
    }
}