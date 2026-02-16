using Microsoft.Xna.Framework;

public class Aquamentus : IEnemy
{

    public Vector2 position;
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState aquamentusState { get; set; }



    public Aquamentus(AquamentusSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(80, 70); // arbitrary starting position - change later
        aquamentusState = new MovingAquamentusState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingAquamentusSprite(position);
    }

    public void Update(GameTime gametime)
    {
        aquamentusState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

}
