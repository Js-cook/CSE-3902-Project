using Microsoft.Xna.Framework;

public class AquamentusFireball : IProjectile
{


    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }
    public bool HitboxActive { get; set; }
    public Vector2 Position { get; set; }
    Vector2 velocity;
    private double startTime = 0.0;
    private double endTime = 3;
    
    public bool Active { get; set; }

    public int DamageValue { get; } = 2;

    private ISprite sprite;

    // new properties
    public ICollidable owner { get; set; }
    public bool isPlayerProjectile { get; set; }

    public AquamentusFireball(Vector2 position, BossProjectileSpriteFactory spriteFactory, Vector2 velocity)
    {
        this.Position = position;
        this.velocity = velocity;
        sprite = spriteFactory.CreateAquamentusFireballSprite(position);
        Active = false;
        HitboxActive = false;

        // mark as enemy projectile
        isPlayerProjectile = false;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        sprite.Update(gametime);
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        Position += velocity;

        if (startTime >= endTime)
        {
            Active = false;
        }
    }

    public void ResetFireball(Vector2 position)
    {
        this.Position = position;
        startTime = 0.0;
    }

    public void OnCollision()
    {
        Active = false;
    }

    public void Activate()
    {
               Active = true;
        HitboxActive = true;
    }
}

