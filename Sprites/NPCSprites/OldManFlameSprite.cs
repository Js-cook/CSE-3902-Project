using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OldManFlameSpriteFactory
{
    private Texture2D oldManTexture;
    private SpriteBatch spriteBatch;
    public OldManFlameSpriteFactory(Texture2D oldManTexture, SpriteBatch spriteBatch)
    {
        this.oldManTexture = oldManTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateOldManFlameSprite(Vector2 position)
    {
        return new OldManFlameSprite(oldManTexture, position, spriteBatch);
    }

}

public class OldManFlameSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;


    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(52, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(69, 11, 16, 16);
    private int frameCounter = 0;
    public OldManFlameSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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