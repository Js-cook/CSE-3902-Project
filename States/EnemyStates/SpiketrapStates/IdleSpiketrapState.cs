using Microsoft.Xna.Framework;
using System;

public class IdleSpiketrapState : ISpiketrapState
{
    private SpikeTile _trap;
    private float _alignmentTolerance = 16f; // Adjust this to match your sprite's width/height

    public IdleSpiketrapState(SpikeTile trap)
    {
        _trap = trap;
    }

    public void Update(GameTime gameTime)
    {
        Vector2 playerPos = _trap.TargetPlayer.position;

        // Check if player is in the same column or row
        bool alignedX = Math.Abs(playerPos.X - _trap.Position.X) < _alignmentTolerance;
        bool alignedY = Math.Abs(playerPos.Y - _trap.Position.Y) < _alignmentTolerance;

        Vector2 attackDirection = Vector2.Zero;

        if (alignedX)
        {
            // Player is vertically aligned: attack up or down
            attackDirection = playerPos.Y < _trap.Position.Y ? new Vector2(0, -1) : new Vector2(0, 1);
        }
        else if (alignedY)
        {
            // Player is horizontally aligned: attack left or right
            attackDirection = playerPos.X < _trap.Position.X ? new Vector2(-1, 0) : new Vector2(1, 0);
        }

        // If aligned, fire off the trap
        if (attackDirection != Vector2.Zero)
        {
            _trap.ChangeState(new AttackSpiketrapState(_trap, attackDirection));
        }
    }

    public void OnWallCollision()
    {
        // Idle state doesn't need to handle wall collisions
    }
}