using Microsoft.Xna.Framework;

public class Wallmaster : IEnemy
{

    public Vector2 position;
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState wallmasterState { get; set; }



    public Wallmaster(WallmasterSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
        wallmasterState = new MovingWallmasterState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingWallmasterSprite(position);
    }

    public void Update(GameTime gametime)
    {
        wallmasterState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

}
