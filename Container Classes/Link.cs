using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Link
{
    public Vector2 position { get; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IPlayerState playerState { get; set; }
    

    public Link()
    {
        playerState = new RightIdlePlayerState(this);
    }
    // need a state
    // need an ipsrite


}

