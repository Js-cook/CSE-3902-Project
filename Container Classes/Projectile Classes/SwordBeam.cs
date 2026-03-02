using Microsoft.Xna.Framework;
using Enums;

public class SwordBeam : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }

    public bool Active { get; set; }
    public Vector2 Position { get; set; }

    private double startTime = 0.0;
    private double endTime = 0.5;
    private ISprite sprite;
    private Direction direction;

    public SwordBeam(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        Active = true;
        this.direction = direction;
        sprite = spriteFactory.CreateSwordBeamSprite(position, direction);
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

        // TODO: make sword beam disappear after collision with enemy or screen boundary

        //if (startTime >= endTime)
        //{
        //    // do something to delete arrow
        //    Active = false;
        //}
    }
}
