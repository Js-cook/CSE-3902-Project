using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Controllers;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Enums;
namespace _3902_Project
{
    public class GameLoader
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDevice GraphicsDevice;
        private GraphicsDeviceManager _graphics;
        private ContentManager Content;

        private GameStateManager gameStateManager;
        private IGameState startScreenState;
        private IGameState playingState;
        private IGameState deathScreenState;
        private IGameState winScreenState;
        private IGameState inventoryState;
        private IGameState pausedState;

        public GameLoader(GraphicsDevice GraphicsDevice, ContentManager Content, GraphicsDeviceManager _graphics, GameStateManager gameStateManager, SpriteBatch spriteBatch)
        {
            this.GraphicsDevice = GraphicsDevice;
            this.Content = Content;
            this._graphics = _graphics;
            this.gameStateManager = gameStateManager;
            this._spriteBatch = spriteBatch;
        }

        // This method needs to be cleaned up bad
        public void LoadContent()
        {
            Dictionary<string, SoundEffect> sfx = SFXLoader.LoadPlayerSFX(Content);

            playingState = new PlayingState(_spriteBatch, sfx, _graphics);
            playingState.LoadContent(Content);

            startScreenState = new StartScreenState(_spriteBatch);
            startScreenState.LoadContent(Content);

            deathScreenState = new DeathScreenState(playingState);
            deathScreenState.LoadContent(Content);

            winScreenState = new WinScreenState(playingState);
            winScreenState.LoadContent(Content);
            ////questionable syntax
            inventoryState = new InventoryState(((PlayingState)playingState).player.playerInventory, _spriteBatch);
            inventoryState.LoadContent(Content);

            pausedState = new PausedState((PlayingState)playingState, _spriteBatch, Content.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"));
            pausedState.LoadContent(Content);



            LoadGameStates();
        }

        private void LoadGameStates()
        {
            gameStateManager.AddGameState("StartScreen", startScreenState);
            gameStateManager.AddGameState("Playing", playingState);
            gameStateManager.AddGameState("EndScreen", startScreenState);
            gameStateManager.AddGameState("DeathScreen", deathScreenState);
            gameStateManager.AddGameState("WinScreen", winScreenState);
            gameStateManager.AddGameState("InventoryScreen", inventoryState);
            gameStateManager.AddGameState("PauseScreen", pausedState);
            gameStateManager.SetCurrentState("StartScreen");
        }
    }

}
