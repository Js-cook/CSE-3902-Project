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
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardController keyboardController;

        private GameStateManager gameStateManager;
        private GameLoader gameLoader;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1025;
            _graphics.PreferredBackBufferHeight = 928;
            _graphics.ApplyChanges();

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            keyboardController = new KeyboardController(this);
            gameStateManager = new GameStateManager(keyboardController);
            gameLoader = new GameLoader(GraphicsDevice, Content, _graphics, gameStateManager, _spriteBatch);
            



        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        // This method needs to be cleaned up bad
        protected override void LoadContent()
        {
            gameLoader.LoadContent(); // Loads all content and gameStates in the GameState Manager and initializes the first game state

        }

        protected override void Update(GameTime gameTime)
        {
            gameStateManager.Update(gameTime); // Updates currentGame state and keyboard controller
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameStateManager.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    
    
}
