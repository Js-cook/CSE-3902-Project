using Microsoft.Xna.Framework;

namespace Interfaces
{
    public interface IPlayerSprite
    {
        bool Hurt { get; set; }
        public void SpriteDraw(Vector2 position);

        int Width { get; }
        int Height { get; }
        public void Update(GameTime gametime);
    }
}

