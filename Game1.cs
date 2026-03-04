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
using System.IO;

namespace _3902_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Link player;
        private Texture2D playerTexture;
        private Texture2D tileTexture;
        private Texture2D itemTexture;

        private ProjectileController projectileController;

        private EnemyController enemyController;

        private IController keyboardController;

        private TileFactory tileFactory;
        private Environment environment;
        private LevelFileReader levelFileReader;
        private RoomManager roomManager;

        private AudioController audioController;
        private Song dungeonSong;

        private Item item;

        private CollisionManager collisionManager;

        private FactoryStorage factoryStorage;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 512;
            _graphics.PreferredBackBufferHeight = 464;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            audioController = new();
            enemyController = new EnemyController();
            collisionManager = new CollisionManager();
            CollisionRegistry.Initialize(collisionManager);
        }

        // This method needs to be cleaned up bad
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("LinkSprites");
            tileTexture = Content.Load<Texture2D>("DungeonTileSprites");
            itemTexture = Content.Load<Texture2D>("ItemSprites");
            dungeonSong = Content.Load<Song>("BackgroundMusic");
            enemyController.LoadContent(Content, _spriteBatch, _graphics);
            Dictionary<string, SoundEffect> sfx = ContentLoaderHelper.LoadPlayerSFX(Content);

            factoryStorage = new FactoryStorage(playerTexture, tileTexture, itemTexture, _spriteBatch);

            audioController.PlaySong(dungeonSong);

            projectileController = new ProjectileController(factoryStorage, sfx);

            player = new Link(factoryStorage, projectileController, sfx);

            tileFactory = new TileFactory(tileTexture, playerTexture, _spriteBatch);
            environment = new Environment(tileFactory);

            //room manager
            levelFileReader = new LevelFileReader(environment);
            string fullPath = Path.Combine(Content.RootDirectory, "rooms.xml");
            roomManager = new RoomManager(levelFileReader, fullPath, 0, 1);

            levelFileReader.LoadLevel(Path.Combine(Content.RootDirectory, "Room1.csv"));

            item = new Item(factoryStorage);

            keyboardController = new Controllers.IKeyboard(player, environment, item, enemyController, this, audioController, LoadPlayerSFX(Content));

            // Add additional collision handlers here as needed
            collisionManager = new CollisionManager();

            CollisionRegistry.Initialize(collisionManager);


        }

        protected override void Update(GameTime gameTime)
        {

            keyboardController.Update(); // first check input

            // then update all entities based on that input
            player.Update(gameTime);
            environment.Update(gameTime);
            item.Update(gameTime);
            enemyController.Update(gameTime);
            projectileController.Update(gameTime);

            // 1. Create the empty master list
            List<ICollidable> collidables =
            [
                // 2. Add all collidable objects to the master list
                player,
                .. enemyController.enemyArray,
                .. projectileController.projectiles,
            ];

            collisionManager.Update(gameTime, collidables);






            // 5. Finally, run the physics!


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            environment.Draw();
            player.Draw();
            item.Draw();
            enemyController.Draw();
            projectileController.Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
