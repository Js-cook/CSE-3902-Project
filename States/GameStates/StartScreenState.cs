using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Enums;
using Microsoft.Xna.Framework.Media;

public class StartScreenState : IGameState
{
    private HUDText text;
    private SpriteBatch _spriteBatch;
    private ISprite startScreenSprite;
    private AudioController audioController;
    private Song backgroundMusic;

    public GameStateSignal Signal { get; set; }

    public StartScreenState(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
        Signal = GameStateSignal.NONE;
    }

    public void LoadContent(ContentManager contentLoader)
    {
        //contentLoader.Load<Texture2D>("HUD");
        contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes");
        startScreenSprite = new StartScreenSprite(contentLoader.Load<Texture2D>("zelda-start-screen"), _spriteBatch);
        text = new HUDText(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), new Vector2(250, 600), _spriteBatch);
        text.Text = "Press left control";
        text.TextColor = Color.White;
        audioController = new AudioController();
        backgroundMusic = contentLoader.Load<Song>("BackgroundMusic");
        audioController.PlaySong(backgroundMusic);
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
        startScreenSprite.SpriteDraw(Vector2.Zero);
        text.Draw();
    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        audioController.PlaySong(backgroundMusic);
    }
}
