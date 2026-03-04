using Microsoft.Xna.Framework;

public class Spiketrap //TODO: Trap Interface
{

    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    public IEnemyState spiketrapState { get; set; }
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }
    }
    public bool HitboxActive { get; set; } = true;


    public Spiketrap(SpiketrapSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Vector2 startPosition)
    {
        position = startPosition; // arbitrary starting position - change later
        spiketrapState = (IEnemyState)new MovingSpiketrapState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingSpiketrapSprite(position);
  
}

    public void Update(GameTime gametime)
    {
        spiketrapState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

    // No take damage function
}
