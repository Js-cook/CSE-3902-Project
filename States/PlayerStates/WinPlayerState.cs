
using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class WinPlayerState : AbstractWinPlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    private AudioController audioController;

    private float animationTimerMax = 1f;
    private float animationTimer = 0f;
    public bool animationDone { get; private set; } = false;

    public WinPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.player.Sprite = spriteFactory.CreateWinPlayerSprite(player.position);
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        audioController = new AudioController();
        audioController.StopSong();
        audioController.PlaySoundEffect(soundEffect["WinSoundEffect"]);

    }


    public override void Update(GameTime gametime)
    {
        animationTimer += (float)gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationTimerMax)
        {
            animationDone = true;
            animationTimer = 0f;
        }
    }
}
