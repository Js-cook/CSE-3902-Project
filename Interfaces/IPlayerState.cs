using Microsoft.Xna.Framework;
using System;
using Enums;

namespace Interfaces
{
    public interface IPlayerState
    {
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
