using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;


public class UpIdlePlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private FactoryStorage factoryStorage;
    public readonly Direction Direction = Direction.UP;
    private ProjectileController projectileController;
    private AudioController audioController;

    public UpIdlePlayerState(Link player, FactoryStorage factoryStorage, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.factoryStorage = factoryStorage;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        this.audioController = new AudioController();
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateUpMovingPlayerSprite(player.position);
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

        IProjectile swordBeam = new SwordBeam(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(swordBeam);

        player.playerState = new UpAttackingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(silverArrow);
    }
    public void FireArrow()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        audioController.PlaySoundEffect(soundEffect["ArrowBoomerang"]);
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        audioController.PlaySoundEffect(soundEffect["BombDrop"]);
        player.playerState = new UpUsingPlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, Direction.UP, player.projectileSpriteFactory);
        projectileController.projectiles.Add(bomb);
    }
    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {
    }
}

