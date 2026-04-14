using Interfaces;
using Microsoft.Xna.Framework;

public class Doorway : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public int Direction { get; set; }
    public bool HitboxActive { get; set; } = true;
    public bool IsLocked { get; set; }
    public bool IsBombedWall { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            int width = 64;
            int height = 64;

            int offsetX = 0;
            int offsetY = 0;

            if (Direction == 0 || Direction == 2) // top and bottom doors
            {
                width = 126;
                height = 96;
            }
            else // left and right doors
            {
                width = 96;
                height = 126;


                if (Direction == 3)
                {
                    offsetX = 10; // Shift right
                }
                else if (Direction == 1)
                {
                    offsetX = -10; // Shift left
                }
            
                offsetY = -30;
            }

            return new Rectangle((int)Position.X + offsetX, (int)Position.Y + offsetY, width, height);
        }
    }

    public Doorway(ISprite sprite, Vector2 position, int direction, bool isLocked = false, bool isBombedWall = false)
    {
        Sprite = sprite;
        Position = position;
        Direction = direction;
        IsLocked = isLocked;
        IsBombedWall = isBombedWall;
    }
}