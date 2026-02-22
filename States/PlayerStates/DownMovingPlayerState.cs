using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class DownMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    public DownMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory, projectileController);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory, projectileController);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory, projectileController);
                player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
        }
    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {
        player.Hurt = true;
    }

    public void FireArrow()
    {
    }
    public void FireSilverArrow()
    {
    }
    public void BeAttacking()
    {
    }
    public void FireBoomerang()
    {
    }
    public void FireMagicBoomerang()
    {
    }
    public void FireFireball()
    {
    }
    public void FireBomb()
    {
    }
    public void BeIdle()
    {
        player.playerState = new DownIdlePlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
    }
}