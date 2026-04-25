using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace Sprites
{
    public class WinPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private float animationTimer = 0f;

        private int scale = 3;

        public int Width => currentFrame.Width * scale;
        public int Height => currentFrame.Height * scale;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(1, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(230, 11, 16, 16);
        private Rectangle TriForcePiece1 = new Rectangle(249, 11, 10, 10);
        private Rectangle TriForcePiece2 = new Rectangle(249, 27, 10, 10);

        public WinPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {

            animationTimer += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.5f)
            {
                currentFrame = sourceRectangle2;
            }
            
        }

        public void SpriteDraw(Vector2 position, Color color)
        {
             spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }
    }

}
