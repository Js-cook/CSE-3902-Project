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

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 8);
        }
    }
    public Vector2 Position { get; set; }
    string direction;
    private double startTime = 0.0;
    private double endTime = 3;
    private int directionSign = 1;
    public bool Active { get; set; }

    private ISprite sprite;

    public GoriyaBoomerang(Vector2 position, string direction, EnemyProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
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
            case "up":
                positionNew.Y -= (3 * directionSign);
                break;
            case "down":
                positionNew.Y += (3 * directionSign);
                break;
            case "left":
                positionNew.X -= (3 * directionSign);
                break;
            case "right":
                positionNew.X += (3 * directionSign);
                break;
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

    public void ResetBoomerang(Vector2 position, string direction)
    {
        this.Position = position;
        this.direction = direction;
        directionSign = 1;
        startTime = 0.0;
    }

    


}

