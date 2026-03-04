using Enums;
using Microsoft.Xna.Framework;

public class Bomb : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }
    public bool HitboxActive { get; set; }
    public int DamageValue { get; set; } = 1; public bool Active { get; set; }
    private double startTime = 0.0;
    private double endTime = 0.75;

    ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public Vector2 Position { get; set; }
    public Bomb(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        //this.Position = position;
        switch (direction)
        {
            case Direction.LEFT:
                this.Position = new Vector2(position.X - 20, position.Y);
                break;
            case Direction.RIGHT:
                this.Position = new Vector2(position.X + 20, position.Y);
                break;
            case Direction.DOWN:
                this.Position = new Vector2(position.X, position.Y + 20);
                break;
            case Direction.UP:
                this.Position = new Vector2(position.X, position.Y - 20);
                break;
        }
        this.spriteFactory = spriteFactory;
        this.sprite = spriteFactory.CreateBombSprite(position);
        Active = true;
        HitboxActive = true;
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
            Active = false;
            HitboxActive = false;
        }
    }

    public void OnCollision()
    {
        // do nothing, bomb should not interact with anything
    }
}
