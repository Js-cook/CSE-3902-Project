using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

public class PausedState : IGameState
{
    private PlayingState _playingState;
    private SpriteBatch _spriteBatch;
    private SpriteFont _messageFont;
    private KeyboardState _previousKeyboardState;
    private AudioController _audioController = new();
    private Song backgroundMusic;


    public GameStateSignal Signal { get; set; }

    public PausedState(PlayingState playingState, SpriteBatch spriteBatch, SpriteFont messageFont)
    {
        _playingState = playingState;
        _spriteBatch = spriteBatch;
        _messageFont = messageFont;
        Signal = GameStateSignal.NONE;



    }

    public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager contentLoader)
    {
        backgroundMusic = contentLoader.Load<Song>("BackgroundMusic");

    }

    public void ResolveKey(KeyboardState keyState)
    {
       
        if (keyState.IsKeyDown(Keys.P) && _previousKeyboardState.IsKeyUp(Keys.P))
        {
            Signal = GameStateSignal.TO_RESUME; 
        }

        _previousKeyboardState = keyState;
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw()
    {
        _playingState.Draw();


        // ---------------------------------------------------------
        // Code generated with the assistance of Google Gemini
        // Date: 2026-04-13
        // Description: Logic for drawing a semi-transparent overlay 
        // and centering text dynamically on the viewport.
        // ---------------------------------------------------------

        // Create a semi-transparent black overlay
        Texture2D pixel = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
        pixel.SetData(new[] { Color.Black }); // A single black pixel

        Rectangle overlayRect = _spriteBatch.GraphicsDevice.Viewport.Bounds; // Full screen rectangle

        _spriteBatch.Draw(pixel, overlayRect, Color.Black * 0.5f); // Draw the single pixel stretched over the entire screen with 50% opacity

        string message = "PAUSED";
        Vector2 textSize = _messageFont.MeasureString(message);

        // Calculate position to center the text
        Vector2 position = new Vector2(
            (overlayRect.Width / 2f) - (textSize.X / 2f),
            (overlayRect.Height / 2f) - (textSize.Y / 2f)
        );

        _spriteBatch.DrawString(_messageFont, message, position, Color.White);
    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        _previousKeyboardState = Keyboard.GetState(); // Initialize previous keyboard state


    }
}