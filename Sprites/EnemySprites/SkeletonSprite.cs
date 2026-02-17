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



public class SkeletonSpriteFactory
{
    private Texture2D skeletonTexture;
    private SpriteBatch spriteBatch;
    public SkeletonSpriteFactory(Texture2D skeletonTexture, SpriteBatch spriteBatch)
    {
        this.skeletonTexture = skeletonTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingSkeletonSprite(Vector2 position)
    {
        return new MovingSkeletonSprite(skeletonTexture, position, spriteBatch);
    }

}

public class MovingSkeletonSprite : ISprite
{
    private Texture2D texture;
    //private Vector2 position;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt {  get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(404, 194, 16, 16);
    private Rectangle sourceRectangle2 = new Rectangle(404, 212, 16, 16);
    private int frameCounter = 0;

    public MovingSkeletonSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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







