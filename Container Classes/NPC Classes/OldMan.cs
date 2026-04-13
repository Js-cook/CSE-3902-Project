using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OldMan : IEnemy
{
    public int Health { get; set; } = 999;
    public bool isDead { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }
    }

    public bool HitboxActive { get; set; }
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    public IEnemyState oldManState { get; set; }

    public OldMan(OldManSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Vector2 startPosition)
    {
        position = startPosition;
        oldManState = new IdleOldManState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateOldManIdleSprite(position);
        HitboxActive = false;
    }

    public void Update(GameTime gametime)
    {
        oldManState.Update(gametime);
        // Don't update sprite animation - keep him static
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

    public void TakeDamage(int damage)
    {
    }

    public void ChangeState(IEnemyState newState)
    {
        oldManState = newState;
    }

    public void OnWallCollision(Direction newDir)
    {
    }

    public void DropHearts(int numHearts)
    {
    }
}
