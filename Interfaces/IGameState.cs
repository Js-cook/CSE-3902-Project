using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

public interface IGameState
{
    void LoadContent(ContentManager contentLoader);
    void Update(GameTime gameTime);
    void Draw();
}