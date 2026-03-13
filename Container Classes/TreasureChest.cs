using Interfaces;
using Microsoft.Xna.Framework;

public class TreasureChest : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public bool HitboxActive { get; set; } = true;
    public bool IsOpened { get; set; } = false;

    public Rectangle Hitbox
    {
        get
        {
            int width = 30;
            int height = 22;
            int offsetX = 12;
            int offsetY = 14;

            return new Rectangle(
                (int)Position.X + offsetX,
                (int)Position.Y + offsetY,
                width,
                height
            );
        }
    }

    public TreasureChest(ISprite sprite, Vector2 position)
    {
        Sprite = sprite;
        Position = position;
    }
}