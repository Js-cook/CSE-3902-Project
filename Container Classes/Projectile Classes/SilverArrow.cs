using Enums;
using Microsoft.Xna.Framework;

public class SilverArrow : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8 * 3, 8 * 3);
        }
    }
    public bool HitboxActive { get; set; }
    public int DamageValue { get; set; } = 1; public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    // IProjectile members
    public ICollidable owner { get; set; }
    public bool isPlayerProjectile { get; set; }

    public SilverArrow(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateSilverArrowSprite(position, direction);
        Active = true;
        HitboxActive = true;

        // mark as player projectile
        isPlayerProjectile = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        Vector2 positionNew = new Vector2(Position.X, Position.Y);
        switch (direction)
        {
            case Direction.UP:
                positionNew.Y -= 8;
                break;
            case Direction.DOWN:
                positionNew.Y += 8;
                break;
            case Direction.LEFT:
                positionNew.X -= 8;
                break;
            case Direction.RIGHT:
                positionNew.X += 8;
                break;
        }
        Position = positionNew;

        if (startTime >= endTime)
        {
            Active = false;
            HitboxActive = false;
        }
    }

    public void OnCollision()
    {
        HitboxActive = false;
            Active = false;

    }
}

