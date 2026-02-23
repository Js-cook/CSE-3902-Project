using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BoomerangSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(64, 185, 7, 15),
        new Rectangle(73, 185, 7, 15),
        new Rectangle(82, 185, 7, 15),
    };

    public BoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        currentFrame = 0;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

