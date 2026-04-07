using _3902_Project;
using Controllers;
using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprites;
using System.Collections.Generic;
using System.IO;

public class PlayingState : IGameState
{
    public Link player { get; private set; }
    private bool playerDead = false;
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

    private AudioController audioController;
    private Song backgroundMusic;

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

    private int projectileInputLimiter = 0;
    private int roomSwitchLimiter = 0;
    private int itemSwitchLimiter = 0;

    public GameStateSignal Signal { get; set; }

    private KeyboardState previousKeyboardState;


    public PlayingState(SpriteBatch spriteBatch, Dictionary<string, SoundEffect> sfx, GraphicsDeviceManager graphics)
    {
        _spriteBatch = spriteBatch;
        playerInventory = new LinkInventory();
        enemyMasterSpriteFactory = new EnemyMasterSpriteFactory();
        this.sfx = sfx;
        _graphics = graphics;
        Signal = GameStateSignal.NONE;
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

        audioController = new AudioController();

        player = new Link(spriteFactory, projectileSpriteFactory, projectileController, sfx, playerInventory);



        itemFactory = new ItemFactory(contentLoader.Load<Texture2D>("ItemSprites"), _spriteBatch);
        itemController = new ItemController(itemFactory, sfx);



        // EnemySpriteFactory, Enemy Actor Factory Enemy Controller, and EnemyLoader Initialization
        enemyMasterSpriteFactory.LoadContent(contentLoader, _spriteBatch);
        enemyFactory = new EnemyFactory(_graphics, enemyMasterSpriteFactory);
        enemyController = new EnemyController(sfx, itemController);
        enemyLoader = new EnemyLoader(enemyFactory, enemyController); // Handles laoding enemies into the enemyCotnroller which then updates each of them

        // Effect Factory and Effect Controller Initialization
        effectSpriteFactory = new EffectSpriteFactory(playerTexture, _spriteBatch); // Uses player texture spritesheet for the death cloud effect
        effectFactory = new EffectFactory(effectSpriteFactory);
        effectController = new EffectController(effectFactory);


        //room manager
        tileFactory = new TileFactory(contentLoader.Load<Texture2D>("DungeonTileSprites"), playerTexture, enemyTexture, treasureChestTexture, _spriteBatch);
        environment = new Environment(tileFactory);
        levelFileReader = new LevelFileReader(environment, enemyLoader);
        roomManager = new RoomManager(levelFileReader, 0, 1, enemyController);


        //keyboardController = new KeyboardController(player, roomManager, enemyController, this, itemController);

        // Add additional collision handlers here as needed
        collisionManager = new CollisionManager();

        CollisionRegistry.Initialize(collisionManager, roomManager);
    }

