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
        private PlayerSpriteFactory spriteFactory;
        private ProjectileSpriteFactory projectileSpriteFactory;
        private ProjectileController projectileController;

        private EnemyMasterSpriteFactory enemyMasterSpriteFactory;
        private EnemyFactory enemyFactory;
        private EnemyController enemyController;
        private EnemyLoader enemyLoader;

        private EffectSpriteFactory effectSpriteFactory;
        private EffectFactory effectFactory;
        private EffectController effectController;

        //private HUDBackgroundSprite hudBackgroundSprite;

        private IController keyboardController;

        private TileFactory tileFactory;
        private Environment environment;
        private LevelFileReader levelFileReader;
        private RoomManager roomManager;

        private Song dungeonSong;

        private ItemFactory itemFactory;
        private Item item;

        private CollisionManager collisionManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //_graphics.PreferredBackBufferWidth = 512 * 1.5;
            //_graphics.PreferredBackBufferHeight = 464 * 1.5;
            _graphics.PreferredBackBufferWidth = 1025;
            _graphics.PreferredBackBufferHeight = 928;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //AudioController audioController = new AudioController();
            enemyMasterSpriteFactory = new EnemyMasterSpriteFactory();
            
            base.Initialize();
        }

        private Dictionary<string, SoundEffect> LoadPlayerSFX(ContentManager content)
        {
            Dictionary<string, SoundEffect> res = new()
            {
                { "ArrowBoomerang", content.Load<SoundEffect>("SFX/ArrowBoomerang") },
                { "BombDrop", content.Load<SoundEffect>("SFX/BombDrop") },
                { "BombExplode", content.Load<SoundEffect>("SFX/BombExplode") },
                { "SwordSlash", content.Load<SoundEffect>("SFX/SwordSlash") },
                { "EnemyDie", content.Load<SoundEffect>("SFX/EnemyDie") }
            };

            return res;
        }

        // This method needs to be cleaned up bad
        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Dictionary<string, SoundEffect> sfx = LoadPlayerSFX(Content);

            //hudBackgroundSprite = new HUDBackgroundSprite(Vector2.Zero, _spriteBatch);

            AudioController audioController = new AudioController();
            dungeonSong = Content.Load<Song>("BackgroundMusic");
          //  audioController.PlaySong(dungeonSong);

            playerTexture = Content.Load<Texture2D>("LinkSprites");
            spriteFactory = new PlayerSpriteFactory(playerTexture, _spriteBatch);
            projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, _spriteBatch);
            projectileController = new ProjectileController(projectileSpriteFactory, sfx);

            player = new Link(spriteFactory, projectileSpriteFactory, projectileController, sfx);


            // EnemySpriteFactory, Enemy Actor Factory Enemy Controller, and EnemyLoader Initialization
            enemyMasterSpriteFactory.LoadContent(Content, _spriteBatch, _graphics);
            enemyFactory = new EnemyFactory(_graphics, enemyMasterSpriteFactory);
            enemyController = new EnemyController(sfx);
            enemyLoader = new EnemyLoader(enemyFactory, enemyController); // Handles laoding enemies into the enemyCotnroller which then updates each of them

            //Load the enmies into the scene
            enemyLoader.LoadFakeLevel(); //Load a fake level whihc loads all the enmies

            // Effect Factory and Effect Controller Initialization
            effectSpriteFactory = new EffectSpriteFactory(playerTexture, _spriteBatch); // Uses player texture spritesheet for the death cloud effect
            effectFactory = new EffectFactory(effectSpriteFactory);
            effectController = new EffectController(effectFactory);


            //room manager
            tileFactory = new TileFactory(Content.Load<Texture2D>("DungeonTileSprites"),Content.Load<Texture2D>("LinkSprites"), _spriteBatch);
            environment = new Environment(tileFactory);
            levelFileReader = new LevelFileReader(environment);
            string fullPath = Path.Combine(Content.RootDirectory, "rooms.xml");
            roomManager = new RoomManager(levelFileReader, fullPath, 0, 1);

            itemFactory = new ItemFactory(Content.Load<Texture2D>("ItemSprites"), _spriteBatch);
            item = new Item(itemFactory);

            keyboardController = new Controllers.IKeyboard(player, roomManager, item, enemyController, this, audioController, LoadPlayerSFX(Content));

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
                .. enemyController.GetAllEnemyProjectiles(), // Enemy projectiles (Goriya boomerang, Aquamentus fireballs)
                .. environment.GetCollidableTiles(), //Added collidable tiles from environment since environment is not a collidable class, dk
                
            ];

            collisionManager.Update(gameTime, collidables);
            effectController.Update(gameTime); 






            // 5. Finally, run the physics!


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            environment.Draw();
            //hudBackgroundSprite.SpriteDraw(Vector2.Zero);
            player.Draw();
            item.Draw();
            enemyController.Draw();
            projectileController.Draw();
            effectController.Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

    
    
}
