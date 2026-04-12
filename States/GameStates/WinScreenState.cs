using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class WinScreenState : IGameState
{
    private IGameState playingState; 
    public GameStateSignal Signal { get; set; }

    private double winScreenTimerMax = 3.0;

    private double winScreenTimer; 


    private GraphicsDevice graphicsDevice;
    private SpriteBatch spriteBatch;
    private Texture2D blankTexture;
    private SpriteFont winFont;
    private float fadeAlpha = 0f;

    public WinScreenState(IGameState playingState)
    {
        winScreenTimer = winScreenTimerMax;

        Signal = GameStateSignal.NONE;
        this.playingState = playingState;

        
        spriteBatch = ((PlayingState)this.playingState)._spriteBatch;
        graphicsDevice = ((PlayingState)this.playingState)._spriteBatch.GraphicsDevice;

    }



    public void LoadContent(ContentManager contentLoader)
    {
     
        blankTexture = new Texture2D(graphicsDevice, 1, 1);
        blankTexture.SetData(new[] { Color.White });

        winFont = contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes");

    }

    public void ResolveKey(KeyboardState keyState)
    {

    }

    public void Update(GameTime gameTime)
    {
        // Wait for death/win animation to finish
        if (((WinPlayerState)((PlayingState)playingState).player.playerState).animationDone)
        {
            winScreenTimer -= gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate the alpha based on the timer. 
            // As timer goes from 5.0 down to 0, alpha goes from 0.0 up to 1.0.
            fadeAlpha = 1f - (float)(winScreenTimer / winScreenTimerMax);

            // Make sure alpha does not go over 1.0, or beloew 0.0
            fadeAlpha = MathHelper.Clamp(fadeAlpha, 0f, 1f);

            if (winScreenTimer <= 0)
            {
                winScreenTimer = winScreenTimerMax; 

                if (Signal != GameStateSignal.TO_STARTSCREEN)
                {
                    Signal = GameStateSignal.TO_STARTSCREEN;
                }
            }
        }

        this.playingState.Update(gameTime);
    }

    public void Draw()
    {
        // Draw whatever playingstate needs to draw
        this.playingState.Draw();

      
       
        Rectangle screenRectangle = new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      

        spriteBatch.Draw(blankTexture, screenRectangle, Color.Black * fadeAlpha);

        if (fadeAlpha > 0f)
        {
            string text = "Triforce Piece Acquired. You Won!";

            Vector2 textSize = winFont.MeasureString(text);
            Vector2 textPosition = new Vector2(
                (graphicsDevice.Viewport.Width - textSize.X) / 2,
                (graphicsDevice.Viewport.Height - textSize.Y) / 2
            );

            spriteBatch.DrawString(winFont, text, textPosition, Color.White);
        }

    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        winScreenTimer = winScreenTimerMax; // Reset the timer
        fadeAlpha = 0f;     // Reset the fade
    }
}