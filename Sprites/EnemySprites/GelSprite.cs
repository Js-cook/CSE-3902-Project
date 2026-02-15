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



public class GelSpriteFactory
{
    private Texture2D gelTexture;
    private SpriteBatch spriteBatch;
    public GelSpriteFactory(Texture2D gelTexture, SpriteBatch spriteBatch)
    {
        this.gelTexture = gelTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingGelSprite(Vector2 position)
    {
        return new MovingGelSprite(gelTexture, position, spriteBatch);
    }

}

    public class MovingGelSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(28, 28, 8, 16);
        private Rectangle sourceRectangle2 = new Rectangle(28, 28, 8, 16);
        private int frameCounter = 0;

        public MovingGelSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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







