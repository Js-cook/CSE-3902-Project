using Enums;
using Microsoft.Xna.Framework;
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

    public Vector2 position { get; set; } 
    public ISprite Sprite { get; set; }   
    public Rectangle Hitbox => Rectangle.Empty; 
    public bool HitboxActive { get; set; } = false;
    public int Health { get; set; } = 999;
    public bool isDead { get; set; } = false;

   
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
                    WallDirection chosenWall = DetermineSpawnWall(distNorth, distSouth, distEast, distWest, minDistance);
                    Vector2 spawnPosition = CalculateSpawnPosition(chosenWall, player.position);

                    // Grab a hand from the pool, spawn it, and move it to the active list
                    Wallmaster spawnedHand = hiddenHands[0];
                    hiddenHands.RemoveAt(0);

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
    private WallDirection DetermineSpawnWall(float north, float south, float east, float west, float min)
    {
       
        if (Math.Abs(min - north) < 0.1f) return WallDirection.North;
        if (Math.Abs(min - south) < 0.1f) return WallDirection.South;
        if (Math.Abs(min - east) < 0.1f) return WallDirection.East;
        return WallDirection.West;
    }

    private Vector2 CalculateSpawnPosition(WallDirection wall, Vector2 playerPos)
    {
       
        switch (wall)
        {
            case WallDirection.North:
                return new Vector2(playerPos.X, roomBounds.Top);
            case WallDirection.South:
                return new Vector2(playerPos.X, roomBounds.Bottom);
            case WallDirection.East:
                return new Vector2(roomBounds.Right, playerPos.Y);
            case WallDirection.West:
                return new Vector2(roomBounds.Left, playerPos.Y);
            default:
                return Vector2.Zero;
        }
    }

   
    public List<Wallmaster> GetActiveHands()
    {
        return activeHands;
    }
}