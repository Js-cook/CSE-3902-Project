using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISprite
{
    bool Hurt { get; set; }
    public void SpriteDraw(Vector2 position);
    public void Update(GameTime gametime);
}

