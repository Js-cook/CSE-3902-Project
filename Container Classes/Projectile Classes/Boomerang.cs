using Enums;
using Microsoft.Xna.Framework;

public class Boomerang : IProjectile
{
    public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 0.75;
    private int directionSign = 1;

    public int DamageValue { get; } = 0;
    public bool Active { get; set; }

    private ISprite sprite;

    public bool isPlayerProjectile { get; set; } = true;



    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8 * 3, 8 * 3);
        }
    }
    public bool HitboxActive { get; set; } = true;
    private ProjectileSpriteFactory spriteFactory;

    public Boomerang(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateBoomerangSprite(position);
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

        Vector2 positionNew = new Vector2(Position.X, Position.Y);
        switch (direction)
        {
            case Direction.UP:
                positionNew.Y -= (6 * directionSign);
                break;
            case Direction.DOWN:
                positionNew.Y += (6 * directionSign);
                break;
            case Direction.LEFT:
                positionNew.X -= (6 * directionSign);
                break;
            case Direction.RIGHT:
                positionNew.X += (6 * directionSign);
                break;
        }
        Position = positionNew;

        if (startTime >= (endTime / 2))
        {
            directionSign = -1;
        }

        if (startTime >= endTime)
        {
            // do something to delete arrow
            Active = false;
            HitboxActive = false;
        }
    }

    public void OnCollision()
    {
        // Go back and dont damage again
        startTime = endTime / 2;
        HitboxActive = false;
    }
}

