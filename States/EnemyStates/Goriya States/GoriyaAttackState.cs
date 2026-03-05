using Enums;
using Microsoft.Xna.Framework;

public class GoriyaAttackState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;
    private Direction direction;
    public GoriyaAttackState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics, Direction direction)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        this._graphics = _graphics;
        SetSpriteByDirection(direction);

        this.direction = direction;
        goriya.goriyaBoomerang.HitboxActive = true;
    }
    public void ChangeDirection()
    {
        // No movement during attack, so no direction change.
    }
    public void BeDead()
    {
        // No need for this
    }
    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        // During the attack state, the Goriya should not move. It should only transition back to a moving state once the boomerang is no longer active.
        if (!goriya.goriyaBoomerang.Active)
        {
            CompleteAttack();
        }
    }

    public void TakeDamage()
    {
        if (goriya.Health > 0)
        {
            goriya.goriyaState = new DamagedGoriyaState(goriya, spriteFactory, _graphics);
        }
        else
        {
            goriya.goriyaState = new DeadGoriyaState(goriya, spriteFactory);
        }
    }

    private void SetSpriteByDirection(Direction direction)
    {
        // The sprite can be set to any direction since the boomerang will be active and the Goriya will be stationary during the attack.
        switch (direction)
        {
            case Direction.LEFT:
                goriya.Sprite = spriteFactory.CreateLeftMovingGoriyaSprite(goriya.position);
                break;
            case Direction.RIGHT:
                goriya.Sprite = spriteFactory.CreateRightMovingGoriyaSprite(goriya.position);
                break;
            case Direction.UP:
                goriya.Sprite = spriteFactory.CreateUpMovingGoriyaSprite(goriya.position);
                break;
            case Direction.DOWN:
                goriya.Sprite = spriteFactory.CreateDownMovingGoriyaSprite(goriya.position);
                break;
        }

    }
    private void CompleteAttack()
    {
        // Once the attack is complete (i.e., the boomerang is no longer active), transition back to the appropriate moving state based on the direction.
        TransitionBackToMovingState();
    }

    private void TransitionBackToMovingState()
    {
        switch (direction)
        {
            case Direction.LEFT:
                goriya.ChangeState(new LeftMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
            case Direction.RIGHT:
                goriya.ChangeState(new RightMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
            case Direction.UP:
                goriya.ChangeState(new UpMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
            case Direction.DOWN:
                goriya.ChangeState(new DownMovingGoriyaState(goriya, spriteFactory, _graphics));
                break;
        }
    }

    public void OnWallCollision()
    {
        // No movement during attack, so no wall collision logic needed.
    }
}