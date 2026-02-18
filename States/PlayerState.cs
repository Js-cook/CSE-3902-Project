using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
        player.Hurt = true;
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
    public void FireFireball()
    {
    }
    public void FireSilverArrow()
    {
    }
    public void FireBomb()
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
        player.Hurt = true;
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
    }
}

public class UpMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startTime = 0.0;
    private double endTime = 2.5;

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

public class DownMovingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startTime = 0.0;
    private double endTime = 2.5;

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
        player.Hurt = true;
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
    public void FireFireball()
    {
    }
    public void FireBomb()
    {
    }
    public void BeIdle()
    {
        player.playerState = new DownIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
    }
}

public class LeftIdlePlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startTime = 0.0;
    private double endTime = 2.5;

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
        player.Hurt = true;
    }


    public void BeAttacking()
    {
        player.playerState = new LeftAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }
    public void FireArrow()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new LeftUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, "left", player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
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

    private double startTime = 0.0;
    private double endTime = 2.5;

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
        player.Hurt = true;
    }

    public void BeAttacking()
    {
        Debug.WriteLine("RIGHT IDLE NOT IMPLEMENTED");
        player.playerState = new RightAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new RightUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, "right", player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
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

    private double startTime = 0.0;
    private double endTime = 2.5;

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
        player.Hurt = true;
    }

    public void BeAttacking()
    {
        Debug.WriteLine("UP IDLE NOT IMPLEMENTED");
        player.playerState = new UpAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }
    public void FireArrow()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }
    public void FireBoomerang()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new UpUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateUpUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, "up", player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
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

    private double startTime = 0.0;
    private double endTime = 2.5;

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
        player.Hurt = true;
    }

    public void BeAttacking()
    {
        Debug.WriteLine("DOWN IDLE NOT IMPLEMENTED");
        player.playerState = new DownAttackingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownAttackingPlayerSprite(player.position);
    }

    public void FireSilverArrow()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile silverArrow = new SilverArrow(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(silverArrow);
    }

    public void FireArrow()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile arrow = new Arrow(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(arrow);
    }

    public void FireBoomerang()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile boomerang = new Boomerang(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(boomerang);
    }
    public void FireMagicBoomerang()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile magicBoomerang = new MagicBoomerang(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(magicBoomerang);
    }
    public void FireFireball()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile fireball = new Fireball(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(fireball);
    }
    public void FireBomb()
    {
        player.playerState = new DownUsingPlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateDownUsingPlayerSprite(player.position);
        IProjectile bomb = new Bomb(player.position, "down", player.projectileSpriteFactory);
        player.projectiles.Add(bomb);
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

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;

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

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;

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
    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
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

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
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

public class LeftUsingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
    public LeftUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while using item
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
        player.playerState = new LeftIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateLeftIdlePlayerSprite(player.position);
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

public class RightUsingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
    public RightUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while using item
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
        player.playerState = new RightIdlePlayerState(player, spriteFactory);
        player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
    }

    public void Update(GameTime gametime)
    {
        Debug.WriteLine("USING ITEM ANIMATION");
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}

public class UpUsingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
    public UpUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while using item
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
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            BeIdle();
        }
    }
}

public class DownUsingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private double injuredStartTime = 0.0;
    private double injuredEndTime = 2.5;
    public DownUsingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(String Direction)
    {
        // do nothing - can't change direction while using item
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