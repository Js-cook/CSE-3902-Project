using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BombSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Rectangle frame = new Rectangle(129, 185, 8, 15);
    public BombSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.position = position;
        this.spriteBatch = spriteBatch;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
    }
}

