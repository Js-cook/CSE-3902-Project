using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if ((keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) && !movementKeyActive)
            {
                // link go up
                player.playerState.ChangeDirection("up");
                player.MoveUp();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) && !movementKeyActive)
            {
                // link go down
                player.playerState.ChangeDirection("down");
                player.MoveDown();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) && !movementKeyActive)
            {
                // link go left
                player.playerState.ChangeDirection("left");
                player.MoveLeft();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) && !movementKeyActive)
            {
                // link go right
                player.playerState.ChangeDirection("right");
                player.MoveRight();
                movementKeyActive = true;
            }

            if(keyState.IsKeyDown(Keys.N) || keyState.IsKeyDown(Keys.Z))
            {
                player.playerState.BeAttacking();
                Debug.WriteLine("attack");
            }

            if (!movementKeyActive)
            {
                player.playerState.BeIdle();
            }
        }
    }
}
