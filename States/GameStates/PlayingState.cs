using Controllers;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprites;
using System;
using System.Collections.Generic;
using System.IO;

public class PlayingState : IGameState
{
    private Link player;
    private LinkInventory playerInventory;
    private Texture2D playerTexture;
    private Texture2D enemyTexture;
    private Texture2D treasureChestTexture;
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

    private HUDBackgroundSprite hudBackgroundSprite;
    private HUD hud;
    private HUDSpriteFactory textFactory;

    private TileFactory tileFactory;
    private Environment environment;
    private LevelFileReader levelFileReader;
    private RoomManager roomManager;

    private ItemFactory itemFactory;
    private ItemController itemController;

    private CollisionManager collisionManager;

    private SpriteBatch _spriteBatch;

    private Dictionary<string, SoundEffect> sfx;
    
    private GraphicsDeviceManager _graphics;

    public PlayingState(SpriteBatch spriteBatch, Dictionary<string, SoundEffect> sfx, GraphicsDeviceManager graphics)
    {
        _spriteBatch = spriteBatch;
        playerInventory = new LinkInventory();
        enemyMasterSpriteFactory = new EnemyMasterSpriteFactory();
        this.sfx = sfx;
        _graphics = graphics;
    }

    public void LoadContent(ContentManager contentLoader)
    {
        playerTexture = contentLoader.Load<Texture2D>("LinkSprites");
        enemyTexture = contentLoader.Load<Texture2D>("EnemySprites");
        treasureChestTexture = contentLoader.Load<Texture2D>("TreasureChestSprite");
        spriteFactory = new PlayerSpriteFactory(playerTexture, _spriteBatch);
        projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, _spriteBatch);
        projectileController = new ProjectileController(projectileSpriteFactory, sfx);


        hudBackgroundSprite = new HUDBackgroundSprite(Vector2.Zero, _spriteBatch, contentLoader.Load<Texture2D>("HUD"));
        textFactory = new HUDSpriteFactory(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), _spriteBatch, contentLoader.Load<Texture2D>("HUD"), playerTexture);
        hud = new HUD(new Rectangle(0, 0, 1025, 244), textFactory, hudBackgroundSprite, playerInventory);

        AudioController audioController = new AudioController();
        audioController.PlaySong(contentLoader.Load<Song>("BackgroundMusic"));


        player = new Link(spriteFactory, projectileSpriteFactory, projectileController, sfx, playerInventory);


        // EnemySpriteFactory, Enemy Actor Factory Enemy Controller, and EnemyLoader Initialization
        enemyMasterSpriteFactory.LoadContent(contentLoader, _spriteBatch);
        enemyFactory = new EnemyFactory(_graphics, enemyMasterSpriteFactory);
        enemyController = new EnemyController(sfx);
        enemyLoader = new EnemyLoader(enemyFactory, enemyController); // Handles laoding enemies into the enemyCotnroller which then updates each of them

        // Effect Factory and Effect Controller Initialization
        effectSpriteFactory = new EffectSpriteFactory(playerTexture, _spriteBatch); // Uses player texture spritesheet for the death cloud effect
        effectFactory = new EffectFactory(effectSpriteFactory);
        effectController = new EffectController(effectFactory);


        //room manager
        tileFactory = new TileFactory(contentLoader.Load<Texture2D>("DungeonTileSprites"), playerTexture, enemyTexture, treasureChestTexture, _spriteBatch);
        environment = new Environment(tileFactory);
        levelFileReader = new LevelFileReader(environment, enemyLoader);
        string fullPath = Path.Combine(contentLoader.RootDirectory, "rooms.xml");
        roomManager = new RoomManager(levelFileReader, fullPath, 0, 1, enemyController);

        itemFactory = new ItemFactory(contentLoader.Load<Texture2D>("ItemSprites"), _spriteBatch);
        itemController = new ItemController(itemFactory, sfx);

        //keyboardController = new KeyboardController(player, roomManager, enemyController, this, itemController);

        // Add additional collision handlers here as needed
        collisionManager = new CollisionManager();

        CollisionRegistry.Initialize(collisionManager, roomManager);
    }
    public void Update(GameTime gameTime)
    {
        // then update all entities based on that input
        player.Update(gameTime);
        environment.Update(gameTime);
        itemController.Update(gameTime);
        enemyController.Update(gameTime);
        projectileController.Update(gameTime);

        List<ICollidable> collidables =
        [
            player,
                .. enemyController.enemyArray,
                .. projectileController.projectiles,
                .. enemyController.GetAllEnemyProjectiles(), // Enemy projectiles (Goriya boomerang, Aquamentus fireballs)
                .. environment.GetCollidableTiles(), //Added collidable tiles from environment since environment is not a collidable class, dk
                .. itemController.itemArray, // Pickup items
            ];

        collisionManager.Update(gameTime, collidables);
        effectController.Update(gameTime);

        hud.Update(gameTime);
    }
    public void Draw()
    {
        environment.Draw();
        hud.Draw();
        player.Draw();
        itemController.Draw();
        enemyController.Draw();
        projectileController.Draw();
        effectController.Draw();
    }
}