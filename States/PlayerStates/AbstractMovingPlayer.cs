using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

public abstract class AbstractMovingPlayer : IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    public abstract void ChangeDirection(Direction direction);
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
    public void Update(GameTime gametime)
    {

    }
}