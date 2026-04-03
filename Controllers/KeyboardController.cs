using Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Enums;
using System.Collections.Generic;

namespace Controllers
{
    public class KeyboardController : Interfaces.IController
    {
        private Game gameInstance;

        public IGameState gameState { get; set; }

        public KeyboardController(Game gameInstance, IGameState gameState)
        {
            this.gameInstance = gameInstance;
            this.gameState = gameState;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            gameState.ResolveKey(keyState);

            if (keyState.IsKeyDown(Keys.Q))
            {
                gameInstance.Exit();
            }
        }
    }
}
