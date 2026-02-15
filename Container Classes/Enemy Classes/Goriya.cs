using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class Goriya : IEnemy
{
    public Vector2 position;
    // idk if this should be public
    public IEnemyState goriyaState { get; set; }

    public ISprite Sprite;



    public Goriya(GoriyaSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
        goriyaState = new LeftMovingGoriyaState(this, spriteFactory, _graphics);
       
    }

    public void Update(GameTime gametime)
    {
        goriyaState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }

}