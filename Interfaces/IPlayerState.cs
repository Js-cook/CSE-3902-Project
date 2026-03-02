using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPlayerState
    {
        Dictionary<string, SoundEffect> soundEffect { get; set; }

        void ChangeDirection(Direction direction);
        void BeDead();
        void BeDamaged();
        void BeAttacking();
        void BeIdle();
        void FireArrow();
        void FireSilverArrow();
        void FireBoomerang();
        void FireMagicBoomerang();
        void FireFireball();
        void FireBomb();
        void Update(GameTime gametime);
    
    }
}
