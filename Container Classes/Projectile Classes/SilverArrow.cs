using Enums;
using Microsoft.Xna.Framework;

public class SilverArrow : IProjectile
{
    public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public SilverArrow(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateSilverArrowSprite(position, direction);
        Active = true;
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
                positionNew.Y -= 5;
                break;
            case Direction.DOWN:
                positionNew.Y += 5;
                break;
            case Direction.LEFT:
                positionNew.X -= 5;
                break;
            case Direction.RIGHT:
                positionNew.X += 5;
                break;
        }
        Position = positionNew;

        if (startTime >= endTime)
        {
            Active = false;
        }
    }
}

