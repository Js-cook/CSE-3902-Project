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

public class DeathScreenState : IGameState
{
    private IGameState playingState; // Uses playing state to access player for death animation and other controllers to show the current room in the background
    public GameStateSignal Signal { get; set; }

    private double deathScreenTimerMax = 3; // Duration of death screen in seconds
    private double deathScreenTimer; // Timer to track how long the death screen has been displayed

    private GraphicsDevice graphicsDevice;
    private SpriteBatch spriteBatch;
    private Texture2D blankTexture;
    private SpriteFont winFont;
    private float fadeAlpha = 0f;

    public DeathScreenState(IGameState playingState)
    {

        deathScreenTimer = deathScreenTimerMax;
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

        
        Debug.WriteLine(((PlayingState)playingState).player.playerState.ToString());

        // Wait for death animation to finish
        if (((PlayingState)playingState).player.playerState is DeadPlayerState)
        {
            // once death aniamtion has finished, have a long enough timer to show the death screen before going to start screen
            deathScreenTimer -= gameTime.ElapsedGameTime.TotalSeconds;

            fadeAlpha = fadeAlpha = 1f - (float)(deathScreenTimer / deathScreenTimerMax);

            fadeAlpha = MathHelper.Clamp(fadeAlpha, 0f, 1f); // make sure alpha doesn't go above 1 or below 0
            if (deathScreenTimer <= 0)
            
            {
                deathScreenTimer = deathScreenTimerMax; // reset timer for next time we enter death screen

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
            string text = "You Died!";

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
       deathScreenTimer = deathScreenTimerMax;
       fadeAlpha = 0f;
    }
       
}
