using Controllers;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System;
using System.Collections.Generic;


public class Link : ICollidable
{

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, Sprite.Width, Sprite.Height);
        }
    }
    public bool HitboxActive { get; set; } //not sure if this is necessary for Link, but it is for enemies and projectiles so I added it here for consistency and to implement ICollidable correctly
    public Vector2 position { get; set; }

    public float health { get; set; } = Settings.Instance.StartingPlayerHealth; // Health is measured in hearts. Each heart is 1 health point.
    public IPlayerSprite Sprite { get; set; }
    public IPlayerState playerState { get; set; }
    public ProjectileSpriteFactory projectileSpriteFactory { get; set; }

    public bool Hurt { get; set; }
    private double hurtTimer = 0.0;
    private double hurtDuration = 2.5;

    public List<IProjectile> projectiles { get; set; } = new List<IProjectile>();

    public LinkInventory playerInventory { get; set; }

    // Message display
    private string currentMessage = "";
    private int messageTimer = 0;
    private const int MessageDuration = 120; // 2 seconds at 60 FPS
    private int messageCooldown = 0; // Prevent spam
    private const int MessageCooldownDuration = 180; // 3 seconds cooldown between messages

    // Inventory/Stats
    //public int CurrentHealth { get; set; }
    //public int MaxHealth { get; set; }
    //public int RupeeCount { get; set; }
    //public int KeyCount { get; set; }
    //public int BombCount { get; set; }

    public Link(PlayerSpriteFactory spriteFactory, ProjectileSpriteFactory projectileSpriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect, LinkInventory playerInventory)
    {
        // Spawn player in center of floor area
        // Floor grid starts at ~(100, 88) and is 19x10 tiles of 32px each
        // Center position: (100 + (19*32)/2, 88 + (10*32)/2) ≈ (404, 248)
        position = new Vector2(400*2, 250*2);
        HitboxActive = true; // Enable collision detection for player
        playerState = new RightIdlePlayerState(this, spriteFactory, projectileController, soundEffect);
        this.projectileSpriteFactory = projectileSpriteFactory;
        Sprite = spriteFactory.CreateRightIdlePlayerSprite(position);
        this.playerInventory = playerInventory;

        //Adds Stats to Link, starting with 3 hearts (6 health) and no rupees, keys, or bombs
        //CurrentHealth = 6; 
        //MaxHealth = 6;
        //RupeeCount = 0;
        //KeyCount = 0;
        //BombCount = 0;
    }

    public void MoveUp() 
    {
        position = new Vector2(position.X, position.Y - (2 * Settings.Instance.PlayerSpeed));
    }

    public void MoveDown()
    {
        position = new Vector2(position.X, position.Y + (2  * Settings.Instance.PlayerSpeed));
    }

    public void MoveLeft()
    {
        position = new Vector2(position.X - (2 * Settings.Instance.PlayerSpeed), position.Y);
    }
    public void MoveRight()
    {
        position = new Vector2(position.X + (2 * Settings.Instance.PlayerSpeed), position.Y);
    }

    public void Update(GameTime gametime)
    {

        playerState.Update(gametime);

            Sprite.Update(gametime);

        //List<IProjectile> markedForDeletion = new List<IProjectile>();
        playerInventory.currentHearts = (int)health;

        if (Hurt)
        {
            hurtTimer += gametime.ElapsedGameTime.TotalSeconds;
            if(hurtTimer >= hurtDuration)
            {
                Hurt = false;
                hurtTimer = 0.0;
            }
        }

        // Update message timer
        if (messageTimer > 0)
        {
            messageTimer--;
        }

        // Update message cooldown
        if (messageCooldown > 0)
        {
            messageCooldown--;
        }
    }

    public void Draw()
    {
        Sprite.Hurt = Hurt;
        Sprite.SpriteDraw(position);
    }

    public void TakeDamage(float damage)
    {
        if (!Hurt)
        {
            health -= damage;
            Hurt = true;
            if (health <= 0)
            {
                // Handle player death (e.g., reset level, show game over screen, etc.)
                health = 0; // Ensure health doesn't go negative
            }
        }
    }

    public void OnHeartPickup()
    {
        health = Math.Min(health + Settings.Instance.HEALTH_PER_HEART, playerInventory.maxHearts * Settings.Instance.HEALTH_PER_HEART); // each heart is worth 2 health points
    }

    public void OnHeartContainerPickup()
    {
        playerInventory.maxHearts += 2;
        health = playerInventory.maxHearts * Settings.Instance.HEALTH_PER_HEART;
    }

    public void OnFairyPickup()
    {
        health = playerInventory.maxHearts * Settings.Instance.HEALTH_PER_HEART;
    }

    public void ShowMessage(string message)
    {
        // Only show message if not in cooldown
        if (messageCooldown <= 0)
        {
            currentMessage = message;
            messageTimer = MessageDuration;
            messageCooldown = MessageCooldownDuration;
        }
    }

    public string GetCurrentMessage()
    {
        return messageTimer > 0 ? currentMessage : "";
    }

    public bool HasMessage()
    {
        return messageTimer > 0;
    }
}

