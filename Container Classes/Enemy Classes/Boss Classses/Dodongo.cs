using Enums;
using Microsoft.Xna.Framework;
using System;

public class Dodongo : IEnemy
{
    public int Health { get; set; } = 2; // Dies after eating 2 bombs
    public bool isDead { get; set; } = false;
    private IFrameManager iFrameManager = new IFrameManager(0.2); // 0.2 second of invincibility frames after taking damage
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    public IEnemyState dodongoState { get; set; }
    public Direction CurrentDirection { get; set; } = Direction.UP;

    // Adjustable speed parameter (units per second)
    public float Speed { get; set; } = 100f;

    private GraphicsDeviceManager _graphics;
    private DodongoSpriteFactory spriteFactory;

    public Rectangle Hitbox
    {
        get
        {
            switch (CurrentDirection)
            {
                case Direction.UP:
                    return new Rectangle((int)position.X, (int)position.Y - 32, 64, 32);
                    break;
                case Direction.DOWN:
                    return new Rectangle((int)position.X, (int)position.Y + 48, 64, 32);
                    break;
                case Direction.LEFT:
                    return new Rectangle((int)position.X, (int)position.Y, 48, 64);
                    break;
                case Direction.RIGHT:
                    return new Rectangle((int)position.X + 96, (int)position.Y, 48, 64);
                    break;
                default:
                    return new Rectangle((int)position.X, (int)position.Y, 32, 32);
            }
        }
    }

    public bool HitboxActive { get; set; }

    public Dodongo(DodongoSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Vector2 startPosition)
    {
        this._graphics = _graphics;
        this.spriteFactory = spriteFactory;
        position = startPosition;
        dodongoState = new MovingDodongoState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingDodongoSprite(position, CurrentDirection);
    }

    public void Update(GameTime gametime)
    {
        iFrameManager.Update(gametime);
        dodongoState.Update(gametime);
        Sprite.Update(gametime);

        // Update health and state transitions
        if (Health <= 0 && !isDead)
        {
            isDead = true;
            ChangeState(new DeadDodongoState(this, spriteFactory));
        }
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

    public void TakeDamage(int damage)
    {
        // Dodongo only takes damage from bombs, not general TakeDamage calls
        // Ignore this method - only TakeBombDamage should be used
    }

    public void TakeBombDamage(int damage)
    {
        if (iFrameManager.IsInvincible)
        {
            return; // Ignore damage if currently invincible
        }

        iFrameManager.Trigger(); // Start invincibility frames
        Health -= damage;
        dodongoState.TakeDamage();
    }

    public void ChangeState(IEnemyState newState)
    {
        dodongoState = newState;
    }

    public void OnWallCollision(Direction newDir)
    {
        dodongoState.OnWallCollision(newDir);
    }

    public void DropHearts(int numHearts)
    {
        // Implement logic for dropping hearts when Dodongo is defeated if necessary
    }
}