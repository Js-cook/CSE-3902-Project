using Enums;
using Microsoft.Xna.Framework;

public class HiddenWallmasterState : IEnemyState
{
    private Wallmaster wallmaster;

    public HiddenWallmasterState(Wallmaster wallmaster)
    {
        this.wallmaster = wallmaster;
    }

    public void Update(GameTime gameTime)
    {
    }

    public void TakeDamage()
    {
    }

    public void BeDead()
    {
    }

    public void OnWallCollision(Direction newDir)
    {
    }

    public void ChangeDirection()
        {
        // No need for this
    }
}