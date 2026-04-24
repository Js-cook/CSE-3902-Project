using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

public class PickupItem : ICollidable
{
    public Vector2 Position { get; set; }
    public ISprite Sprite { get; set; }
    public ItemType ItemType { get; set; }
    public bool HitboxActive { get; set; }
    // Track which room/grid cell this item originated from for persistence
    public int RoomRow { get; set; } = -1;
    public int RoomCol { get; set; } = -1;
    public float GridX { get; set; } = -1;
    public float GridY { get; set; } = -1;
    private Random random;
    private float directionTimer = 1.5f;
    private Vector2 flyDirection;



    public Rectangle Hitbox
    {
        get
        {
            // Most Zelda items are 16x16 pixels
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }

    public PickupItem(ISprite sprite, Vector2 position, ItemType itemType)
    {
        random = new Random();
        Sprite = sprite;
        Position = position;
        ItemType = itemType;
        HitboxActive = true; // Item is active by default
    }

    public void Update(GameTime gameTime)
    {
        if (Sprite != null)
        {
            Sprite.Update(gameTime);
        }

        if (this.ItemType == ItemType.Fairy)
        {

            Debug.WriteLine($"Updating Fairy at position {Position} with hitbox active: {HitboxActive}");
            // Fairy items have their own movement logic, so we don't want to deactivate the hitbox
            FlyAround(gameTime);
            
        }
    }

    public void Draw()
    {
        // Only draw if the item is active
        if (HitboxActive && Sprite != null)
        {
            Sprite.SpriteDraw(Position);
        }
    }

    public void FlyAround(GameTime gameTime)
    {
        // 1. Countdown using the decimal fraction of a second
        directionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (directionTimer <= 0)
        {
            flyDirection = new Vector2(random.Next(0, 2), random.Next(0, 2));
            directionTimer = (float)(random.NextDouble() * 0.5 + 0.5);
        }

      
        this.Position += flyDirection * Settings.Instance.FairyFlySpeed;
    }

    public void FairyOnWallCollision(Direction directionToGo)
    {
        // Reverse direction when colliding with a wall
        switch (directionToGo)
        {

            case Direction.DOWN:
                flyDirection = new Vector2(flyDirection.X, Math.Abs(flyDirection.Y)); // Move down
                break;
            case Direction.UP:
                flyDirection = new Vector2(flyDirection.X, -Math.Abs(flyDirection.Y)); // Move up
                break;
            case Direction.RIGHT:
                flyDirection = new Vector2(Math.Abs(flyDirection.X), flyDirection.Y); // Move right
                break;
            case Direction.LEFT:
                flyDirection = new Vector2(-Math.Abs(flyDirection.X), flyDirection.Y); // Move left
                break;
        }


        }
}
