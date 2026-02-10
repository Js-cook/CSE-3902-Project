using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPlayerState
    {
        void ChangeDirection(String Direction);
        void BeDead();
        void BeDamaged();
        void BeAttacking();
        void BeIdle();
        void Update(GameTime gametime);
    
    }
}
