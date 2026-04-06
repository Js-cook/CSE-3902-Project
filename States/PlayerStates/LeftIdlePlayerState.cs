using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class LeftIdlePlayerState : AbstractIdlePlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    private AudioController audioController;

    public LeftIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        audioController = new AudioController();
    }

    public override void ChangeDirection(Direction Direction)
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
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
        }
    }
 


    public override void BeAttacking()
    {
        audioController.PlaySoundEffect(soundEffect["SwordSlash"]);

        IProjectile swordBeam = new SwordBeam(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(swordBeam);

        player.playerState = new LeftAttackingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftAttackingPlayerSprite(player.position);
    }

    public override void FireSilverArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(silverArrow);
    }
    public override void FireArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(arrow);
    }
    public override void FireBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(boomerang);
    }
    public override void FireMagicBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(magicBoomerang);
    }
    public override void FireFireball()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(fireball);
    }
    public override void FireBomb()
    {
        audioController.PlaySoundEffect(soundEffect["BombDrop"]);
        player.playerState = new LeftUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.LEFT, player.projectileSpriteFactory);
        projectileController.projectiles.Add(bomb);
    }

    public override void usePrimaryItem()
    {
        switch (player.playerInventory.primaryItem)
        {
            case Weapon.WOOD_SWORD:
                BeAttacking();
                break;
            case Weapon.ARROW:
                FireArrow();
                break;
            case Weapon.SILVER_ARROW:
                FireSilverArrow();
                break;
            case Weapon.BOMB:
                FireBomb();
                break;
            case Weapon.BOOMERANG:
                FireBoomerang();
                break;
            case Weapon.MAGIC_BOOMERANG:
                FireMagicBoomerang();
                break;
        }
    }

    public override void useSecondaryItem()
    {
        switch (player.playerInventory.secondaryItem)
        {
            case Weapon.WOOD_SWORD:
                BeAttacking();
                break;
            case Weapon.ARROW:
                FireArrow();
                break;
            case Weapon.SILVER_ARROW:
                FireSilverArrow();
                break;
            case Weapon.BOMB:
                FireBomb();
                break;
            case Weapon.BOOMERANG:
                FireBoomerang();
                break;
            case Weapon.MAGIC_BOOMERANG:
                FireMagicBoomerang();
                break;
        }
    }
}
