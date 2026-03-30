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

        private Link player;

        private int itemSwitchLimiter = 0;

        private EnemyController enemyController;
        private int projectileInputLimiter = 0;

        private KeyboardState previousKeyboardState;

        private Game gameInstance;

        private RoomManager roomManager;
        private int roomSwitchLimiter = 0;

        private ItemController itemController;

        public KeyboardController(Link player, RoomManager roomManager, EnemyController enemyController, Game gameInstance, ItemController itemController)
        {
            this.player = player;
            this.gameInstance = gameInstance;
            this.roomManager = roomManager;
            this.itemController = itemController;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            bool movementKeyActive = false;

            if (itemSwitchLimiter > 0)
            {
                itemSwitchLimiter--;
            }
            if (projectileInputLimiter > 0)
            {
                projectileInputLimiter--;
            }
            if (roomSwitchLimiter > 0)
            {
                roomSwitchLimiter--;
            }

            //room management
            if (keyState.IsKeyDown(Keys.Y) && roomSwitchLimiter == 0) { roomManager.MoveUp(); roomSwitchLimiter = 10; }
            if (keyState.IsKeyDown(Keys.H) && roomSwitchLimiter == 0) { roomManager.MoveDown(); roomSwitchLimiter = 10; }
            if (keyState.IsKeyDown(Keys.G) && roomSwitchLimiter == 0) { roomManager.MoveLeft(); roomSwitchLimiter = 10; }
            if (keyState.IsKeyDown(Keys.J) && roomSwitchLimiter == 0) { roomManager.MoveRight(); roomSwitchLimiter = 10; }

            if(keyState.IsKeyDown(Keys.Z) && projectileInputLimiter == 0)
            {
                player.playerState.usePrimaryItem();
                projectileInputLimiter = 20;
            }

            if(keyState.IsKeyDown(Keys.X) && projectileInputLimiter == 0)
            {
                player.playerState.useSecondaryItem();
                projectileInputLimiter = 20;
            }

            //other inputs
            if ((keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)) && !movementKeyActive)
            {
                player.playerState.ChangeDirection(Direction.UP);
                player.MoveUp();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)) && !movementKeyActive)
            {
                player.playerState.ChangeDirection(Direction.DOWN);
                player.MoveDown();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) && !movementKeyActive)
            {
                player.playerState.ChangeDirection(Direction.LEFT);
                player.MoveLeft();
                movementKeyActive = true;
            }

            if ((keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) && !movementKeyActive)
            {
                player.playerState.ChangeDirection(Direction.RIGHT);
                player.MoveRight();
                movementKeyActive = true;
            }

            if (keyState.IsKeyDown(Keys.N) && projectileInputLimiter == 0)
            {
                player.playerState.BeAttacking();
                projectileInputLimiter = 10;
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

            if (!movementKeyActive)
            {
                player.playerState.BeIdle();
            }

            // TEST: Spawn pickup items for collision testing (press once to spawn near player)
            if (keyState.IsKeyDown(Keys.T) && previousKeyboardState.IsKeyUp(Keys.T))
            {
                itemController.SpawnItem(ItemType.Heart, player.position + new Vector2(50, 0));
            }
            if (keyState.IsKeyDown(Keys.R) && previousKeyboardState.IsKeyUp(Keys.R))
            {
                itemController.SpawnItem(ItemType.Rupee, player.position + new Vector2(50, 0));
            }
            if (keyState.IsKeyDown(Keys.K) && previousKeyboardState.IsKeyUp(Keys.K))
            {
                itemController.SpawnItem(ItemType.Key, player.position + new Vector2(50, 0));
            }


            if (keyState.IsKeyDown(Keys.Q))
            {
                gameInstance.Exit();
            }


            previousKeyboardState = keyState;
        }
    }
}
