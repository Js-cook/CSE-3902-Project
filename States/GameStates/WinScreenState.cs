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

    private bool animationComplete = false;
    private int selectedOption = 0; // 0 = Continue, 1 = Main Menu
    private KeyboardState previousKeyState;

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
        if (!animationComplete)
        {
            previousKeyState = keyState;
            return;
        }

        // Left/Right to switch options
        if ((keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) && previousKeyState.IsKeyUp(Keys.Up) && previousKeyState.IsKeyUp(Keys.W))
        {
            selectedOption = 0;
        }

        if ((keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) && previousKeyState.IsKeyUp(Keys.Down) && previousKeyState.IsKeyUp(Keys.S))
        {
            selectedOption = 1;
        }

        // Enter/Z to confirm
        if ((keyState.IsKeyDown(Keys.Enter) || keyState.IsKeyDown(Keys.Z)) && (previousKeyState.IsKeyUp(Keys.Enter) && previousKeyState.IsKeyUp(Keys.Z)))
        {
            if (selectedOption == 0)
            {
                // Continue Playing - unlock the door, stay in level 1
                Debug.WriteLine("[WinScreenState] Player chose to continue playing!");
                ContinuePlaying();
            }
            else if (selectedOption == 1)
            {
                // Main Menu
                Debug.WriteLine("[WinScreenState] Player chose to go to main menu!");
                Signal = GameStateSignal.TO_STARTSCREEN;
            }
        }

        previousKeyState = keyState;
    }

    private void ContinuePlaying()
    {
        PlayingState pState = (PlayingState)playingState;

        Debug.WriteLine("[WinScreenState] Unlocking exit door in triforce room (1,5)...");

        // Put the player into a playable state
        pState.player.playerState = new RightIdlePlayerState(pState.player, pState.player.playerSpriteFactory, pState.player.projectileController, pState.player.soundEffect);

        pState.audioController.PlaySong(pState.backgroundMusic);
        // Go back to playing state
        Signal = GameStateSignal.TO_SAVED_PLAYING;
    }

    public void Update(GameTime gameTime)
    {
        // Wait for death/win animation to finish
        if (((WinPlayerState)((PlayingState)playingState).player.playerState).animationDone && !animationComplete)
        {
            animationComplete = true;
        }

        if (animationComplete)
        {
            winScreenTimer -= gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate the alpha based on the timer. 
            // As timer goes from 3.0 down to 0, alpha goes from 0.0 up to 1.0.
            fadeAlpha = 1f - (float)(winScreenTimer / winScreenTimerMax);

            // Make sure alpha does not go over 1.0, or below 0.0
            fadeAlpha = MathHelper.Clamp(fadeAlpha, 0f, 1f);
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
                (graphicsDevice.Viewport.Height - textSize.Y) / 2 - 100
            );

            spriteBatch.DrawString(winFont, text, textPosition, Color.White);

            // Draw options if animation is complete
            if (animationComplete)
            {
                string continueText = selectedOption == 0 ? "> Continue Playing <" : "Continue Playing";
                string menuText = selectedOption == 1 ? "> Main Menu <" : "Main Menu";

                Vector2 continueSize = winFont.MeasureString(continueText);
                Vector2 continuePos = new Vector2(
                    (graphicsDevice.Viewport.Width - continueSize.X) / 2,
                    (graphicsDevice.Viewport.Height - continueSize.Y) / 2 + 50
                );

                Vector2 menuSize = winFont.MeasureString(menuText);
                Vector2 menuPos = new Vector2(
                    (graphicsDevice.Viewport.Width - menuSize.X) / 2,
                    (graphicsDevice.Viewport.Height - menuSize.Y) / 2 + 100
                );

                Color continueColor = selectedOption == 0 ? Color.Yellow : Color.White;
                Color menuColor = selectedOption == 1 ? Color.Yellow : Color.White;

                spriteBatch.DrawString(winFont, continueText, continuePos, continueColor);
                spriteBatch.DrawString(winFont, menuText, menuPos, menuColor);
            }
        }
    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        winScreenTimer = winScreenTimerMax;
        fadeAlpha = 0f;
        animationComplete = false;
        selectedOption = 0;
        previousKeyState = Keyboard.GetState();
    }


}