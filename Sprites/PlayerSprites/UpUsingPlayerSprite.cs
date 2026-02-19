using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class UpUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        public bool Hurt { get; set; }
        private Rectangle currentFrame = new Rectangle(141, 11, 15, 15);

        public UpUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

}
