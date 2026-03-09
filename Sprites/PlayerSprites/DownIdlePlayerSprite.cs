using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace Sprites
{
    public class DownIdlePlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private int scale = 3;

        public int Width => currentFrame.Width * scale;
        public int Height => currentFrame.Height * scale;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(1, 11, 16, 16);

        public DownIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            }
        }
    }

}
