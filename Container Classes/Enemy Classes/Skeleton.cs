using Enums;
using Microsoft.Xna.Framework;

public class Skeleton : IEnemy
{

    public Vector2 position { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 65, 65);
        }
    }
    public bool HitboxActive { get; set; }
    public int Health { get; set; } = 2;
    public bool isDead { get; set; }

    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState skeletonState { get; set; }



    public Skeleton(SkeletonSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Vector2 startPosition)
    {
        position = startPosition; // arbitrary starting position - change later
        skeletonState = new MovingSkeletonState(this, spriteFactory);
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        skeletonState.TakeDamage();
    }

    public void ChangeState(IEnemyState newState)
    {
        skeletonState = newState;
    }

    public void OnWallCollision(Direction newDir)
    {
        // Implement logic for what happens when Skeleton collides with a wall, if necessary
        skeletonState.OnWallCollision(newDir);
    }

    public void DropHearts (int numHearts)
    {
        // Implement logic for dropping hearts when Skeleton is defeated, if necessary
    }

}