    public void ResolveKey(KeyboardState keyState)
    {
        bool movementKeyActive = false;
        if (itemSwitchLimiter > 0)
        {
            itemSwitchLimiter--;
        }
        if (projectileInputLimiter > 0)
        {
            projectileInputLimiter--;
        }
        if (roomSwitchLimiter > 0)
        {
            roomSwitchLimiter--;
        }

        //room management
        if (keyState.IsKeyDown(Keys.Y) && roomSwitchLimiter == 0) { roomManager.MoveUp(); roomSwitchLimiter = 10; }
        if (keyState.IsKeyDown(Keys.H) && roomSwitchLimiter == 0) { roomManager.MoveDown(); roomSwitchLimiter = 10; }
        if (keyState.IsKeyDown(Keys.G) && roomSwitchLimiter == 0) { roomManager.MoveLeft(); roomSwitchLimiter = 10; }
        if (keyState.IsKeyDown(Keys.J) && roomSwitchLimiter == 0) { roomManager.MoveRight(); roomSwitchLimiter = 10; }

        if (keyState.IsKeyDown(Keys.Z) && projectileInputLimiter == 0)
        {
            player.playerState.usePrimaryItem();
            projectileInputLimiter = 20;
        }

        if (keyState.IsKeyDown(Keys.X) && projectileInputLimiter == 0)
        {
            player.playerState.useSecondaryItem();
            projectileInputLimiter = 20;
        }

        //other inputs
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

        if (keyState.IsKeyDown(Keys.N) && projectileInputLimiter == 0)
        {
            player.playerState.BeAttacking();
            projectileInputLimiter = 10;
        }

        if ((keyState.IsKeyDown(Keys.D1) || keyState.IsKeyDown(Keys.NumPad1)) && projectileInputLimiter == 0)
        {
            player.playerState.FireArrow();
            projectileInputLimiter = 20;
        }

        if ((keyState.IsKeyDown(Keys.D2) || keyState.IsKeyDown(Keys.NumPad2)) && projectileInputLimiter == 0)
        {
            player.playerState.FireSilverArrow();
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

        // TEST: Spawn pickup items for collision testing (press once to spawn near player)
        if (keyState.IsKeyDown(Keys.T) && previousKeyboardState.IsKeyUp(Keys.T))
        {
            itemController.SpawnItem(ItemType.Heart, player.position + new Vector2(50, 0));
        }
        if (keyState.IsKeyDown(Keys.R) && previousKeyboardState.IsKeyUp(Keys.R))
        {
            itemController.SpawnItem(ItemType.Rupee, player.position + new Vector2(50, 0));
        }
        if (keyState.IsKeyDown(Keys.K) && previousKeyboardState.IsKeyUp(Keys.K))
        {
            itemController.SpawnItem(ItemType.Key, player.position + new Vector2(50, 0));
        }


        //if (keyState.IsKeyDown(Keys.Q))
        //{
        //    gameInstance.Exit();
        //}


        previousKeyboardState = keyState;
    }

    public void Update(GameTime gameTime)
    {
        // then update all entities based on that input

        // Only update player logic if no state transition signal is set otherwise,
        // it'll update with a null player sprite in case player is dead
        if (Signal == GameStateSignal.NONE) 
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
        if (CheckForWinCondition())
        {
            return; // If win condition is met, skip the rest of the update to prevent player from moving or doing other actions after picking up last Triforce piece
        } 

        if (player.health <= 0 && !playerDead)
        {
            playerDead = true;
            Signal = GameStateSignal.TO_DEATHSCREEN;
            player.playerState = new DyingPlayerState(player, spriteFactory, projectileController, sfx);
            return;
        }

        effectController.Update(gameTime);

        hud.Update(gameTime);
    }

    private bool CheckForWinCondition()
    {
        if (player.playerInventory.hasTriForcePiece)
        {
            player.playerState = new WinPlayerState(player, spriteFactory, projectileController, sfx);
            Signal = GameStateSignal.TO_WINSCREEN;
            return true;
        }

        return false;
    }
    public void Draw()
    {
        environment.Draw();
        hud.Draw();

        if (Signal == GameStateSignal.NONE)
            player.Draw();
        itemController.Draw();
        enemyController.Draw();
        projectileController.Draw();
        effectController.Draw();
    }

    public void ResetState()
    {
        Signal = GameStateSignal.NONE;

       

        // Controllers
        enemyController.enemyArray.Clear();
        projectileController.projectiles.Clear();
        effectController.ClearEffects();
        itemController.itemArray.Clear();
        

        // Player
        playerDead = false;
        player.HitboxActive = true;
        player.position = new Vector2(400 * 2, 250 * 2); // Spawn center position
        player.health = Settings.Instance.StartingPlayerHealth; // 3 hearts
        player.Hurt = false;
        player.playerState = new RightIdlePlayerState(player, spriteFactory, projectileController, sfx);
        player.projectiles.Clear();

        playerInventory.ResetInventory();

        levelFileReader.LoadLevel(0, 1, true); // Force load initial room

       

        // Input limiters
        projectileInputLimiter = 0;
        roomSwitchLimiter = 0;
        itemSwitchLimiter = 0;



    }
}