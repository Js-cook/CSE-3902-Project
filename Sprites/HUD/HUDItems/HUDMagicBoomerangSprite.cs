using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class HUDMagicBoomerangSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle boomerang = new Rectangle(91, 185, 7, 15);

    public HUDMagicBoomerangSprite(Texture2D texture, SpriteBatch spriteBatch)
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
            boomerang.Width * scale,
            boomerang.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, boomerang, Color.White);
    }
}
