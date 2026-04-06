
using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class DeadPlayerState : AbstractDyingPlayer
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    private AudioController audioController;

    private float animationTimerMax = 1.5f;
    private float animationTimer = 0f;

    public DeadPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        player.HitboxActive = false; // Disable collision detection for player when in the dead state
        // Use a null-object sprite instead of setting the sprite to null so
        // callers of player.Sprite don't need to guard against null references.
        this.player.Sprite = new Sprites.NullPlayerSprite(player.position);
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
        audioController = new AudioController();
        EffectController.Instance.SpawnDeathCloud(player.position);
        audioController.PlaySoundEffect(soundEffect["PlayerDeath"]);

    }


    public override void Update(GameTime gametime)
    {
        animationTimer += (float)gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationTimerMax)
        {
            animationTimer = animationTimerMax;
        }
    }
}
