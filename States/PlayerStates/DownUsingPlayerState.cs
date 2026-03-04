using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class DownUsingPlayerState : Interfaces.IPlayerState
{
    public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private bool animationDone = false;
    private ProjectileController projectileController;
    public DownUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }
    public void ChangeDirection(Direction Direction)
    {
        // do nothing - can't change direction while using item
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
            player.playerState = new DownIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
            player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
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