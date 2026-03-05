using Enums;
using Microsoft.Xna.Framework;

public class Aquamentus : IEnemy
{

    public int Health { get; set; } = 90;
    public bool isDead { get; set; } = false;



    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState aquamentusState { get; set; }


    public AquamentusFireball topFireball { get; set; }
    public AquamentusFireball middleFireball { get; set; }

    public AquamentusFireball bottomFireball { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }
    }
    public bool HitboxActive { get; set; }





    public Aquamentus(AquamentusSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, BossProjectileSpriteFactory enemyProjectileSpriteFactory, Vector2 startPosition)
    {
        position = startPosition; // arbitrary starting position - change later
        aquamentusState = new MovingAquamentusState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingAquamentusSprite(position);

            topFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, -1));
            middleFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, 0));
            bottomFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, 1));
    }

    public void Update(GameTime gametime)
    {
        aquamentusState.Update(gametime);
        Sprite.Update(gametime);

        // Code block to update each fireball separately, only if they are active
        if (topFireball.Active)
            topFireball.Update(gametime);
        if (middleFireball.Active)
            middleFireball.Update(gametime);
        if (bottomFireball.Active)
            bottomFireball.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);

        // Code block to draw each fireball separately, only if they are active
        if (topFireball.Active)
            topFireball.Draw();
        if (middleFireball.Active)
            middleFireball.Draw();
        if (bottomFireball.Active)
            bottomFireball.Draw();
    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic here, such as reducing health and changing state if health reaches zero
        Health -= damage;

        aquamentusState.TakeDamage();


    }

    public void ChangeState(IEnemyState newState)
    {
        aquamentusState = newState;
    }

    public void OnWallCollision(Direction newDir)
    {
        // Implement logic for what happens when Aquamentus collides with a wall, if necessary
        aquamentusState.OnWallCollision(newDir);
    }

}
