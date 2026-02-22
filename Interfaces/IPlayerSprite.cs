using Microsoft.Xna.Framework;

namespace Interfaces
{
    public interface IPlayerSprite
    {
        bool Hurt { get; set; }
        public void SpriteDraw(Vector2 position);
        public void Update(GameTime gametime);
    }
}

