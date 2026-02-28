using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bat : IEnemy
{
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState batState { get; set; }






    public Bat(BatSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(60, 30); // arbitrary starting position - change later
        batState = new MovingBatState(this, spriteFactory, _graphics);
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
}