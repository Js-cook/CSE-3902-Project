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
            int triggerInset = 12;

            if (Direction == 0 || Direction == 2) // top and bottom doors
            {
                width = 126;
                height = 96;
                offsetY += triggerInset;
            }
            else // left and right doors
            {
                width = 80;
                height = 128;
                offsetY = 0;

                if (Direction == 3)
                {
                    offsetX += triggerInset; // Shift right
                }
                else if (Direction == 1)
                {
                    offsetX += triggerInset; // Shift left
                }
            
                
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