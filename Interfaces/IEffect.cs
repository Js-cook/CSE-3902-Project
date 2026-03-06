using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IEffect
{
    // The position where the effect is playing
    Vector2 Position { get; set; }

    bool IsExpired { get; }

    void Update(GameTime gameTime);

    // Standard render loop
    void Draw();
}