using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Sprites;
using System.Collections.Generic;

public class LeftMovingPlayerState : AbstractMovingPlayer
{

    private Link player;
    private PlayerSpriteFactory spriteFactory; // create at start of game and will need a reference to player

    private ProjectileController projectileController;
    public LeftMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
        this.projectileController = projectileController;
        this.soundEffect = soundEffect;
    }

    public override void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.UP:
                player.playerState = new UpMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
        }
    }

    public override void BeDamaged()
    {
        player.Hurt = true;
    }

    public override void BeIdle()
    {
        player.playerState = new LeftIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
    }
}
