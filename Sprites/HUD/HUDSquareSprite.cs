using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class HUDSquareSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle coverage;
    private Color color;

    //private Texture2D texture;
    private Rectangle sourceRectangle = new Rectangle(1, 2, 1, 1);

    public HUDSquareSprite(Rectangle coverage, SpriteBatch spriteBatch, Texture2D texture, Color color)
    {
        this.coverage = coverage;
        this.spriteBatch = spriteBatch;
        this.texture = texture;
        this.color = color;
    }

    public void SpriteDraw(Vector2 position)
    {
        //spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 224), Color.White);
        //spriteBatch.Draw(texture, position, sourceRectangle, color);
        spriteBatch.Draw(texture, coverage, sourceRectangle, color);
    }

    public void Update(GameTime gameTime)
    {

    }
}