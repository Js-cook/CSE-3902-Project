using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEnemy : ICollidable
{
    public int Health { get; set; }
    public Vector2 position {  get; set; }
    public bool isDead { get; set; }
    public void Update(GameTime gameTime);

    public void Draw();

    public void TakeDamage(int damage);

   
}
