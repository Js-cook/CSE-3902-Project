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

        private IGameState gameState;

        private IGameState demoState;
        private IGameState playingState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1025;
            _graphics.PreferredBackBufferHeight = 928;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        // This method needs to be cleaned up bad
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Dictionary<string, SoundEffect> sfx = SFXLoader.LoadPlayerSFX(Content);

            playingState = new PlayingState(_spriteBatch, sfx, _graphics);
            playingState.LoadContent(Content);

            demoState = new StartScreenState(_spriteBatch);
            demoState.LoadContent(Content);

            gameState = demoState;

            keyboardController = new KeyboardController(this, gameState);
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
            keyboardController.Update();

            if (gameState.Signal == GameStateSignal.TO_PLAYING)
            {
                gameState = playingState;
                keyboardController.gameState = gameState;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameState.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    
    
}
