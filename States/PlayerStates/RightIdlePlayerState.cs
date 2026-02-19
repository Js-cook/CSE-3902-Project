using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class RightIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    public RightIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory);
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

    public void BeAttacking()
    {
        player.playerState = new RightAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {
    }
}
