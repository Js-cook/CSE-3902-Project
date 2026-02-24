using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingSpiketrapSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt { get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(164, 59, 16, 16);
    //private int frameCounter = 0;

    public MovingSpiketrapSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        //this.position = position;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }

    public void Update(GameTime gametime)
    {
        // No animation for spike trap, but we can still update the frame if we want to add animation later
        /* frameCounter++;
         if (frameCounter >= 5)
         {
             currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
             frameCounter = 0;
         }*/
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, Color.White);
    }
}
