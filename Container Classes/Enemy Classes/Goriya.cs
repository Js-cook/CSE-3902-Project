using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Microsoft.Xna.Framework;

public class Goriya : IEnemy
{
        public Rectangle Hitbox
            {
                get
                {
                    return new Rectangle((int)position.X, (int)position.Y, 16, 16);
                }
    }
    public bool HitboxActive { get; set; }
    public int Health { get; set; } = 2;
    public bool isDead { get; set; }

    public Vector2 position { get; set; }
    // idk if this should be public
    public IEnemyState goriyaState { get; set; }

    public ISprite Sprite;

    public GoriyaBoomerang goriyaBoomerang;





    public Goriya(GoriyaSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, EnemyProjectileSpriteFactory enemyProjectileSpriteFactory, Vector2 startPosition)
    {
        position = startPosition; // arbitrary starting position - change later
        goriyaState = new LeftMovingGoriyaState(this, spriteFactory, _graphics);

        // Give Goriya a boomerang to throw
        goriyaBoomerang = new GoriyaBoomerang(this.position, Direction.LEFT, enemyProjectileSpriteFactory);
        HitboxActive = false;


    }

    public void Update(GameTime gametime)
    {
        goriyaState.Update(gametime);
        Sprite.Update(gametime);
        if (goriyaBoomerang.Active)
            goriyaBoomerang.Update(gametime);


    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
        if (goriyaBoomerang.Active)
            goriyaBoomerang.Draw();
       

    }

    public void TakeDamage(int damage)
    {
        if ((goriyaState is not DamagedGoriyaState))
        {
            Health -= damage;
        }

        goriyaState.TakeDamage();
    }

    public void ChangeState(IEnemyState newState)
    {
        goriyaState = newState;
    }

    public void OnWallCollision(Direction newDir)
    {
        // Implement logic for what happens when Goriya collides with a wall, if necessary
        goriyaState.OnWallCollision(newDir);
    }

}