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

public class OldManFlameSprite : BaseTile
{
    private Texture2D npcTexture;
    private Texture2D tileTexture;
    private SpriteBatch spriteBatch;

    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(52, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(69, 11, 16, 16);
    private Rectangle blackFloorSource = new Rectangle(404, 27, 8, 8);
    private int frameCounter = 0;

    public OldManFlameSprite(Texture2D npcTexture, Texture2D tileTexture, SpriteBatch spriteBatch)
    {
        this.npcTexture = npcTexture;
        this.tileTexture = tileTexture;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }

    public OldManFlameSprite(Texture2D npcTexture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.npcTexture = npcTexture;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }

    public override void Update(GameTime gametime)
    {
        frameCounter++;
        if (frameCounter >= 15)
        {
            currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
            frameCounter = 0;
        }
    }

    public override void SpriteDraw(Vector2 position)
    {
        int scale = Settings.Instance.scale;
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 16 * scale, 16 * scale);

        // Draw black floor behind the flame if we have the tile texture
        if (tileTexture != null)
        {
            spriteBatch.Draw(tileTexture, destinationRectangle, blackFloorSource, Color.White);
        }

        // Draw the flame on top
        spriteBatch.Draw(npcTexture, destinationRectangle, currentFrame, Color.White);
    }
}
