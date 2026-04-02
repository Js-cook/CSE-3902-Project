using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class DemoState : IGameState
{
    private HUDText text;
    private SpriteBatch _spriteBatch;
    public DemoState(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
    }

    public void LoadContent(ContentManager contentLoader)
    {
        //contentLoader.Load<Texture2D>("HUD");
        contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes");
        text = new HUDText(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), new Vector2(100, 100), _spriteBatch);
        text.Text = "balls and ass";
        text.TextColor = Color.White;
    }
    public void Update(GameTime gameTime)
    {
        text.Update();
    }
    public void Draw()
    {
        text.Draw();
    }
}
