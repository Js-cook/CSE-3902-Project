using Enums;
using Microsoft.Xna.Framework;
using System;
using static WallmasterManager;

public class Wallmaster : IEnemy
{
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    public IEnemyState wallmasterState { get; set; }
    public WallDirection SpawnWall { get; set; }
    public bool IsCarryingPlayer { get; set; }

    public Rectangle Hitbox
    {
        get
        {
            if (HitboxActive)
                return new Rectangle((int)position.X, (int)position.Y, 16, 16);

            return Rectangle.Empty;
        }
    }

    public bool HitboxActive { get; set; }
    public int Health { get; set; }
    public bool isDead { get; set; }

    public Action OnResetDungeon { get; set; }

    private WallmasterSpriteFactory _spriteFactory;

    public Wallmaster(WallmasterSpriteFactory spriteFactory, Vector2 startPosition)
    {
        _spriteFactory = spriteFactory;
        position = startPosition;
        HitboxActive = false;
        IsCarryingPlayer = false;
        wallmasterState = new HiddenWallmasterState(this);
        Sprite = spriteFactory.CreateMovingWallmasterSprite(position);
    }

    public void Update(GameTime gametime)
    {
        wallmasterState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        if (HitboxActive)
        {
            Sprite.SpriteDraw(position);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        wallmasterState.TakeDamage();
    }

    public void ChangeState(IEnemyState newState)
    {
        wallmasterState = newState;
    }

    public void SpawnAt(WallDirection wall, Vector2 startPos)
    {
        SpawnWall = wall;
        position = startPos;
        HitboxActive = true;
        ChangeState(new EmergingWallmasterState(this, _spriteFactory));
    }

    public void OnWallCollision(Direction newDir)
    {
        wallmasterState.OnWallCollision(newDir);
    }

    public void DropHearts(int numHearts)
    {
    }

    public void GrabPlayer(Link player)
    {
        // Only grab if the hand is fully emerged and isn't already carrying Link
        if (!IsCarryingPlayer && HitboxActive)
        {
            IsCarryingPlayer = true;
            System.Diagnostics.Debug.WriteLine($"Hand grabbed player. Has Action: {this.OnResetDungeon != null}");
            // 1. Tell the Wallmaster to start moving back into the wall
            ChangeState(new RetreatingWallmasterState(this, _spriteFactory));

            // 2. Force Link into the grabbed state so he can't move or attack
            player.playerState = new GrabbedPlayerState(player, this);
        }
    }
}