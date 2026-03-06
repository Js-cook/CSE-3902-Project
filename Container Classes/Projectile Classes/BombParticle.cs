using Microsoft.Xna.Framework;

public class BombParticle : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }

    public bool isPlayerProjectile { get; set; } = true;

    public bool HitboxActive { get; set; }
    public int DamageValue { get; set; } = 0; public bool Active { get; set; }
    public Vector2 Position { get; set; }

    private double startTime = 0.0;
    private double duration = 0.6;
    private ISprite sprite;

    public BombParticle(Vector2 position, ProjectileSpriteFactory spriteFactory)
    {
        Position = position;
        sprite = spriteFactory.CreateBombParticleSprite(position);
        Active = true;
        HitboxActive = true;
    }

    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }

    public void Update(GameTime gametime)
    {
        sprite.Update(gametime);
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        if (startTime >= duration)
        {
            // do something to delete particle
            Active = false;
            HitboxActive = false;
        }
    }

    public void OnCollision()
    {
        // do nothing, particle should not interact with anything
    }
}
