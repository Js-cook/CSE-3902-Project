using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SwordBeamSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Direction direction;

    //private Rectangle sourceRectangleHorizontal = new Rectangle(10, 185, 15, 15);
    //private Rectangle sourceRectangleVertical = new Rectangle(1, 185, 7, 15);

    private double animationTimer = 0.0;
    private double animationInterval = 0.05;
    private int currentFrame = 0;

    private Rectangle[] sourceFramesHorizontal =
    {
        new Rectangle(10, 154, 15, 15),
        new Rectangle(45, 154, 15, 15),
        new Rectangle(80, 154, 15, 15),
        new Rectangle(115, 154, 15, 15)

    };

    private Rectangle[] sourceFramesVertical =
    {
        new Rectangle(1, 154, 7, 15),
        new Rectangle(36, 154, 7, 15),
        new Rectangle(71, 154, 7, 15),
        new Rectangle(106, 154, 7, 15)
    };

    public SwordBeamSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction direction)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        this.direction = direction;
    }
    public void SpriteDraw(Vector2 position)
    {
        switch (direction)
        {
            case Direction.UP:
                spriteBatch.Draw(texture, position, sourceFramesVertical[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
            case Direction.DOWN:
                spriteBatch.Draw(texture, position, sourceFramesVertical[currentFrame], Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case Direction.LEFT:
                spriteBatch.Draw(texture, position, sourceFramesHorizontal[currentFrame], Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case Direction.RIGHT:
                spriteBatch.Draw(texture, position, sourceFramesHorizontal[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            currentFrame = (currentFrame + 1) % sourceFramesHorizontal.Length;
            animationTimer = 0.0;
        }
    }
}