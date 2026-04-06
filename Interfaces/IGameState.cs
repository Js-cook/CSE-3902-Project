using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Enums;

public interface IGameState
{
    //bool IsDone { get; }
    GameStateSignal Signal { get; set; }

    void LoadContent(ContentManager contentLoader);
    void Update(GameTime gameTime);
    void ResolveKey(KeyboardState keyState);
    void Draw();

    void ResetState();
}