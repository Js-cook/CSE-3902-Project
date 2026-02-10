using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Controllers
{
    public class IKeyboard : Interfaces.IController
    {

        private Link player;
        public IKeyboard(Link player)
        {
            this.player = player;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            Boolean movementKeyActive = false;

            // TODO: restructure to avoid all the ifs
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                // link go up
                movementKeyActive = true;
                player.playerState.ChangeDirection("up");
                player.MoveUp();
            }

            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                // link go down
                movementKeyActive = true;
                player.playerState.ChangeDirection("down");
                player.MoveDown();
            }

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                // link go left
                movementKeyActive = true;
                player.playerState.ChangeDirection("left");
                player.MoveLeft();
            }

            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                // link go right
                movementKeyActive = true;
                player.playerState.ChangeDirection("right");
                player.MoveRight();
            }

            if (!movementKeyActive)
            {
                player.playerState.BeIdle();
            }
        }
    }
}
