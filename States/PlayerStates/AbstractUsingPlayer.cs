using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

public abstract class AbstractUsingPlayer : IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }
    public void ChangeDirection(Direction direction)
    {

    }
    public void BeDead()
    {

    }
    public abstract void BeDamaged();
    public void BeAttacking()
    {

    }
    public abstract void BeIdle();
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
    public void FireBomb()
    {

    }
    public void usePrimaryItem()
    {

    }
    public void useSecondaryItem()
    {

    }
    public abstract void Update(GameTime gametime);
}