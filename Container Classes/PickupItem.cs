using Microsoft.Xna.Framework;
using Interfaces;
using Enums;

public class PickupItem : ICollidable
{
    public Vector2 Position { get; set; }
    public ISprite Sprite { get; set; }
    public ItemType ItemType { get; set; }
    public bool HitboxActive { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            // Most Zelda items are 16x16 pixels
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }

    public PickupItem(ISprite sprite, Vector2 position, ItemType itemType)
    {
        Sprite = sprite;
        Position = position;
        ItemType = itemType;
        HitboxActive = true; // Item is active by default
    }

    public void Update(GameTime gameTime)
    {
        if (Sprite != null)
        {
            Sprite.Update(gameTime);
        }
    }

    public void Draw()
    {
        // Only draw if the item is active
        if (HitboxActive && Sprite != null)
        {
            Sprite.SpriteDraw(Position);
        }
    }
}
