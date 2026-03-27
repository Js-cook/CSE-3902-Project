using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class UpAttackingPlayerState : AbstractAttackingPlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    private double startClock = 0.0;
    private double animationDuration = 0.2;

    private bool animationDone = false;
    private ProjectileController projectileController;
    
    public UpAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }

    public override void BeDamaged()
    {
        player.Hurt = true;
    }

    public override void BeIdle()
    {
        if (animationDone)
        {
            //animationDone = false;
            player.playerState = new UpIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
            player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
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
