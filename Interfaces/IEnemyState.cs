using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEnemyState
{
    void ChangeDirection();
    void BeDead();

    void Update(GameTime gameTime);
}

