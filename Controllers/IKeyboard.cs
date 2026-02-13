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
        private int projectileInputLimiter = 0;
        public IKeyboard(Link player)
        {
            this.player = player;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            bool movementKeyActive = false;
            if(projectileInputLimiter > 0)
            {
                projectileInputLimiter--;
            }

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
            }

            if((keyState.IsKeyDown(Keys.D1) || keyState.IsKeyDown(Keys.NumPad1)) && projectileInputLimiter == 0)
            {
                player.playerState.FireArrow();
                projectileInputLimiter = 20;
            }

            if((keyState.IsKeyDown(Keys.D2) || keyState.IsKeyDown(Keys.NumPad2)) && projectileInputLimiter == 0)
            {
                player.playerState.FireSilverArrow();
                projectileInputLimiter = 20;
            }

            if((keyState.IsKeyDown(Keys.D3) || keyState.IsKeyDown(Keys.NumPad3)) && projectileInputLimiter == 0)
            {
                player.playerState.FireBoomerang();
                projectileInputLimiter = 20;
            }

            if (!movementKeyActive && !(player.playerState is LeftAttackingPlayerState || player.playerState is RightAttackingPlayerState || player.playerState is UpAttackingPlayerState || player.playerState is DownAttackingPlayerState))
            {
                player.playerState.BeIdle();
            }
        }
    }
}
