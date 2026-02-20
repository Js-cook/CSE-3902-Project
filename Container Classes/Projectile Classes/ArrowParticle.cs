using Microsoft.Xna.Framework;

public class ArrowParticle : IProjectile
{
    public Vector2 Position { get; set; }
    private double startTime = 0.0;
    private double endTime = 0.2;
    public bool Active { get; set; }

    private ISprite sprite;

    public ArrowParticle(Vector2 position, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        sprite = spriteFactory.CreateArrowParticleSprite(position);
        Active = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        if (startTime >= endTime)
        {
            // do something to delete particle
            Active = false;
        }
    }
}

