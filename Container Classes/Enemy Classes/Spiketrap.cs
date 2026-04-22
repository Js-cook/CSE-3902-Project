using Microsoft.Xna.Framework;
using System.Diagnostics.CodeAnalysis;

public class Spiketrap
{

    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    public IEnemyState spiketrapState { get; set; }

    public Vector2 OriginalPosition { get; set; }
    public Vector2 TargetPosition { get; set; }
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
        OriginalPosition = startPosition;
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

    public void ChangeState(IEnemyState newState)
    {
        spiketrapState = newState;
    }

    

    // No take damage function
}
