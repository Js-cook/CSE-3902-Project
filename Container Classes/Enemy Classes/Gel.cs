using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gel : IEnemy {

    public int Health { get; set; } = 1;
    public bool isDead { get; set; }


       public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 34, 52);
            }
    }   
    public bool HitboxActive { get; set; }
    public Vector2 position {  get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState gelState { get; set; }
    


    public Gel(GelSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Vector2 startPosition)
    {
        position = startPosition; // arbitrary starting position - change later
        gelState = new MovingGelState(this, spriteFactory);
        Sprite = spriteFactory.CreateMovingGelSprite(position);
    }

    public void Update(GameTime gametime)
    {
       
        gelState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        gelState.TakeDamage();
    }

    public void ChangeState(IEnemyState newState)
    {
        gelState = newState;
    }
    public void OnWallCollision(Direction newDir)
    {
        // Implement logic for what happens when Gel collides with a wall, if necessary
        gelState.OnWallCollision(newDir);
    }

    public void DropHearts(int numHearts)
    {
        // Implement logic for dropping hearts when Gel is defeated, if necessary
    }

}
