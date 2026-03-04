using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class RightIdlePlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    private AudioController audioController;
    public RightIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        audioController = new AudioController();
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
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
        audioController.PlaySoundEffect(soundEffect["SwordSlash"]);

        IProjectile swordBeam = new SwordBeam(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(swordBeam);

        player.playerState = new RightAttackingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        audioController.PlaySoundEffect(soundEffect["BombDrop"]);
        player.playerState = new RightUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.RIGHT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(bomb);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {
    }
}
