using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BatSpriteFactory
{
    private Texture2D batTexture;
    private SpriteBatch spriteBatch;
    public BatSpriteFactory(Texture2D batTexture, SpriteBatch spriteBatch)
    {
        this.batTexture = batTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateBatMovingSprite(Vector2 position)
    {
        return new MovingBatSprite(batTexture, position, spriteBatch);
    }

}

public class MovingBatSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;


    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(183, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(200, 11, 16, 16);
    private int frameCounter = 0;
    public MovingBatSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
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