using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class RightUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame = new Rectangle(124, 11, 15, 15);

        public bool Hurt { get; set; }

        public RightUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

}
