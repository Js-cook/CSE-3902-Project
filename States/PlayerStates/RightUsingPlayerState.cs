using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class RightUsingPlayerState : AbstractUsingPlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private bool animationDone = false;
    private ProjectileController projectileController;

    public RightUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
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
            player.playerState = new RightIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
            player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
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