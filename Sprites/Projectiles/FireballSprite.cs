using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireballSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle frame = new Rectangle(191, 185, 15, 15);
    bool flipped = false;

    public FireballSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }
    public void SpriteDraw(Vector2 position)
    {
        if (flipped)
        {
            spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0.0f);
        }
        else
        {
            spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipHorizontally, 0.0f);
        }
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            flipped = !flipped;
            animationTimer = 0;
        }
    }
}

