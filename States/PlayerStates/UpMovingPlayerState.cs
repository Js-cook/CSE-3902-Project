using Enums;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    public UpMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(Direction Direction)
    {
        switch (Direction)
        {
            case Direction.DOWN:
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case Direction.LEFT:
                player.playerState = new LeftMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case Direction.RIGHT:
                player.playerState = new RightMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
                break;
        }
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
        player.playerState = new UpIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
    }
}
