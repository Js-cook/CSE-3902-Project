using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OldManSpriteFactory
{
    private Texture2D oldManTexture;
    private SpriteBatch spriteBatch;
    public OldManSpriteFactory(Texture2D oldManTexture, SpriteBatch spriteBatch)
    {
        this.oldManTexture = oldManTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateOldManIdleSprite(Vector2 position)
    {
        return new OldManIdleSprite(oldManTexture, position, spriteBatch);
    }

}

public class OldManIdleSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;


    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(1, 11, 16, 16);
    public OldManIdleSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }
    public void Update(GameTime gametime)
    {
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, Color.White, 0f, Vector2.Zero, Settings.Instance.scale, SpriteEffects.None, 0f);
    }
}