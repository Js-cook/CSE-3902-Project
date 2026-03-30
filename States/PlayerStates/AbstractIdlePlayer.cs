using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractIdlePlayer : IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }
    public abstract void ChangeDirection(Direction direction);
    public void BeDead()
    {

    }
    public abstract void BeDamaged();
    public abstract void BeAttacking();
    public void BeIdle()
    {

    }
    public abstract void FireArrow();
    public abstract void FireSilverArrow();
    public abstract void FireBoomerang();
    public abstract void FireMagicBoomerang();
    public abstract void FireFireball();
    public abstract void FireBomb();
    public abstract void usePrimaryItem();
    public abstract void useSecondaryItem();
    public void Update(GameTime gametime)
    {

    }
}