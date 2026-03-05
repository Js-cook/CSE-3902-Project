using Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEnemyState
{
    void TakeDamage();
    void ChangeDirection();
    void BeDead();

    void OnWallCollision(Direction newDir);


    void Update(GameTime gameTime);

}

