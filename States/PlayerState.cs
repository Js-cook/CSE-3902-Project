using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Sprites;


public class LeftMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory; // create at start of game and will need a reference to player

    public LeftMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }

    public void ChangeDirection(String Direction)
    {
        switch (Direction)
        {
            case "up":
                player.playerState = new UpMovingPlayerState(player);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                //player.Sprite = UpMovingPlayerSprite()
                break;
            case "down":
                player.playerState = new DownMovingPlayerState(player);
                break;
            case "right":
                player.playerState = new RightMovingPlayerState(player);
                break;
        }
    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class RightMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;

    public RightMovingPlayerState(Link player)
    {
        this.player = player;
    }
    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class UpMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;

    public UpMovingPlayerState(Link player)
    {
        this.player = player;
    }
    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class DownMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;

    public DownMovingPlayerState(Link player)
    {
        this.player = player;
    }

    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class LeftIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;

    public LeftIdlePlayerState(Link player)
    {
        this.player = player;
    }

    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class RightIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;

    public RightIdlePlayerState(Link player)
    {
        this.player = player;
    }

    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class UpIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;

    public UpIdlePlayerState(Link player)
    {
        this.player = player;
    }

    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}

public class DownIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;

    public DownIdlePlayerState(Link player)
    {
        this.player = player;
    }

    public void ChangeDirection(String Direction)
    {

    }

    public void BeDead()
    {

    }

    public void BeDamaged()
    {

    }

    public void BeAttacking()
    {

    }

    public void BeIdle()
    {

    }

    public void Update()
    {

    }
}