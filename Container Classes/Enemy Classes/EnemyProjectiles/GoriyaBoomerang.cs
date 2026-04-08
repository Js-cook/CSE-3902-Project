using Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;



public class GoriyaBoomerang : IProjectile
{

    public int DamageValue { get; set; }
    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }
    public bool HitboxActive { get; set; }
    public Vector2 Position { get; set; }
    private Vector2 startPos;
    Direction direction;
    private double startTime = 0.0;
    private double endTime = 3;
    private int directionSign = 1;
    public bool Active { get; set; }

    private ISprite sprite;

    // new properties
    public ICollidable owner { get; set; }
    public bool isPlayerProjectile { get; set; } = false;

    public GoriyaBoomerang(Vector2 position, Direction direction, EnemyProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        startPos = position;
        this.direction = direction;
        sprite = spriteFactory.CreateGoriyaBoomerangSprite(position);
        Active = false;

    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        sprite.Update(gametime);
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        Vector2 positionNew = new Vector2(Position.X, Position.Y);
        switch (direction)
        {
            case Direction.UP:
                positionNew.Y -= (3 * directionSign);
                break;
            case Direction.DOWN:
                positionNew.Y += (3 * directionSign);
                break;
            case Direction.LEFT:
                positionNew.X -= (3 * directionSign);
                break;
            case Direction.RIGHT:
                positionNew.X += (3 * directionSign);
                break;
        }
        if (positionNew.Equals(startPos))
        {
            Active = false;
        }

        Position = positionNew;

        if (startTime >= (endTime / 2))
        {
            directionSign = -1;
        }

        if (startTime >= endTime)
        {
            Active = false;
        }
    }

    public void ResetBoomerang(Vector2 position, Direction direction)
    {
        this.Position = position;
        startPos = position;
        this.direction = direction;
        directionSign = 1;
        startTime = 0.0;
    }

    public void OnCollision()
    {
        //This will make it return
        startTime = endTime / 2;
    }




}

