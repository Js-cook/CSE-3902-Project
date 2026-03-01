using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISprite
{
    public void SpriteDraw(Vector2 position);
    public void Update(GameTime gametime);

}

