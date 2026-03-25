using Controllers;
using Enums;
using Microsoft.Xna.Framework;
using Sprites;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

public class DownMovingPlayerState : AbstractMovingPlayer
{
    //public Dictionary<string, SoundEffect> soundEffect { get; set; }

    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private ProjectileController projectileController;
    public DownMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
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
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory, projectileController, soundEffect);
                player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
        }
    }

    //public void BeDead()
    //{

    //}

    public override void BeDamaged()
    {
        player.Hurt = true;
    }

    //public void FireArrow()
    //{
    //}
    //public void FireSilverArrow()
    //{
    //}
    //public void BeAttacking()
    //{
    //}
    //public void FireBoomerang()
    //{
    //}
    //public void FireMagicBoomerang()
    //{
    //}
    //public void FireFireball()
    //{
    //}
    //public void FireBomb()
    //{
    //}
    public override void BeIdle()
    {
        player.playerState = new DownIdlePlayerState(player, spriteFactory, projectileController, soundEffect);
        player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
    }

    //public void Update(GameTime gametime)
    //{
    //}
}