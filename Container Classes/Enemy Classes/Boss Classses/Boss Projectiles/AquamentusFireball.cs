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
    public Vector2 Position { get; set; }
    Vector2 velocity;
    private double startTime = 0.0;
    private double endTime = 3;
    
    public bool Active { get; set; }

    private ISprite sprite;

    public AquamentusFireball(Vector2 position, BossProjectileSpriteFactory spriteFactory, Vector2 velocity)
    {
        this.Position = position;
        this.velocity = velocity;
        sprite = spriteFactory.CreateAquamentusFireballSprite(position);
        Active = false;
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
}

