using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal interface IEnvironment
{
    Vector2 Position { get; set; }
    void Update();

    void Draw(SpriteBatch spriteBatch);
}
