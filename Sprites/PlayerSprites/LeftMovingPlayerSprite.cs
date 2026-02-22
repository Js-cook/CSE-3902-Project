using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprites
{
    public class LeftMovingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(52, 11, 16, 16);
        private int frameCounter = 0;

        public LeftMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.5f, 1.5f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.5f, 1.5f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
    }

}
