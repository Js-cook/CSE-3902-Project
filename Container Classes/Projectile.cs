using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class MagicBoomerang : IProjectile
{
    public Vector2 Position { get; set; }
    string direction;
    private double startTime = 0.0;
    private double endTime = 1.5;
    private int directionSign = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;
    public MagicBoomerang(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateMagicBoomerangSprite(position);
        Active = true;
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
            // do something to delete arrow
            Active = false;
        }
    }
}

public class Boomerang : IProjectile
{
    public Vector2 Position { get; set; }
    string direction;
    private double startTime = 0.0;
    private double endTime = 0.75;
    private int directionSign = 1;
    public bool Active { get; set; }
    
    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public Boomerang(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateBoomerangSprite(position);
        Active = true;
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
            // do something to delete arrow
            Active = false;
        }
    }
}

public class Arrow : IProjectile
{
    public Vector2 Position { get; set; }
    string direction;
    private double startTime = 0.0;
    private double endTime = 0.5;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    //private int velocity = 5;

    public Arrow(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateArrowSprite(position, direction);
        Active = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        //Debug.WriteLine("ARROW UPDATE");
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        Vector2 positionNew = new Vector2(Position.X, Position.Y);
        switch (direction)
        {
            case "up":
                positionNew.Y -= 5;
                break;
            case "down":
                positionNew.Y += 5;
                break;
            case "left":
                positionNew.X -= 5;
                break;
            case "right":
                positionNew.X += 5;
                break;
        }
        Position = positionNew;

        if (startTime >= endTime)
        {
            // do something to delete arrow
            Active = false;
        }
    }
}

public class SilverArrow : IProjectile
{
    public Vector2 Position { get; set; }
    string direction;
    private double startTime = 0.0;
    private double endTime = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public SilverArrow(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateSilverArrowSprite(position, direction);
        Active = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        Vector2 positionNew = new Vector2(Position.X, Position.Y);
        switch (direction)
        {
            case "up":
                positionNew.Y -= 5;
                break;
            case "down":
                positionNew.Y += 5;
                break;
            case "left":
                positionNew.X -= 5;
                break;
            case "right":
                positionNew.X += 5;
                break;
        }
        Position = positionNew;

        if (startTime >= endTime)
        {
            Active = false;
        }
    }
}

public class ArrowParticle : IProjectile
{
    public Vector2 Position { get; set; }
    private double startTime = 0.0;
    private double endTime = 0.2;
    public bool Active { get; set; }

    private ISprite sprite;

    public ArrowParticle(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        sprite = spriteFactory.CreateArrowParticleSprite(position);
        Active = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        if (startTime >= endTime)
        {
            // do something to delete particle
            Active = false;
        }
    }
}

public class Bomb : IProjectile
{
    public bool Active { get; set; }
    public Vector2 Position { get; set; }
    public Bomb()
    {
    }
    public void Draw()
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}

public class Fireball : IProjectile
{
    public Vector2 Position { get; set; }
    public bool Active { get; set; }
    public Fireball()
    {
    }
    public void Draw()
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}
