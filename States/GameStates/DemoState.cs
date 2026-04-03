using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Enums;

public class DemoState : IGameState
{
    private HUDText text;
    private SpriteBatch _spriteBatch;

    public GameStateSignal Signal { get; private set; }

    public DemoState(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
        Signal = GameStateSignal.NONE;
    }

    public void LoadContent(ContentManager contentLoader)
    {
        //contentLoader.Load<Texture2D>("HUD");
        contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes");
        text = new HUDText(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), new Vector2(100, 100), _spriteBatch);
        text.Text = "Press left control to start";
        text.TextColor = Color.White;
    }

    public void ResolveKey(KeyboardState keyState)
    {
        // No key handling for this demo state
        if (keyState.IsKeyDown(Keys.LeftControl))
        {
            Signal = GameStateSignal.TO_PLAYING;
        }
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
