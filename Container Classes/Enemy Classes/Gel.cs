using Interfaces;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gel {

    public Vector2 position;
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState gelState { get; set; }
    


    public Gel(GelSpriteFactory spriteFactory)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
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

}
