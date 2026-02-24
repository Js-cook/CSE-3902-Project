using Microsoft.Xna.Framework;

public class GoriyaAttackState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;
    private string direction;
    public GoriyaAttackState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics, string direction)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        this._graphics = _graphics;
        // The sprite can be set to any direction since the boomerang will be active and the Goriya will be stationary during the attack.
        switch (direction)
        {
            case "left":
                goriya.Sprite = spriteFactory.CreateLeftMovingGoriyaSprite(goriya.position);
                break;
            case "right":
                goriya.Sprite = spriteFactory.CreateRightMovingGoriyaSprite(goriya.position);
                break;
            case "up":
                goriya.Sprite = spriteFactory.CreateUpMovingGoriyaSprite(goriya.position);
                break;
            case "down":
                goriya.Sprite = spriteFactory.CreateDownMovingGoriyaSprite(goriya.position);
                break;
        }
        this.direction = direction;
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
            // Transition back to a moving state based on the previous direction.
            switch (direction)
            {
                case "left":
                    goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "right":
                    goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "up":
                    goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "down":
                    goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
            }
        }
    }
}