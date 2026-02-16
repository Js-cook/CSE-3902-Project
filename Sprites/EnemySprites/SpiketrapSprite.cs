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



public class SpiketrapSpriteFactory
{
    private Texture2D spiketrapTexture;
    private SpriteBatch spriteBatch;
    public SpiketrapSpriteFactory(Texture2D spiketrapTexture, SpriteBatch spriteBatch)
    {
        this.spiketrapTexture = spiketrapTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingSpiketrapSprite(Vector2 position)
    {
        return new SpiketrapSprite(spiketrapTexture, position, spriteBatch);
    }

}

public class SpiketrapSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    private Rectangle sourceRectangle1 = new Rectangle(164, 59, 16, 16);
    private int frameCounter = 0;

    public SpiketrapSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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







