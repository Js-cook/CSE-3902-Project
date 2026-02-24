using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingSkeletonSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt { get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(404, 194, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(404, 212, 16, 16);
    private int frameCounter = 0;

    public MovingSkeletonSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        //this.position = position;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }

    public void Update(GameTime gametime)
    {
        frameCounter++;
        if (frameCounter >= 5)
        {
            currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
            frameCounter = 0;
        }

    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, Color.White);
    }
}