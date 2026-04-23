using Enums;
using Microsoft.Xna.Framework;
using System.Threading;

public class DeadAquamentusState : IEnemyState
{
    private Aquamentus aquamentus;
    private AquamentusSpriteFactory spriteFactory;

    public DeadAquamentusState(Aquamentus aquamentus, AquamentusSpriteFactory spriteFactory)
    {
        this.aquamentus = aquamentus;
        this.spriteFactory = spriteFactory;
        aquamentus.isDead = true;
            aquamentus.HitboxActive = false;
            SpawnAquamentusDeathCloud();
    }
    public void ChangeDirection()
    {
        // No need for this 
    }
    public void BeDead()
    {

    }
    public void Update(GameTime gameTime)
    {

    }

    public void TakeDamage()
    {
        // No need for this
    }

    public void OnWallCollision(Direction newDir)
    {
        // No need for this
    }

    private void SpawnAquamentusDeathCloud()
    {
        EffectController.Instance.SpawnDeathCloud(new Vector2(aquamentus.position.X + 5, aquamentus.position.Y + 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(aquamentus.position.X - 5, aquamentus.position.Y + 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(aquamentus.position.X + 5, aquamentus.position.Y - 5));
        EffectController.Instance.SpawnDeathCloud(new Vector2(aquamentus.position.X - 5, aquamentus.position.Y - 5));


    }
}