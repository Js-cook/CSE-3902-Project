using Microsoft.Xna.Framework;

public class Spiketrap : IEnemy
{

    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState spiketrapState { get; set; }



    public Spiketrap(SpiketrapSprite spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
        spiketrapState = new MovingSpiketrapState(this, spriteFactory, _graphics);
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

}
