using Enums;
using Microsoft.Xna.Framework;

public class DamagedDodongoState : IEnemyState
{
    private Dodongo dodongo;
    private DodongoSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;

    private double damageStateDuration = 2.0; // Duration to show damaged state in seconds (increased for stationary behavior)
    private double damageStateTimer = 0;
    private Direction damageDirection;

    public DamagedDodongoState(Dodongo dodongo, DodongoSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, Direction direction)
    {
        this.dodongo = dodongo;
        this.spriteFactory = spriteFactory;
        this._graphics = _graphics;
        this.damageDirection = direction;

        // Change sprite to damaged sprite
        dodongo.Sprite = spriteFactory.CreateDamagedDodongoSprite(dodongo.position, direction);
        damageStateTimer = 0;
    }

    public void TakeDamage()
    {
        // Already in damaged state, just reset the timer
        damageStateTimer = 0;
    }

    public void ChangeDirection()
    {
        // No direction changes while damaged
    }

    public void BeDead()
    {
        // No need for this
    }

    public void OnWallCollision(Direction newDir)
    {
        // No movement while damaged, so no wall collision logic needed
    }

    public void Update(GameTime gameTime)
    {
        damageStateTimer += gameTime.ElapsedGameTime.TotalSeconds;

        if (damageStateTimer >= damageStateDuration)
        {
            // Check if Dodongo is dead before returning to moving state
            if (dodongo.Health <= 0)
            {
                dodongo.ChangeState(new DeadDodongoState(dodongo, spriteFactory));
            }
            else
            {
                // Return to moving state
                dodongo.ChangeState(new MovingDodongoState(dodongo, spriteFactory, _graphics));
            }
        }
    }
}
