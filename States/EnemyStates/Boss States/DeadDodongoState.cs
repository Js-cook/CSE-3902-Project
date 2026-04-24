using Microsoft.Xna.Framework;

public class DeadDodongoState : IEnemyState
{
    private Dodongo dodongo;
    private DodongoSpriteFactory spriteFactory;
    public DeadDodongoState(Dodongo dodongo, DodongoSpriteFactory spriteFactory)
    {
        this.dodongo = dodongo;
        this.spriteFactory = spriteFactory;
        dodongo.isDead = true;
        dodongo.HitboxActive = false;
        SpawnDodongoDeathCloud();
    }

    public void TakeDamage()
    {
        // Dead, can't take damage
    }

    public void ChangeDirection()
    {
        // Dead, can't change direction
    }

    public void BeDead()
    {
        // Already dead
    }

    public void OnWallCollision(Enums.Direction newDir)
    {
        // Dead, no collision logic needed
    }

    public void Update(GameTime gameTime)
    {
        // Dead, no update needed
    }

    private void SpawnDodongoDeathCloud()
    {
        EffectController.Instance.SpawnDeathCloud(new Vector2(dodongo.position.X + 5, dodongo.position.Y + 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(dodongo.position.X - 5, dodongo.position.Y + 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(dodongo.position.X + 5, dodongo.position.Y - 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(dodongo.position.X - 5, dodongo.position.Y - 5));
    }
}
