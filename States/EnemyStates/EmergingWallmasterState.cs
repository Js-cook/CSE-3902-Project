using Enums;
using Microsoft.Xna.Framework;
using static WallmasterManager;

public class EmergingWallmasterState : IEnemyState
{
    private Wallmaster wallmaster;
    private WallmasterSpriteFactory spriteFactory;
    private Vector2 velocity;
    private double timerMax = 1.5;
    private double timer;

    public EmergingWallmasterState(Wallmaster wallmaster, WallmasterSpriteFactory spriteFactory)
    {
        this.wallmaster = wallmaster;
        this.spriteFactory = spriteFactory;
        timer = 0;
        SetEmergeVelocity();
    }

    public void ChangeDirection()
    {
        // No need for this
    }
    private void SetEmergeVelocity()
    {
        float speed = 1.0f;
        switch (wallmaster.SpawnWall)
        {
            case WallDirection.North:
                velocity = new Vector2(0, speed);
                break;
            case WallDirection.South:
                velocity = new Vector2(0, -speed);
                break;
            case WallDirection.East:
                velocity = new Vector2(-speed, 0);
                break;
            case WallDirection.West:
                velocity = new Vector2(speed, 0);
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
            wallmaster.ChangeState(new RetreatingWallmasterState(wallmaster, spriteFactory));
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
    }
}