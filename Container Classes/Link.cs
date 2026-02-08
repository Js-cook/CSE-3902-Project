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
    private Vector2 position;
    private ISprite sprite;
    private IPlayerState playerState;

    public Link()
    {
        playerState = new RightIdlePlayerState(this);
    }
    // need a state
    // need an ipsrite


}

