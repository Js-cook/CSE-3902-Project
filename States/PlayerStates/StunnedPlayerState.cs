using Controllers;
using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class StunnedPlayerState : AbstractStunnedPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;

    private Direction currDirection;

    private float stunnedTimerMax = Settings.Instance.PlayerStunnedTime; // Duration of stunned state in seconds
    private float stunnedTimer; // Timer to track stunned duration

    public StunnedPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect, Direction currDirection)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.player.Sprite = spriteFactory.CreateStunnedPlayerSprite(player.position, player.Sprite); // Set the sprite based on the current direction when entering the stunned state
        this.currDirection = currDirection;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
  

        stunnedTimer = stunnedTimerMax; // Start the timer when entering the stunned state

    }



    public override void Update(GameTime gameTime)
    {
        // Decrease the stunned timer
        stunnedTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        // Check if the stunned duration has elapsed
        if (stunnedTimer <= 0f)
        {
            stunnedTimer = stunnedTimerMax;
            // Transition back to the appropriate idle state based on the current direction
            switch (currDirection)
            {
                case Direction.UP:
                    player.playerState = new UpIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
                    player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
                    break;
                case Direction.DOWN:
                    player.playerState = new DownIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
                    player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
                    break;
                case Direction.LEFT:
                    player.playerState = new LeftIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
                    player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
                    break;
                case Direction.RIGHT:
                    player.playerState = new RightIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
                    player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
                    break;
            }
        }
    }
}
