using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public interface IGameState
{
    bool IsDone { get; }
    void LoadContent(ContentManager contentLoader);
    void Update(GameTime gameTime);
    void ResolveKey(KeyboardState keyState);
    void Draw();
}