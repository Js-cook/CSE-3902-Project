using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IProjectile
{ 
    bool Active { get; set; }
    void Draw();
    void Update(GameTime gametime);
}

