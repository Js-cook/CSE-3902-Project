using Interfaces;
using Microsoft.Xna.Framework;

public class Doorway : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public int Direction { get; set; }
    public bool HitboxActive { get; set; } = true;
    public bool IsLocked { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            int width = 64;
            int height = 64;

            if (Direction == 0 || Direction == 2)
            {
                width = 96;
                height = 40;
            }
            else
            {
                width = 40;
                height = 96;
            }

            return new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }
    }

    public Doorway(ISprite sprite, Vector2 position, int direction, bool isLocked = false)
    {
        Sprite = sprite;
        Position = position;
        Direction = direction;
        IsLocked = isLocked;
    }
}