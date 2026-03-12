using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class HUDBackgroundSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    //private Texture2D texture;
    private Rectangle sourceRectangle = new Rectangle(258, 11, 255, 55);

    public HUDBackgroundSprite(Vector2 position, SpriteBatch spriteBatch, Texture2D texture)
    {
        this.position = position;
        this.spriteBatch = spriteBatch;
        this.texture = texture;
    }

    public void SpriteDraw(Vector2 position)
    {
        //spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 224), Color.White);
        spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 224), sourceRectangle, Color.White);
    }

    public void Update(GameTime gameTime)
    {

    }
}