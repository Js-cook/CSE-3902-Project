using Controllers;
using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractWinPlayer : IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }
    public void ChangeDirection(Direction direction)
    {

    }
    public void BeDead()
    {

    }
    public void BeDamaged()
    {

    }
    public void BeAttacking()
    {

    }
    public void BeIdle()
    {

    }
    public void FireArrow()
    {

    }
    public void FireSilverArrow()
    {

    }
    public void FireBoomerang()
    {

    }
    public void FireMagicBoomerang()
    {

    }
    public void FireFireball()
    {

    }

    public void usePrimaryItem()
    {

    }

    public void useSecondaryItem()
    {

    }

    public void FireBomb()
    {

    }
    public abstract void Update(GameTime gametime);
}
