using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DamagedDodongoSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;
    private Direction currentDirection;

    public bool Hurt { get; set; }

    // Damaged frames for each direction - these represent a recoil/knockback animation
    // UP direction damaged frames
    private Rectangle upDamagedFrame = new Rectangle(52, 58, 15, 15);

    // DOWN direction damaged frames
    private Rectangle downDamagedFrame = new Rectangle(18, 58, 15, 15);

    // LEFT direction damaged frames
    private Rectangle leftDamagedFrame = new Rectangle(135, 58, 31, 15);

    // RIGHT direction damaged frames
    private Rectangle rightDamagedFrame = new Rectangle(135, 58, 31, 15);

    public DamagedDodongoSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction direction)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.currentDirection = direction;
        SetFrameForDirection(direction);
    }

    private void SetFrameForDirection(Direction direction)
    {
        currentDirection = direction;
        currentFrame = direction switch
        {
            Direction.UP => upDamagedFrame,
            Direction.DOWN => downDamagedFrame,
            Direction.LEFT => leftDamagedFrame,
            Direction.RIGHT => rightDamagedFrame,
            _ => upDamagedFrame
        };
    }

    public void Update(GameTime gametime)
    {
        // Damaged sprite doesn't animate, just shows the damage frame
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