using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ArrowParticleSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    private Rectangle sourceRectangle = new Rectangle(53, 185, 7, 15);

    public ArrowParticleSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
    }
}

