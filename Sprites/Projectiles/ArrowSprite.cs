using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ArrowSprite : ISprite
{

    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Direction direction;

    private Rectangle sourceRectangleHorizontal = new Rectangle(10, 185, 15, 15);
    private Rectangle sourceRectangleVertical = new Rectangle(1, 185, 7, 15);

    public ArrowSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction direction)
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
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
            case Direction.DOWN:
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case Direction.LEFT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case Direction.RIGHT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
        // arrow doesn't need to animate
    }
}
