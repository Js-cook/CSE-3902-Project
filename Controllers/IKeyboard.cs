using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Controllers
{
    public class IKeyboard : Interfaces.IController
    {
        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            // TODO: restructure to avoid all the ifs
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                // link go up
            }

            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                // link go up
            }

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                // link go up
            }

            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                // link go up
            }
        }
    }
}
