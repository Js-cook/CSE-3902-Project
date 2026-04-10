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

        private KeyboardController keyboardController;

        private GameStateManager gameStateManager;
        private IGameState startScreenState;
        private IGameState playingState;
        private IGameState deathScreenState;
        private IGameState winScreenState;
        private IGameState inventoryState;

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

            winScreenState = new WinScreenState(playingState);
            // questionable syntax
            inventoryState = new InventoryState(playingState, ((PlayingState)playingState).player.playerInventory, _spriteBatch);
            inventoryState.LoadContent(Content);

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
            gameStateManager.SetCurrentState("StartScreen");
        }
    }

}
