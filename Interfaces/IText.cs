using Enums;
using Microsoft.Xna.Framework;

public interface IText
{
    string Text { get; set; }
    Color TextColor { get; set; }

    void Update();
    void Draw();
}
