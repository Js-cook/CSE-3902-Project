using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class LeftAttackingPlayerState : AbstractAttackingPlayer
{

    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.2;

    private bool animationDone;
    private ProjectileController projectileController;
    public LeftAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;

        this.player.currDirection = Direction.LEFT;

    }


    public override void BeIdle()
    {
        if (animationDone)
        {
            player.playerState = new LeftIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
            player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
        }
    }
    public override void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            animationDone = true;
            BeIdle();
        }
    }
}

