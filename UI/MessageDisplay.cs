using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MessageDisplay
{
    private string currentMessage;
    private int displayTimer;
    private const int DisplayDuration = 120; // 2 seconds at 60 FPS
    private SpriteFont font;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    public MessageDisplay(SpriteFont font, SpriteBatch spriteBatch, Vector2 position)
    {
        this.font = font;
        this.spriteBatch = spriteBatch;
        this.position = position;
        this.currentMessage = "";
        this.displayTimer = 0;
    }

    public void ShowMessage(string message)
    {
        currentMessage = message;
        displayTimer = DisplayDuration;
    }

    public void Update(GameTime gameTime)
    {
        if (displayTimer > 0)
        {
            displayTimer--;
        }
    }

    public void Draw()
    {
        if (displayTimer > 0 && !string.IsNullOrEmpty(currentMessage))
        {
            // Measure text to center it
            Vector2 textSize = font.MeasureString(currentMessage);
            Vector2 centeredPosition = new Vector2(
                position.X - textSize.X / 2,
                position.Y - textSize.Y / 2
            );

            // Draw black background
            Rectangle backgroundRect = new Rectangle(
                (int)centeredPosition.X - 10,
                (int)centeredPosition.Y - 5,
                (int)textSize.X + 20,
                (int)textSize.Y + 10
            );

            // Create a 1x1 white texture for the background (you can create this once and reuse)
            Texture2D backgroundTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { Color.Black });

            spriteBatch.Draw(backgroundTexture, backgroundRect, Color.Black * 0.7f);

            // Draw text
            spriteBatch.DrawString(font, currentMessage, centeredPosition, Color.White);
        }
    }
}
