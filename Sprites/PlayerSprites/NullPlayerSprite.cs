using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;

namespace Sprites
{
    // A Null Object implementation of IPlayerSprite that performs no drawing or updating
    // but preserves Width/Height contracts to avoid NullReferenceExceptions.
    public class NullPlayerSprite : IPlayerSprite
    {
        private Rectangle frame = new Rectangle(0, 0, 16, 16);
        public bool Hurt { get; set; }
        public int Width => frame.Width;
        public int Height => frame.Height;

        public NullPlayerSprite(Vector2 position)
        {
            // position parameter kept for factory compatibility; no-op
        }

        public void SpriteDraw(Vector2 position)
        {
            // intentionally empty - nothing to draw
        }

        public void Update(GameTime gametime)
        {
            // intentionally empty - nothing to update
        }
    }
}
