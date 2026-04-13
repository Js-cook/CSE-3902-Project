using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

public class UpIdlePlayerState : AbstractIdlePlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    public readonly Direction Direction = Direction.UP;
    private ProjectileController projectileController;
    private AudioController audioController;

    public UpIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        this.audioController = new AudioController();

        this.player.currDirection = Direction.UP;

    }

    public override void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
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
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
        }
    }

    public override void BeAttacking()
    {
        audioController.PlaySoundEffect(soundEffect["SwordSlash"]);

        if(player.playerInventory.currentHearts == 2 * player.playerInventory.maxHearts)
        {
            IProjectile swordBeam = new SwordBeam(player.position, Direction.UP, player.projectileSpriteFactory);
            projectileController.projectiles.Add(swordBeam);
        }

        player.playerState = new UpAttackingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpAttackingPlayerSprite(player.position);
    }

    public override void FireSilverArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(silverArrow);
    }
    public override void FireArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(arrow);
    }
    public override void FireBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(boomerang);
    }
    public override void FireMagicBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(magicBoomerang);
    }
    public override void FireFireball()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(fireball);
    }
    public override void FireBomb()
    {
        audioController.PlaySoundEffect(soundEffect["BombDrop"]);
        player.playerState = new UpUsingPlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.UP, player.projectileSpriteFactory);
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
        if(player.playerInventory.calculateNumberOfSecondaryItems() > 0)
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
            player.playerInventory.useSecondaryItem();
        }
    }
}

