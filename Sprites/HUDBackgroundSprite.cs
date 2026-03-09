using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class HUDBackgroundSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    public HUDBackgroundSprite(Vector2 position, SpriteBatch spriteBatch)
    {
        this.position = position;
        this.spriteBatch = spriteBatch;
        this.texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.Black });
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 224), Color.White);
    }

    public void Update(GameTime gameTime)
    {

    }
}