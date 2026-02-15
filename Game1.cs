using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Controllers;
using Sprites;
using Interfaces;

namespace _3902_Project
{
    public class Game1 : Game
    {
        //private Controllers.IKeyboard keyboardController = new Controllers.IKeyboard();

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Link player;
        private Texture2D playerTexture;
        private PlayerSpriteFactory spriteFactory;
        private ProjectileSpriteFactory projectileSpriteFactory;

        private EnemyConroller enemyController;



        private IController keyboardController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("LinkSprites");
            spriteFactory = new PlayerSpriteFactory(playerTexture, _spriteBatch);
            projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, _spriteBatch);

            player = new Link(spriteFactory, projectileSpriteFactory);


            // Handles loading content for all enemies
            enemyController = new EnemyConroller();
            enemyController.LoadContent(Content, _spriteBatch, _graphics);

            keyboardController = new Controllers.IKeyboard(player, enemyController);
        }

        protected override void Update(GameTime gameTime)
        { 
            // TODO: Add your update logic here
            keyboardController.Update();
            player.Update(gameTime);
            enemyController.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            player.Draw();
            enemyController.Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
