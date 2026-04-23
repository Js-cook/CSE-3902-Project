using Interfaces;
using Microsoft.Xna.Framework;
using System;
using Enums;

public class TreasureChest : ICollidable
{
    private static readonly Random random = new Random();

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

    public ItemType? OpenAndGetRandomDrop()
    {
        if (IsOpened)
        {
            return null;
        }

        IsOpened = true;

        return GetRandomDrop();
    }

    private ItemType GetRandomDrop()
    {
        int roll = random.Next(4);

        if (roll == 0)
        {
            return ItemType.Heart;
        }
        if (roll == 1)
        {
            return ItemType.Rupee;
        }
        if (roll == 2)
        {
            return ItemType.Bomb;
        }

        return ItemType.Key;
    }
}