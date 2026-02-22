using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class DownIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    public readonly Direction Direction = Direction.DOWN;

    private ProjectileController projectileController;
    public DownIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController)
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
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, spriteFactory, projectileController);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
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

    public void BeAttacking()
    {
        player.playerState = new DownAttackingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory, projectileController);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.DOWN, player.projectileSpriteFactory);
        projectileController.projectiles.Add(bomb);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {
    }
}
