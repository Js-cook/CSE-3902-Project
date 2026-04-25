using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    return new Rectangle((int)position.X, (int)position.Y, 60, 60);
                }
    }
    public bool HitboxActive { get; set; }
    public int Health { get; set; } = 3;
    public bool isDead { get; set; }

    public Vector2 position { get; set; }
    // idk if this should be public
    public IEnemyState goriyaState { get; set; }

    // Track the current direction for knockback recovery
    public Direction currentDirection { get; set; } = Direction.LEFT;

    public ISprite Sprite;

    public GoriyaBoomerang goriyaBoomerang;

    private GoriyaSpriteFactory spriteFactory;
    private GraphicsDeviceManager graphicsDevice;

    public Goriya(GoriyaSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, EnemyProjectileSpriteFactory enemyProjectileSpriteFactory, Vector2 startPosition)
    {
        this.spriteFactory = spriteFactory;
        this.graphicsDevice = _graphics;

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
        if ((goriyaState is DamagedGoriyaState) || (goriyaState is KnockedBackGoriyaState))
        {
            return; // If already in damaged or knockback state, ignore additional damage
        }

        else
        {
            Health -= damage;
            goriyaState.TakeDamage();
        }

    }

    public void TakeKnockback(Direction knockbackDirection)
    {
        // Apply knockback regardless of current state (except if already knocked back or dead)
        if (!(goriyaState is KnockedBackGoriyaState) && !(goriyaState is DeadGoriyaState))
        {
            goriyaState = new KnockedBackGoriyaState(this, spriteFactory, graphicsDevice, knockbackDirection, currentDirection);
        }
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

    public void DropHearts(int numHearts)
    {
        // Implement logic for dropping hearts when Goriya is defeated, if necessary
    }

}