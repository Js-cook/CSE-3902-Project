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



public class WallmasterSpriteFactory
{
    private Texture2D wallmasterTexture;
    private SpriteBatch spriteBatch;
    public WallmasterSpriteFactory(Texture2D wallmasterTexture, SpriteBatch spriteBatch)
    {
        this.wallmasterTexture = wallmasterTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingWallmasterSprite(Vector2 position)
    {
        return new MovingWallmasterSprite(wallmasterTexture, position, spriteBatch);
    }

}

public class MovingWallmasterSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    private Rectangle sourceRectangle1 = new Rectangle(393, 11, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(410, 11, 16, 16);
    private int frameCounter = 0;

    public MovingWallmasterSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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







