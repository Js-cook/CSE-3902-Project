using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpMovingPlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private FactoryStorage factoryStorage;
    private ProjectileController projectileController;

    public UpMovingPlayerState(Link player, FactoryStorage factoryStorage, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.factoryStorage= factoryStorage;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
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
    public void FireArrow()
    {
    }
    public void FireSilverArrow()
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
        player.playerState = new UpIdlePlayerState(player, factoryStorage, projectileController, soundEffect);
        player.Sprite = factoryStorage.playerSpriteFactory.CreateUpIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
    }
}
