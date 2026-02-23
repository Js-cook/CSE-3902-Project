using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprites
{
    public class FairySprite : BaseItem
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;

        private Rectangle frame1 = new Rectangle(40, 0, 8, 16);
        private Rectangle frame2 = new Rectangle(48, 0, 8, 16);
        private Rectangle currentFrame;

        private int frameCounter = 0;

        private Vector2 offset = Vector2.Zero;
        private Random random = new Random();

        public FairySprite(Texture2D texture, SpriteBatch spriteBatch)
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

                offset.X += random.Next(-3, 4);
                offset.Y += random.Next(-3, 4);

                frameCounter = 0;
            }
        }

        public override void SpriteDraw(Vector2 position)
        {
            int scale = 4;

            Rectangle destinationRectangle = new Rectangle(
                (int)(position.X + offset.X),
                (int)(position.Y + offset.Y),
                currentFrame.Width * scale,
                currentFrame.Height * scale
            );

            spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White);
        }
    }
}