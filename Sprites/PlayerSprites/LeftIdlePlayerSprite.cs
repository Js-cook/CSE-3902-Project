using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class LeftIdlePlayerSprite : Interfaces.IPlayerSprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt { get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);

    public LeftIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
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
            spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
        }
        else
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
        }
    }
}

}
