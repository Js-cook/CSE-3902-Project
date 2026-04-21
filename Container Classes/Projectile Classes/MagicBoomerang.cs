using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MagicBoomerang : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8*3, 8*3);
        }
    }
    public bool HitboxActive { get; set; }

    public bool isPlayerProjectile { get; set; } = true;
    public int DamageValue { get; set; } = 0; 
    public Vector2 Position { get; set; }
    private Link player;
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1.5;
    private bool returning = false;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;
    public MagicBoomerang(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory, Link player)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        this.player = player;
        sprite = spriteFactory.CreateMagicBoomerangSprite(position);
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
        if (!returning)
        {
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
        } else
        {
            positionNew.X = Position.X + (player.position.X - Position.X) * 0.05f;
            positionNew.Y = Position.Y + (player.position.Y - Position.Y) * 0.05f;
        }
        Position = positionNew;

        if (startTime >= (endTime / 2))
        {
            returning = true;
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
        // Come back
        startTime = endTime / 2;
        HitboxActive = false;
    }
}

