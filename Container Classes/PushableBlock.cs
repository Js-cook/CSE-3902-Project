using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;

public class PushableBlock : ICollidable
{
    private ISprite sprite;
    public Vector2 Position { get; set; }
    public bool HitboxActive { get; set; } = true;
    public bool HasBeenPushed { get; private set; } = false;

    private HashSet<int> allowedDirections;

    private const int tileSize = 32 * 2;

    // Event triggered when block is successfully pushed
    public event Action BlockPushed;

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, tileSize, tileSize);
        }
    }

    public PushableBlock(ISprite sprite, Vector2 position, HashSet<int> allowedDirections = null)
    {
        this.sprite = sprite;
        Position = position;
        this.allowedDirections = allowedDirections ?? new HashSet<int> { 0, 1, 2, 3 };
    }

    public void Draw()
    {
        sprite?.SpriteDraw(Position);
    }
    public bool TryPush(int direction)
    {
        if (HasBeenPushed)
            return false;
        if (!allowedDirections.Contains(direction))
            return false;

        Vector2 nextPosition = direction switch
        {
            0 => Position + Vector2.UnitY * -tileSize,  // Up
            1 => Position + Vector2.UnitX * tileSize,   // Right
            2 => Position + Vector2.UnitY * tileSize,   // Down
            3 => Position + Vector2.UnitX * -tileSize,  // Left
            _ => Position
        };
        Position = nextPosition;
        HasBeenPushed = true;

        // Trigger the event when block is pushed
        Console.WriteLine("=== BLOCK PUSHED! FIRING EVENT ===");
        System.Diagnostics.Debug.WriteLine("*** BLOCK PUSHED - FIRING EVENT");
        BlockPushed?.Invoke();
        Console.WriteLine($"=== BlockPushed event has {BlockPushed?.GetInvocationList().Length ?? 0} subscribers ===");

        return true;
    }

    public static int GetDirectionFromPositions(Rectangle fromHitbox, Rectangle toHitbox)
    {
        int centerDiffX = toHitbox.Center.X - fromHitbox.Center.X;
        int centerDiffY = toHitbox.Center.Y - fromHitbox.Center.Y;

        if (System.Math.Abs(centerDiffX) > System.Math.Abs(centerDiffY))
        {
            return centerDiffX > 0 ? 1 : 3; // 1=Right and 3=Left
        }
        else
        {
            return centerDiffY > 0 ? 2 : 0; // 2=Down and 0=Up
        }
    }
}
