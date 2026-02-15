using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Xna.Framework;
using Sprites;

// TODO: consolidate moving states into one class and idle states into another class
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
        player.playerState = new LeftIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
    }

    public void FireArrow()
    {
    }
    public void FireBoomerang()
    {
    }
    public void FireMagicBoomerang()
    {
    }
    public void FireSilverArrow()
    {
    }
    public void Update(GameTime gametime)
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
    public void BeAttacking()
    {

    }

    public void BeIdle()
    {
        player.playerState = new RightIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
        //player.Sprite = spriteFactory.CreateRightMovingPlayerSprite(player.position);
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
    public void BeIdle()
    {
        player.playerState = new UpIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
        //player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
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

    public void FireArrow()
    {
    }
    public void FireSilverArrow()
    {
    }
    public void BeAttacking()
    {
    }
    public void FireBoomerang()
    {
    }
    public void FireMagicBoomerang()
    {
    }
    public void BeIdle()
    {
        player.playerState = new DownIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
        //player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
    }
}

public class LeftIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    public LeftIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
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

    public void FireSilverArrow()
    {
        IProjectile silverArrow = new SilverArrow(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void BeAttacking()
    {
        player.playerState = new LeftAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftAttackingPlayerSprite(player.position);
    }

    public void FireArrow()
    {
        IProjectile arrow = new Arrow(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        IProjectile boomerang = new Boomerang(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {

    }
}

public class RightIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    public RightIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
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
        Debug.WriteLine("RIGHT IDLE NOT IMPLEMENTED");
        player.playerState = new RightAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        IProjectile silverArrow = new SilverArrow(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        IProjectile arrow = new Arrow(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        IProjectile boomerang = new Boomerang(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {

    }
}

public class UpIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    public readonly string Direction = "up";

    public UpIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
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
            case "up":
                player.playerState = new UpMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateUpMovingPlayerSprite(player.position);
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
        Debug.WriteLine("UP IDLE NOT IMPLEMENTED");
        player.playerState = new UpAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        IProjectile silverArrow = new SilverArrow(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }
    public void FireArrow()
    {
        IProjectile arrow = new Arrow(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        IProjectile boomerang = new Boomerang(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {

    }
}

public class DownIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    public readonly string Direction = "down";

    public DownIdlePlayerState(Link player, PlayerSpriteFactory spriteFactory)
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
            case "down":
                player.playerState = new DownMovingPlayerState(player, spriteFactory);
                player.Sprite = spriteFactory.CreateDownMovingPlayerSprite(player.position);
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
        Debug.WriteLine("DOWN IDLE NOT IMPLEMENTED");
        player.playerState = new DownAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        IProjectile silverArrow = new SilverArrow(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        IProjectile arrow = new Arrow(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        IProjectile boomerang = new Boomerang(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }

    public void BeIdle()
    {

    }

    public void Update(GameTime gametime)
    {

    }
}

public class LeftAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    public LeftAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while attacking
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
    public void BeIdle()
    {
        player.playerState = new LeftIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        Debug.WriteLine("ATTACK STATE UPDATE");
        if (startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}

public class RightAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    public RightAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while attacking
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
    public void BeIdle()
    {
        player.playerState = new RightIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if(startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}

public class UpAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    private double startClock = 0.0;
    private double animationDuration = 0.4;
    public UpAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while attacking
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
    public void BeIdle()
    {
        player.playerState = new UpIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}

public class DownAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    private double startClock = 0.0;
    private double animationDuration = 0.4;
    public DownAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while attacking
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
    public void BeIdle()
    {
        player.playerState = new DownIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}