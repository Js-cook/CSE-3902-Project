using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IPlayerState
{
    void ChangeDirection();
    void BeDead();
    void BeDamaged();
    void BeAttacking();
    void BeIdle();
    void Update();
    
}
