using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseItem : ISprite
{
    public bool Hurt { get; set; } = false;
    public abstract void Update(GameTime gameTime);
    public abstract void SpriteDraw(Vector2 position);
}
