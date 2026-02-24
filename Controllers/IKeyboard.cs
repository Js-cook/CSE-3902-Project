using Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Enums;
using System.Collections.Generic;

namespace Controllers
{
    public class IKeyboard : Interfaces.IController
    {

        private Link player;

        private Environment environment;
        private int envSwitchLimiter = 0;

        private Item item;
        private int itemSwitchLimiter = 0;

        private EnemyController enemyController;
        private int projectileInputLimiter = 0;

        private KeyboardState previousKeyboardState;

        private Game gameInstance;

        private AudioController audioController;
        private Dictionary<string, SoundEffect> soundEffects;

        public IKeyboard(Link player, Environment env, Item item, EnemyController enemyController, Game gameInstance, AudioController audioController, Dictionary<string, SoundEffect> soundEffect)
        {
            this.player = player;
            this.environment = env;
            this.item = item;
            this.enemyController = enemyController;
            this.gameInstance = gameInstance;
            this.audioController = audioController;
            this.soundEffects = soundEffect;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            bool movementKeyActive = false;

            if (envSwitchLimiter > 0)
            {
                envSwitchLimiter--;
            }
            if (itemSwitchLimiter > 0)
            {
                itemSwitchLimiter--;
            }
            if (projectileInputLimiter > 0)
            {
                projectileInputLimiter--;
            }

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

            if ((keyState.IsKeyDown(Keys.N) || keyState.IsKeyDown(Keys.Z)) && projectileInputLimiter == 0)
            {
                player.playerState.BeAttacking();
                audioController.PlaySoundEffect(soundEffects["SwordSlash"], 0.5f, 1.0f, 0.0f, false);
                projectileInputLimiter = 10;
            }

            if ((keyState.IsKeyDown(Keys.D1) || keyState.IsKeyDown(Keys.NumPad1)) && projectileInputLimiter == 0)
            {
                player.playerState.FireArrow();
                audioController.PlaySoundEffect(soundEffects["ArrowBoomerang"], 0.5f, 1.0f, 0.0f, false);
                projectileInputLimiter = 20;
            }

            if ((keyState.IsKeyDown(Keys.D2) || keyState.IsKeyDown(Keys.NumPad2)) && projectileInputLimiter == 0)
            {
                player.playerState.FireSilverArrow();
                audioController.PlaySoundEffect(soundEffects["ArrowBoomerang"], 0.5f, 1.0f, 0.0f, false);
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
                audioController.PlaySoundEffect(soundEffects["BombDrop"], 0.5f, 1.0f, 0.0f, false);
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

            //for item cycling
            if (keyState.IsKeyDown(Keys.U) && itemSwitchLimiter == 0)
            {
                item.CycleLeft();
                itemSwitchLimiter = 20;
            }
            if (keyState.IsKeyDown(Keys.I) && itemSwitchLimiter == 0)
            {
                item.CycleRight();
                itemSwitchLimiter = 20;
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
                item.CycleReset();
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
