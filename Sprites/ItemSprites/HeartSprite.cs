using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class HeartSprite : BaseItem
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;

        private Rectangle frame1 = new Rectangle(0, 0, 8, 8);
        private Rectangle frame2 = new Rectangle(0, 8, 8, 8);
        private Rectangle currentFrame;

        private int frameCounter = 0;

        public HeartSprite(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.currentFrame = frame1;
        }

        public override void Update(GameTime gametime)
        {
            frameCounter++;
            if (frameCounter >= 10)
            {
                currentFrame = currentFrame.Equals(frame1) ? frame2 : frame1;
                frameCounter = 0;
            }
        }

        public override void SpriteDraw(Vector2 position)
        {
            int scale = 4;

            Rectangle destinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                currentFrame.Width * scale,
                currentFrame.Height * scale
            );
            spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White);
        }
    }
}