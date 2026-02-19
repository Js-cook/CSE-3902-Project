using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Enums;

namespace Controllers
{
    public class IKeyboard : Interfaces.IController
    {

        private Link player;
        private Environment environment;
        private int envSwitchLimiter = 0;
        private EnemyConroller enemyController;
        private int projectileInputLimiter = 0;

        private KeyboardState previousKeyboardState;

        private Game gameInstance;

        public IKeyboard(Link player, Environment env, EnemyConroller enemyConroller, Game gameInstance)
        {
            this.player = player;
            this.environment = env;
            this.enemyController = enemyConroller;
            this.gameInstance = gameInstance;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            bool movementKeyActive = false;

            if (envSwitchLimiter > 0)
            {
                envSwitchLimiter--;
            }
            if (projectileInputLimiter > 0)
            {
                projectileInputLimiter--;
            }

            // TODO: restructure to avoid all the ifs
            if ((keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) && !movementKeyActive)
            {
                // link go up
                player.playerState.ChangeDirection(Direction.UP);
                player.MoveUp();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) && !movementKeyActive)
            {
                // link go down
                player.playerState.ChangeDirection(Direction.DOWN);
                player.MoveDown();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) && !movementKeyActive)
            {
                // link go left
                player.playerState.ChangeDirection(Direction.LEFT);
                player.MoveLeft();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) && !movementKeyActive)
            {
                // link go right
                player.playerState.ChangeDirection(Direction.RIGHT);
                player.MoveRight();
                movementKeyActive = true;
            }

            if (keyState.IsKeyDown(Keys.N) || keyState.IsKeyDown(Keys.Z))
            {
                player.playerState.BeAttacking();
            }

            if ((keyState.IsKeyDown(Keys.D1) || keyState.IsKeyDown(Keys.NumPad1)) && projectileInputLimiter == 0)
            {
                player.playerState.FireArrow();
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D2) || keyState.IsKeyDown(Keys.NumPad2)) && projectileInputLimiter == 0)
            {
                player.playerState.FireSilverArrow();
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D3) || keyState.IsKeyDown(Keys.NumPad3)) && projectileInputLimiter == 0)
            {
                player.playerState.FireBoomerang();
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D4) || keyState.IsKeyDown(Keys.NumPad4)) && projectileInputLimiter == 0)
            {
                player.playerState.FireMagicBoomerang();
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D5) || keyState.IsKeyDown(Keys.NumPad5)) && projectileInputLimiter == 0)
            {
                player.playerState.FireFireball();
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D6) || keyState.IsKeyDown(Keys.NumPad6)) && projectileInputLimiter == 0)
            {
                player.playerState.FireBomb();
                projectileInputLimiter = 20;
            }

            if (keyState.IsKeyDown(Keys.E))
            {
                player.playerState.BeDamaged();
            }

            if (!movementKeyActive && !(player.playerState is LeftAttackingPlayerState || player.playerState is RightAttackingPlayerState || player.playerState is UpAttackingPlayerState || player.playerState is DownAttackingPlayerState || player.playerState is LeftUsingPlayerState || player.playerState is RightUsingPlayerState || player.playerState is UpUsingPlayerState || player.playerState is DownUsingPlayerState))
            {
                player.playerState.BeIdle();
            }

            //for tile cycling
            if (keyState.IsKeyDown(Keys.T) && envSwitchLimiter == 0)
            {
                environment.CycleLeft();
                envSwitchLimiter = 20;
            }
            if (keyState.IsKeyDown(Keys.Y) && envSwitchLimiter == 0)
            {
                environment.CycleRight();
                envSwitchLimiter = 20;
            }


            //Enemy Controls
            if (keyState.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
            {
                enemyController.PreviousEnemy();
            }
            if (keyState.IsKeyDown(Keys.P) && !previousKeyboardState.IsKeyDown(Keys.P))
            {
                enemyController.NextEnemy();
            }

            if (keyState.IsKeyDown(Keys.R))
            {
                // reset
                enemyController.ResetEnemy();
                environment.CycleReset();
                enemyController.CurrentEnemy().position = new Vector2(40, 30);
                player.position = new Vector2(10, 10);
                player.playerState.ChangeDirection(Direction.RIGHT);
                player.Hurt = false;

            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                gameInstance.Exit();
            }


            previousKeyboardState = keyState;
        }
    }
}
