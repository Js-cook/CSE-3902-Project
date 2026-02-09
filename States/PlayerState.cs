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
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                //player.Sprite = UpMovingPlayerSprite()
                break;
            case "down":
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case "right":
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
    private PlayerSpriteFactory spriteFactory;

    public RightMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        switch(Direction)
        {
            case "up":
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case "down":
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case "left":
                player.playerState = new LeftMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
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

public class UpMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    public UpMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        switch (Direction) 
        { 
            case "down":
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
                break;
            case "left":
                player.playerState = new LeftMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case "right":
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
    private PlayerSpriteFactory spriteFactory;

    public DownMovingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }

    public void ChangeDirection(String Direction)
    {
        switch (Direction)
        {
            case "up":
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
                break;
            case "left":
                player.playerState = new LeftMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateLeftMovingPlayerSprite(player.position);
                break;
            case "right":
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