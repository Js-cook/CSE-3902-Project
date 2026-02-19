using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class UpIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    public readonly Direction Direction = Direction.UP;

    public UpIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
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
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
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
        player.playerState = new UpAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }
    public void FireArrow()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.UP, player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
    }
    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {
    }
}

