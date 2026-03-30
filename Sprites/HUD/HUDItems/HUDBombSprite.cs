using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class HUDBombSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle bomb = new Rectangle(129, 185, 8, 15);

    public HUDBombSprite(Texture2D texture, SpriteBatch spriteBatch)
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
            bomb.Width * scale,
            bomb.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, bomb, Color.White);
    }
}