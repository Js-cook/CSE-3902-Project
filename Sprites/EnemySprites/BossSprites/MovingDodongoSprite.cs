using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingDodongoSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;
    private Direction currentDirection;

    public bool Hurt { get; set; }

    // UP direction frames
    private Rectangle upFrame1 = new Rectangle(35, 58, 15, 15);
    private Rectangle upFrame2 = new Rectangle(135, 75, 15, 15);

    // DOWN direction frames
    private Rectangle downFrame1 = new Rectangle(1, 58, 15, 15);
    private Rectangle downFrame2 = new Rectangle(170, 58, 15, 15);

    // LEFT direction frames
    private Rectangle leftFrame1 = new Rectangle(69, 58, 31, 15);
    private Rectangle leftFrame2 = new Rectangle(102, 58, 31, 15);

    // RIGHT direction frames
    private Rectangle rightFrame1 = new Rectangle(69, 58, 31, 15);
    private Rectangle rightFrame2 = new Rectangle(102, 58, 31, 15);

    private int frameCounter = 0;
    private const int FRAME_CHANGE_INTERVAL = 5;

    public MovingDodongoSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction initialDirection = Direction.UP)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.currentDirection = initialDirection;
        SetFrameForDirection(initialDirection);
    }

    private void SetFrameForDirection(Direction direction)
    {
        currentDirection = direction;
        switch (direction)
        {
            case Direction.UP:
                currentFrame = upFrame1;
                break;
            case Direction.DOWN:
                currentFrame = downFrame1;
                break;
            case Direction.LEFT:
                currentFrame = leftFrame1;
                break;
            case Direction.RIGHT:
                currentFrame = rightFrame1;
                break;
        }
        frameCounter = 0;
    }

    public void ChangeDirection(Direction newDirection)
    {
        if (currentDirection != newDirection)
        {
            SetFrameForDirection(newDirection);
        }
    }

    public void Update(GameTime gametime)
    {
        frameCounter++;
        if (frameCounter >= FRAME_CHANGE_INTERVAL)
        {
            currentFrame = GetNextFrame(currentFrame);
            frameCounter = 0;
        }
    }

    private Rectangle GetNextFrame(Rectangle current)
    {
        return currentDirection switch
        {
            Direction.UP => current == upFrame1 ? upFrame2 : upFrame1,
            Direction.DOWN => current == downFrame1 ? downFrame2 : downFrame1,
            Direction.LEFT => current == leftFrame1 ? leftFrame2 : leftFrame1,
            Direction.RIGHT => current == rightFrame1 ? rightFrame2 : rightFrame1,
            _ => current
        };
    }

    public void SpriteDraw(Vector2 position)
    {
        if(currentDirection == Direction.LEFT)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, Settings.Instance.scale, SpriteEffects.FlipHorizontally, 0.0f);
        } else
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, Settings.Instance.scale, SpriteEffects.None, 0.0f);
        }
    }
}
