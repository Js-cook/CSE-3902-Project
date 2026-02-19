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

public class MagicBoomerang : IProjectile
{
    public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1.5;
    private int directionSign = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;
    public MagicBoomerang(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
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
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 0.75;
    private int directionSign = 1;
    public bool Active { get; set; }
    
    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public Boomerang(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
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
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 0.5;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    //private int velocity = 5;

    public Arrow(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
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
            case Direction.UP:
                positionNew.Y -= 5;
                break;
            case Direction.DOWN:
                positionNew.Y += 5;
                break;
            case Direction.LEFT:
                positionNew.X -= 5;
                break;
            case Direction.RIGHT:
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
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public SilverArrow(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
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
            case Direction.UP:
                positionNew.Y -= 5;
                break;
            case Direction.DOWN:
                positionNew.Y += 5;
                break;
            case Direction.LEFT:
                positionNew.X -= 5;
                break;
            case Direction.RIGHT:
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

    public ArrowParticle(Vector2 position, ProjectileSpriteFactory spriteFactory)
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

public class BombParticle : IProjectile
{
    public bool Active { get; set; }
    public Vector2 Position { get; set; }

    private double startTime = 0.0;
    private double duration = 0.6;
    private ISprite sprite;

    public BombParticle(Vector2 position, ProjectileSpriteFactory spriteFactory)
    {
        Position = position;
        sprite = spriteFactory.CreateBombParticleSprite(position);
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

        if (startTime >= duration)
        {
            // do something to delete particle
            Active = false;
        }
    }
}


public class Bomb : IProjectile
{
    public bool Active { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 0.75;

    ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public Vector2 Position { get; set; }
    public Bomb(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        //this.Position = position;
        switch (direction)
        {
            case Direction.LEFT:
                this.Position = new Vector2(position.X-20, position.Y);
                break;
            case Direction.RIGHT:
                this.Position = new Vector2(position.X + 20, position.Y);
                break;
            case Direction.DOWN:
                this.Position = new Vector2(position.X, position.Y + 20);
                break;
            case Direction.UP:
                this.Position = new Vector2(position.X, position.Y - 20);
                break;
        }
        this.spriteFactory = spriteFactory;
        this.sprite = spriteFactory.CreateBombSprite(position);
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
            Active = false;
        }
    }
}

public class Fireball : IProjectile
{
    public Vector2 Position { get; set; }
    private Direction direction;
    private double startTime = 0.0;
    private double endTime = 0.75;
    private int stopper = 1;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;
    public Fireball(Vector2 position, Direction direction, ProjectileSpriteFactory spriteFactory)
    {
        this.Position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateFireballSprite(position);
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
            case Direction.UP:
                positionNew.Y -= (3 * stopper);
                break;
            case Direction.DOWN:
                positionNew.Y += (3 * stopper);
                break;
            case Direction.LEFT:
                positionNew.X -= (3 * stopper);
                break;
            case Direction.RIGHT:
                positionNew.X += (3 * stopper);
                break;
        }
        Position = positionNew;

        if (startTime >= (3 * endTime / 4))
        {
            stopper = 0;
        }

        if (startTime >= endTime)
        {
            // do something to delete arrow
            Active = false;
        }
    }
}
