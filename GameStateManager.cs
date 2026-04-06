using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace _3902_Project
{
    public class GameStateManager
    {


        private Dictionary<string, IGameState> gameStates = new Dictionary<string, IGameState>();
        public IGameState currentState { get; private set; }
        private KeyboardController keyboardController;


        public GameStateManager(KeyboardController keyboardController)
        {
            gameStates = new Dictionary<string, IGameState>();
            this.keyboardController = keyboardController;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            keyboardController.Update();

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

                currentState = gameStates[name];
                keyboardController.gameState = currentState;
            }
        }

       public void GameOver()
       {
            SetCurrentState("DeathScreen");
       }

       public void StartGame()
       {
            SetCurrentState("Playing");
            currentState.ResetState();
       }

        public void ReturnToStartScreen()
        {
            SetCurrentState("StartScreen");
            currentState.ResetState();
        }

        private void CheckForStateChange()
        {
            if (currentState.Signal == GameStateSignal.TO_PLAYING)
            {
                StartGame(); // Transition to the Playing state
            }
            if (currentState.Signal == GameStateSignal.TO_GAMEOVER)
            {
                GameOver(); // Transition to the Game Over state
            }
            if (currentState.Signal == GameStateSignal.TO_STARTSCREEN)
            {
                ReturnToStartScreen(); // Transition to the Start Screen state
            }


        }




    }

}
