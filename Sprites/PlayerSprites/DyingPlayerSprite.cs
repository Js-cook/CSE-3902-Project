using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class DyingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private double deathTimer = 0.0;
        public bool Hurt { get; set; }
        private Rectangle[] frameContainer =
        {
                new Rectangle(1, 11, 16, 16),
                new Rectangle(35, 11, 16, 16),
                new Rectangle(69, 11, 16, 16),
                new Rectangle(160, 11, 16, 16)
            };

        private int scale = 3;

        public int Height => currentFrame.Height * scale;
        public int Width => currentFrame.Width * scale;
        public DyingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            deathTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (deathTimer < 0.05)
            {
                currentFrame = frameContainer[0];
            }
            else if (deathTimer >= 0.05 && deathTimer < 0.1)
            {
                currentFrame = frameContainer[1];
            }
            else if (deathTimer >= 0.1 && deathTimer < 0.15)
            {
                currentFrame = frameContainer[2];
            }
            else if (deathTimer >= 0.15 && deathTimer < 0.2)
            {
                currentFrame = frameContainer[3];
            }
            else if (deathTimer >= 0.2)
            {
                currentFrame = frameContainer[0];
                deathTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
           spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            
        }
    }

}
