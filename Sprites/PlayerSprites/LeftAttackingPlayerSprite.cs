using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class LeftAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private double attackTimer = 0.0;

        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 77, 14, 15),
            new Rectangle(70, 77, 18, 15),
            new Rectangle(46, 77, 22, 15),
            new Rectangle(18, 77, 26, 15)
        };

        public LeftAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(2.0f, 2.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(2.0f, 2.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }

    }

}
