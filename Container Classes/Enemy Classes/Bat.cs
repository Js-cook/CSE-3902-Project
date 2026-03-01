using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bat : IEnemy
{

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }
    }
    public int Health { get; set; } 
    public bool isDead { get; set; } = false;
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState batState { get; set; }

    private BatSpriteFactory spriteFactory;








    public Bat(BatSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(60, 30); // arbitrary starting position - change later
        batState = new MovingBatState(this, spriteFactory, _graphics);
        this.spriteFactory = spriteFactory;
        Sprite = spriteFactory.CreateBatMovingSprite(position);
    }

    public void Update(GameTime gametime)
    {
        batState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

    public void TakeDamage(int damage)
    {

        Health -= damage;
        batState = new DeadBatState(this, spriteFactory);
    }
}