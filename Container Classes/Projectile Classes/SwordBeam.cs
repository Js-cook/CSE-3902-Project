using Microsoft.Xna.Framework;
using Enums;

public class SwordBeam : IProjectile
{

    public int DamageValue { get; set; } = 1;
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8*3, 8*3);
        }
    }
    public bool HitboxActive { get; set; }

    public bool Active { get; set; }
    public Vector2 Position { get; set; }

    private double startTime = 0.0;
    private ISprite sprite;
    private Direction direction;

    // new property implementation
    public bool isPlayerProjectile { get; set; } = true; // sword beams are always player projectiles

    public SwordBeam(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        Active = true;
        HitboxActive = true;
        this.direction = direction;
        sprite = spriteFactory.CreateSwordBeamSprite(position, direction);

        
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
                positionNew.Y -= 6;
                break;
            case Direction.DOWN:
                positionNew.Y += 6;
                break;
            case Direction.LEFT:
                positionNew.X -= 6;
                break;
            case Direction.RIGHT:
                positionNew.X += 6;
                break;
        }
        Position = positionNew;


        //if (startTime >= endTime)
        //{
        //    // do something to delete arrow
        //    Active = false;
        //}
    }

    public void OnCollision()
    {

        // TODO: make sword beam disappear after collision with enemy or screen boundary.
        // TODO IS DONE. Currently, the sword beam will disappear after 0.5 seconds or after colliding
        Active = false;
        HitboxActive = false;
    }
}
