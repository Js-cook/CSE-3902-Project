using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Controllers;
using Sprites;
using Interfaces;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

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
        private ProjectileController projectileController;

        private EnemyConroller enemyController;

        private IController keyboardController;

        private TileFactory tileFactory;
        private Environment environment;

        private AudioController audioController;
        private Song dungeonSong;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //AudioController audioController = new AudioController();
            base.Initialize();
        }

        private Dictionary<string, SoundEffect> LoadPlayerSFX(ContentManager content)
        {
            Dictionary<string, SoundEffect> res = new()
            {
                { "ArrowBoomerang", content.Load<SoundEffect>("SFX/ArrowBoomerang") },
                { "BombDrop", content.Load<SoundEffect>("SFX/BombDrop") },
                { "BombExplode", content.Load<SoundEffect>("SFX/BombExplode") },
                { "SwordSlash", content.Load<SoundEffect>("SFX/SwordSlash") }
            };

            return res;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AudioController audioController = new AudioController();
            dungeonSong = Content.Load<Song>("BackgroundMusic");
            audioController.PlaySong(dungeonSong);

            playerTexture = Content.Load<Texture2D>("LinkSprites");
            spriteFactory = new PlayerSpriteFactory(playerTexture, _spriteBatch);
            projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, _spriteBatch);
            projectileController = new ProjectileController(projectileSpriteFactory);

            player = new Link(spriteFactory, projectileSpriteFactory, projectileController);

            // Handles loading content for all enemies
            enemyController = new EnemyConroller();
            enemyController.LoadContent(Content, _spriteBatch, _graphics);

            tileFactory = new TileFactory(Content.Load<Texture2D>("DungeonTileSprites"), _spriteBatch);
            environment = new Environment(tileFactory);

            keyboardController = new Controllers.IKeyboard(player, environment, enemyController, this, audioController, LoadPlayerSFX(Content));

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            keyboardController.Update();
            player.Update(gameTime);
            environment.Update(gameTime);
            enemyController.Update(gameTime);
            projectileController.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            player.Draw();
            environment.Draw();
            enemyController.Draw();
            projectileController.Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
