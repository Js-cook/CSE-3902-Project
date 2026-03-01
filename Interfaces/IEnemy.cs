using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEnemy : ICollidable
{
    public Vector2 position {  get; set; }
    public bool isDead => false;
    public void Update(GameTime gameTime);

    public void Draw();

   
}
