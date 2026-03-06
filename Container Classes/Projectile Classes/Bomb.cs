using Enums;
using Microsoft.Xna.Framework;

public class Bomb : IProjectile
{
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }

    }


    public bool isPlayerProjectile { get; set; } = true;

    public bool HitboxActive { get; set; }
    public int DamageValue { get; set; } = 4; public bool Active { get; set; }
    private double startTime = 0.0;
    private double endTime = 0.75;

    private double damageWindow = 0.10; // Time in seconds during which the bomb can deal damage
    private double damageStartTime = 0.0;

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
        
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gameTime)
    {
        startTime += gameTime.ElapsedGameTime.TotalSeconds;
        if (startTime >= endTime)
        {
            DamageWindow(gameTime);
        }

    }

    public void OnCollision()
    {
        // do nothing, bomb should not interact with anything
    }

    private void DamageWindow(GameTime gameTime)
    {
        HitboxActive = true; // Bomb can deal damage during the damage window
        damageStartTime += gameTime.ElapsedGameTime.TotalSeconds;
        if (damageStartTime >= damageWindow)
        {
            HitboxActive = false; // Bomb can no longer deal damage after the damage window has passed
            Active = false; // Bomb should be removed from the game after the damage window has passed
            
        }
    }
}
