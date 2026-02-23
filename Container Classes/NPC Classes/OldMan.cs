using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OldMan : IEnemy
{
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState oldManState { get; set; }



    public OldMan(OldManSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(60, 30); // arbitrary starting position - change later
        oldManState = new IdleOldManState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateOldManIdleSprite(position);
    }

    public void Update(GameTime gametime)
    {
        oldManState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }
}