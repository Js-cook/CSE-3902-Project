using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class DownAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private int scale = 3;
        private double attackTimer = 0.0;

        public int Width => currentFrame.Width * scale;
        public int Height => currentFrame.Height * scale;

        public bool Hurt { get; set; }
        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 47, 15, 15),
            new Rectangle(52, 47, 15, 18),
            new Rectangle(35, 47, 15, 22),
            new Rectangle(18, 47, 15, 26)
        };
        public DownAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.05)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.05 && attackTimer < 0.1)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.15)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.15 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.2)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
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
