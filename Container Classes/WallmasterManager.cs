using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class WallmasterManager : IEnemy
{

    public enum WallDirection
    {
        North,
        South,
        East,
        West
    }

    public Action OnResetDungeon { get; set; } // this is set by room manager to trigger reset dungeon when wallmaster drags player into wall

    private Texture2D _debugTexture;
    public Vector2 position { get; set; } 
    public ISprite Sprite { get; set; }   
    public Rectangle Hitbox => Rectangle.Empty; 
    public bool HitboxActive { get; set; } = false;
    public int Health { get; set; } = 999;
    public bool isDead { get; set; } = false;


    private Random _rand = new Random();

    private Rectangle roomBounds;
    private Link player; 

    private List<Wallmaster> hiddenHands;
    private List<Wallmaster> activeHands;
    private EnemyFactory enemyFactory; 

    private float proximityTimer = 0f;
    private const float SpawnDelay = 1.5f; 
    private const float ProximityThreshold = 32f; // Distance from wall to trigger (e.g., 2 tiles)

    public WallmasterManager(Rectangle roomBounds, Link player, EnemyFactory enemyFactory)
    {
        this.roomBounds = roomBounds;
        this.player = player;
        this.enemyFactory = enemyFactory;

        this.hiddenHands = new List<Wallmaster>();
        this.activeHands = new List<Wallmaster>();

        
    }

 
    public void InitializeHands(int count)
    {
        for (int i = 0; i < count; i++)
        {
           
            Wallmaster hand = enemyFactory.CreateWallmaster(Vector2.Zero);
            hand.HitboxActive = false;
            hiddenHands.Add(hand);
        }
    }

    public void Update(GameTime gameTime)
    {
       
        for (int i = activeHands.Count - 1; i >= 0; i--)
        {
            Wallmaster hand = activeHands[i];
            hand.Update(gameTime);

            
            if (!hand.HitboxActive || hand.isDead)
            {
                if (!hand.isDead)
                {
                    hiddenHands.Add(hand);
                }
                activeHands.RemoveAt(i);
            }
        }

      
        if (hiddenHands.Count > 0)
        {
            
            float distWest = Math.Abs(player.position.X - roomBounds.Left);
            float distEast = Math.Abs(roomBounds.Right - player.position.X);
            float distNorth = Math.Abs(player.position.Y - roomBounds.Top);
            float distSouth = Math.Abs(roomBounds.Bottom - player.position.Y);

            float minDistance = Math.Min(
                Math.Min(distWest, distEast),
                Math.Min(distNorth, distSouth)
            );

            if (minDistance <= ProximityThreshold)
            {
                proximityTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (proximityTimer >= SpawnDelay)
                {


                    WallDirection chosenWall = DetermineSpawnWall(roomBounds, player.position);
                    Vector2 spawnPosition = CalculateSpawnPosition(chosenWall, player.position);

                    // Grab a hand from the pool, spawn it, and move it to the active list
                    Wallmaster spawnedHand = hiddenHands[0];

                    System.Diagnostics.Debug.WriteLine($"Manager spawning hand. Has Action: {this.OnResetDungeon != null}");
                    hiddenHands.RemoveAt(0);

                    spawnedHand.OnResetDungeon = this.OnResetDungeon; // Pass the reset action to the hand

                    spawnedHand.SpawnAt(chosenWall, spawnPosition);
                    activeHands.Add(spawnedHand);

                    proximityTimer = 0f;
                }
            }
            else
            {
                proximityTimer = 0f;
            }
        }
    }

    public void Draw()
    {
        foreach (var hand in activeHands)
        {
            hand.Draw();
        }
    }

  

    public void TakeDamage(int damage) { }
    public void ChangeState(IEnemyState newState) {  }
    public void OnWallCollision(Direction newDir) {  }
    public void DropHearts(int numHearts) { }

    // --- Helper Methods ---
    private WallDirection DetermineSpawnWall(Rectangle bounds, Vector2 playerPos)
    {
        // 1. Calculate the actual gaps (Must be positive)
        float distNorth = playerPos.Y - bounds.Top;
        float distSouth = bounds.Bottom - playerPos.Y; // IMPORTANT: Bottom - Y
        float distWest = playerPos.X - bounds.Left;
        float distEast = bounds.Right - playerPos.X;   // IMPORTANT: Right - X

        // 2. Start by assuming North is the closest
        float min = distNorth;
        WallDirection bestWall = WallDirection.North;

        // 3. Compare the others one by one
        if (distSouth < min)
        {
            min = distSouth;
            bestWall = WallDirection.South;
        }
        if (distEast < min)
        {
            min = distEast;
            bestWall = WallDirection.East;
        }
        if (distWest < min)
        {
            min = distWest;
            bestWall = WallDirection.West;
        }

        return bestWall;
    }

    private Vector2 CalculateSpawnPosition(WallDirection wall, Vector2 playerPos)
    {

        
        int spread = 32;
        float offset = _rand.Next(-spread, spread + 1);

      
        int handSize = 16;

        switch (wall)
        {
            case WallDirection.North:
                float safeXNorth = MathHelper.Clamp(playerPos.X + offset, roomBounds.Left, roomBounds.Right - handSize);
                return new Vector2(safeXNorth, roomBounds.Top);

            case WallDirection.South:
                float safeXSouth = MathHelper.Clamp(playerPos.X + offset, roomBounds.Left, roomBounds.Right - handSize);
                return new Vector2(safeXSouth, roomBounds.Bottom);

            case WallDirection.East:
                float safeYEast = MathHelper.Clamp(playerPos.Y + offset, roomBounds.Top, roomBounds.Bottom - handSize);
                return new Vector2(roomBounds.Right, safeYEast);

            case WallDirection.West:
                float safeYWest = MathHelper.Clamp(playerPos.Y + offset, roomBounds.Top, roomBounds.Bottom - handSize);
                return new Vector2(roomBounds.Left, safeYWest);

            default:
                return Vector2.Zero;
        }
    }

   
    public List<Wallmaster> GetActiveHands()
    {
        return activeHands;
    }
}