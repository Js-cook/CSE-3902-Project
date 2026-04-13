using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class LeftUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        public bool Hurt { get; set; }
        private Rectangle currentFrame = new Rectangle(124, 11, 15, 15);

        private int scale = 3;

        public int Height => currentFrame.Height * scale;
        public int Width => currentFrame.Width * scale;

        public LeftUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position, Color color)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, color, 0.0f, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

}
