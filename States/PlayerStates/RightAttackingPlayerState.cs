using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class RightAttackingPlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private FactoryStorage factoryStorage;

    private double startClock = 0.0;
    private double animationDuration = 0.2;

    private bool animationDone = false;
    private ProjectileController projectileController;

    public RightAttackingPlayerState(Link player, FactoryStorage factoryStorage, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.factoryStorage = factoryStorage;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }
    public void ChangeDirection(Direction Direction)
    {
        // do nothing - can't change direction while attacking
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
        if (animationDone)
        {
            player.playerState = new RightIdlePlayerState(player, factoryStorage, projectileController, soundEffect);
            player.Sprite = factoryStorage.playerSpriteFactory.CreateRightIdlePlayerSprite(player.position);
        }
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            animationDone = true;
            BeIdle();
        }
    }
}

