using Enums;
using Microsoft.Xna.Framework;


public class MagicBoomerang : IProjectile
{
    public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1.5;
    private int directionSign = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;
    public MagicBoomerang(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateMagicBoomerangSprite(position);
        Active = true;
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
                positionNew.Y -= (3 * directionSign);
                break;
            case Direction.DOWN:
                positionNew.Y += (3 * directionSign);
                break;
            case Direction.LEFT:
                positionNew.X -= (3 * directionSign);
                break;
            case Direction.RIGHT:
                positionNew.X += (3 * directionSign);
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
        }
    }
}

