using Enums;
using Microsoft.Xna.Framework;
using static WallmasterManager;

public class RetreatingWallmasterState : IEnemyState
{
    private Wallmaster wallmaster;
    private WallmasterSpriteFactory spriteFactory;
    private Vector2 velocity;
    private double timerMax = 1.5; // Matches the emerge timer to return to exact start point
    private double timer;

    public RetreatingWallmasterState(Wallmaster wallmaster, WallmasterSpriteFactory spriteFactory)
    {
        this.wallmaster = wallmaster;
        this.spriteFactory = spriteFactory;
        timer = 0;
        SetRetreatVelocity();
    }

    public void ChangeDirection()
    {
        // No need for this
    }
    private void SetRetreatVelocity()
    {
        float speed = 1.0f;

        // Retreating is the exact opposite direction of emerging
        switch (wallmaster.SpawnWall)
        {
            case WallDirection.North:
                velocity = new Vector2(0, -speed); // Move back Up
                break;
            case WallDirection.South:
                velocity = new Vector2(0, speed);  // Move back Down
                break;
            case WallDirection.East:
                velocity = new Vector2(speed, 0);  // Move back Right
                break;
            case WallDirection.West:
                velocity = new Vector2(-speed, 0); // Move back Left
                break;
            default:
                velocity = Vector2.Zero;
                break;
        }
    }

    public void Update(GameTime gameTime)
    {
        wallmaster.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;

        if (timer >= timerMax)
        {
            // If it dragged the player into the wall, trigger your dungeon reset logic here
            if (wallmaster.IsCarryingPlayer)
            {
                // TriggerPlayerTeleport();
            }

            // Tell the WallmasterManager to put this hand back in the hidden pool
            wallmaster.HitboxActive = false;

            // Reset the hand's state to idle/patrolling for the next time it gets spawned
            wallmaster.ChangeState(new HiddenWallmasterState(wallmaster));
        }
    }

    public void TakeDamage()
    {
        if (wallmaster.Health <= 0)
        {
            wallmaster.ChangeState(new DeadWallmasterState(wallmaster, spriteFactory));
        }
    }

    public void BeDead()
    {
    }

    public void OnWallCollision(Direction newDir)
    {
        // Wallmasters ignore room collisions because they live in the walls
    }
}