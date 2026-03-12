using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TreasureChestSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    public TreasureChestSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            16 * Settings.Instance.scale,
            16 * Settings.Instance.scale
        );

        spriteBatch.Draw(texture, destinationRectangle, Color.White);
    }
}