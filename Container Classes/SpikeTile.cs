using Interfaces;
using Microsoft.Xna.Framework;

public class SpikeTile : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public bool HitboxActive { get; set; } = true;

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 64, 64);
        }
    }

    public SpikeTile(ISprite sprite, Vector2 position)
    {
        Sprite = sprite;
        Position = position;
    }
}