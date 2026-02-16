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



public class AquamentusSpriteFactory
{
    private Texture2D aquamentusTexture;
    private SpriteBatch spriteBatch;
    public AquamentusSpriteFactory(Texture2D aquamentusTexture, SpriteBatch spriteBatch)
    {
        this.aquamentusTexture = aquamentusTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingAquamentusSprite(Vector2 position)
    {
        return new MovingAquamentusSprite(aquamentusTexture, position, spriteBatch);
    }

    

}

public class MovingAquamentusSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    private Rectangle sourceRectangle1 = new Rectangle(1, 11, 24, 32);
    private Rectangle sourceRectangle2 = new Rectangle(26, 11, 24, 32);
    private Rectangle sourceRectangle3 = new Rectangle(
        51, 11, 24, 32);
    private Rectangle sourceRectangle4 = new Rectangle(
        76, 11, 24, 32);

    private int frameCounter = 0;

    public MovingAquamentusSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, Color.White);
    }
}










