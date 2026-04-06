using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

public class DownAttackingPlayerState : AbstractAttackingPlayer
{
    //public Dictionary<string, SoundEffect> soundEffect { get; set; }
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    private double startClock = 0.0;
    private double animationDuration = 0.2;

    private bool animationDone = false;
    private ProjectileController projectileController;

    public DownAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }
   
    public override void BeIdle()
    {
        if (animationDone)
        {
            player.playerState = new DownIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
            player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
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