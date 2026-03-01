using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OldManFlame
{

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }
    }
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState oldManFlameState { get; set; }



    public OldManFlame(OldManFlameSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        position = new Vector2(60, 30); // arbitrary starting position - change later
        oldManFlameState = new IdleOldManFlameState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateOldManFlameSprite(position);
    }

    public void Update(GameTime gametime)
    {
        oldManFlameState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }
}