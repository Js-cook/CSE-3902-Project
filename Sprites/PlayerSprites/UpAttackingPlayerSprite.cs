using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class UpAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        public bool Hurt { get; set; }

        private double attackTimer = 0.0;

        private Rectangle[] frameContainer =
        {
                new Rectangle(1, 109, 15, 15),
                new Rectangle(52, 106, 15, 18),
                new Rectangle(35, 98, 15, 26),
                new Rectangle(18, 97, 15, 27)
            };

        public UpAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.1)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.2 && attackTimer < 0.3)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.3 && attackTimer < 0.4)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.4)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
        }
    }

}
