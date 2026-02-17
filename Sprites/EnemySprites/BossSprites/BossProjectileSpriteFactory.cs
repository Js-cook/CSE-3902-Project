using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BossProjectileSpriteFactory
{
    private Texture2D projectileTexture;
    private SpriteBatch spriteBatch;

    public BossProjectileSpriteFactory(Texture2D texture, SpriteBatch spriteBatch)
    {
        projectileTexture = texture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateAquamentusFireballSprite(Vector2 position)
    {
        return new AquamentusFireballSprite(projectileTexture, position, spriteBatch);
    }

}

public class AquamentusFireballSprite : ISprite
{
    public bool Hurt { get; set; }
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int frameCounter;
    private Rectangle sourceRectangle1 = new Rectangle(101, 11, 8, 16);
    private Rectangle sourceRectangle2 = new Rectangle(110, 11, 8, 16);
    private Rectangle sourceRectangle3 = new Rectangle(119, 11, 8, 16);
    private Rectangle sourceRectangle4 = new Rectangle(128, 11, 8, 16);
    private Rectangle currentFrame;
    public AquamentusFireballSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        currentFrame = sourceRectangle1;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, Color.White);
    }
    public void Update(GameTime gametime)
    {
        frameCounter++;
        if (frameCounter >= 5)
        {
            if (currentFrame.Equals(sourceRectangle1))
            {
                currentFrame = sourceRectangle2;
            }
            else if (currentFrame.Equals(sourceRectangle2))
            {
                currentFrame = sourceRectangle3;
            }
            else if (currentFrame.Equals(sourceRectangle3))
            {
                currentFrame = sourceRectangle4;
            }
            else
            {
                currentFrame = sourceRectangle1;
            }
            frameCounter = 0;
        }
    }
}