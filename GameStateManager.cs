using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{
    public class GameStateManager
    {
        private Dictionary<string, IGameState> gameStates = new Dictionary<string, IGameState>();
        public IGameState currentState { get; private set; }
        private KeyboardController keyboardController;

        private PlayingState savedPlayingState;

        public GameStateManager(KeyboardController keyboardController)
        {
            gameStates = new Dictionary<string, IGameState>();
            this.keyboardController = keyboardController;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            keyboardController.Update();

            if(currentState is PlayingState)
            {
                savedPlayingState = (PlayingState)currentState;
            }

            CheckForStateChange();
        }

        public void Draw()
        {
            currentState.Draw();
        }

        public void AddGameState(string name, IGameState state)
        {
            gameStates[name] = state;
        }

        public void SetCurrentState(string name)
        {
            if (gameStates.ContainsKey(name))
            {
                if (currentState != null)
                    currentState.Signal = GameStateSignal.NONE; // Reset signal of the current state before switching

                //if (currentState is PlayingState)
                //{
                //    savedPlayingState = (PlayingState)currentState;
                //}

                if (name.Equals("InventoryScreen"))
                {
                    Debug.WriteLine("Update inventory of inventory screen");
                    ((InventoryState)(gameStates[name])).playerInventory = savedPlayingState.player.playerInventory;
                }

                if(currentState is InventoryState && name.Equals("Playing"))
                {
                    currentState = savedPlayingState;

                } else
                {
                    currentState = gameStates[name];
                }

                keyboardController.gameState = currentState;
            }
        }

       public void ToDeathScreen()
       {
            SetCurrentState("DeathScreen");
            currentState.ResetState();
        }

       public void StartStateToPlayState()
       {
            SetCurrentState("Playing");
            currentState.ResetState();
       }

        public void ReturnToStartScreen()
        {
            SetCurrentState("StartScreen");
            currentState.ResetState();
        }

        public void ToWinScreen()
        {
            SetCurrentState("WinScreen");
            currentState.ResetState();
        }

        public void ToInventoryScreen()
        {
            SetCurrentState("InventoryScreen");
            currentState.ResetState();
        }

        public void ToSavedPlayState()
        {
            SetCurrentState("Playing");
        }

        private void CheckForStateChange()
        {
            if (currentState.Signal == GameStateSignal.TO_PLAYING)
            {
                StartStateToPlayState(); // Transition to the Playing state from start screen state
            }


            if (currentState.Signal == GameStateSignal.TO_DEATHSCREEN)
            {
                ToDeathScreen(); // Transition to the Game Over state
            }


            if (currentState.Signal == GameStateSignal.TO_STARTSCREEN)
            {
                // Transition back to the Start Screen state. Can be from deathscreen, 
                // main menu button, etc
                ReturnToStartScreen(); 

            }

            if (currentState.Signal == GameStateSignal.TO_WINSCREEN)
            {
                ToWinScreen();
            }

            if(currentState.Signal == GameStateSignal.TO_INVENTORY)
            {
                ToInventoryScreen();
            }

            if(currentState.Signal == GameStateSignal.TO_SAVED_PLAYING)
            {
                ToSavedPlayState();
            }
        }
    }

}
