using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IProjectile : ICollidable
{ 

    public int DamageValue { get; }
    bool Active { get; set; }
    Vector2 Position { get; set; }
    void Draw();
    void Update(GameTime gametime);

   
    void OnCollision();

    // New flag: indicates projectile type per request
    bool isPlayerProjectile { get; set; }
}

