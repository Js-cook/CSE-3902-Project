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
using System.Numerics;

public class WinScreenState : IGameState
{
    private IGameState playingState; // Uses playing state to access player for death animation and other controllers to show the current room in the background
    public GameStateSignal Signal { get; set; }

    private double winScreenTimer = 5; // duration of win screen in seconds


    private bool started = false;

    public WinScreenState(IGameState playingState)
    {
        Signal = GameStateSignal.NONE;
        this.playingState = playingState;
        
       
    }

    public void LoadContent(ContentManager contentLoader)
    {

    }

    public void ResolveKey(KeyboardState keyState)
    {

    }

    public void Update(GameTime gameTime)
    {

  
      
        // Wait for death animation to finish
        if (((WinPlayerState)((PlayingState)playingState).player.playerState).animationDone)
        {
            // once death aniamtion has finished, have a long enough timer to show the death screen before going to start screen
            winScreenTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (winScreenTimer <= 0)

            {
                winScreenTimer = 1.0; // reset timer for next time we enter death screen

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
        this.playingState.Draw();
    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
    }

}
