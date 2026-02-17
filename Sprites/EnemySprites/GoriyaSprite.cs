using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class GoriyaSpriteFactory
{
    private Texture2D goriyaTexture;
    private SpriteBatch spriteBatch;
    public GoriyaSpriteFactory(Texture2D goriyaTexture, SpriteBatch spriteBatch)
    {
        this.goriyaTexture = goriyaTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateLeftMovingGoriyaSprite(Vector2 position)
    {
        return new LeftMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateRightMovingGoriyaSprite(Vector2 position)
    {
        return new RightMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateUpMovingGoriyaSprite(Vector2 position)
    {
        return new UpMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateDownMovingGoriyaSprite(Vector2 position)
    {
        return new DownMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }


}

public class LeftMovingGoriyaSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt {  get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(256, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(273, 11, 16, 16);
    private int frameCounter = 0;

    public LeftMovingGoriyaSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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
        spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
    }
}

public class RightMovingGoriyaSprite : ISprite
{
    public bool Hurt { get; set; }
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(256, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(273, 11, 16, 16);
    private int frameCounter = 0;
    public RightMovingGoriyaSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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

public class UpMovingGoriyaSprite : ISprite
{
    public bool Hurt { get; set; }
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(239, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(290, 28, 16, 16);
    private int frameCounter = 0;
    public UpMovingGoriyaSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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

public class DownMovingGoriyaSprite : ISprite
{
    public bool Hurt { get; set; }
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;
    private Rectangle sourceRectangle1 = new Rectangle(222, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(308, 28, 16, 16);
    private int frameCounter = 0;
    public DownMovingGoriyaSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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





