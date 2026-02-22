using Microsoft.Xna.Framework;

public class Skeleton : IEnemy
{

    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState skeletonState { get; set; }



    public Skeleton(SkeletonSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
        skeletonState = new MovingSkeletonState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingSkeletonSprite(position);
    }

    public void Update(GameTime gametime)
    {
        skeletonState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

}
