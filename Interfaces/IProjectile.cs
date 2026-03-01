using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IProjectile : ICollidable
{ 

    bool Active { get; set; }
    Vector2 Position { get; set; }
    void Draw();
    void Update(GameTime gametime);
}

