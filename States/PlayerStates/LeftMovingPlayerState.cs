using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class LeftMovingPlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private FactoryStorage factoryStorage; // create at start of game and will need a reference to player

    private ProjectileController projectileController;
    public LeftMovingPlayerState(Link player, FactoryStorage factoryStorage, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.factoryStorage = factoryStorage;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }

    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, factoryStorage, projectileController, soundEffect);
                player.Sprite = factoryStorage.playerSpriteFactory.CreateRightMovingPlayerSprite(player.position);
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

    }

    public void BeIdle()
    {
        player.playerState = new LeftIdlePlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateLeftIdlePlayerSprite(player.position);
    }

    public void FireArrow()
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
    public void FireSilverArrow()
    {
    }
    public void FireBomb()
    {
    }
    public void Update(GameTime gametime)
    {
    }
}
