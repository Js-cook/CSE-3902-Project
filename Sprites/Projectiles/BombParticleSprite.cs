using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BombParticleSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame = 0;

    private double animationTimer = 0.0;
    private double animationDuration = 0.25;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(138, 185, 15, 15),
        new Rectangle(155, 185, 15, 15),
        new Rectangle(172, 185, 15, 15)

    };

    public BombParticleSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationDuration)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

