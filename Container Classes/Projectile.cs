using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class Boomerang : IProjectile
{
    public bool Active { get; set; }
    public Boomerang()
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

public class MagicBoomerang : IProjectile
{
    public bool Active { get; set; }
    public MagicBoomerang()
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

public class Arrow : IProjectile
{
    private Vector2 position;
    string direction;
    private double startTime = 0.0;
    private double endTime = 0.5;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    //private int velocity = 5;

    public Arrow(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateArrowSprite(position, direction);
        Active = true;
    }
    public void Draw()
    {
        sprite.SpriteDraw(position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;
        switch (direction)
        {
            case "up":
                position.Y -= 5;
                break;
            case "down":
                position.Y += 5;
                break;
            case "left":
                position.X -= 5;
                break;
            case "right":
                position.X += 5;
                break;
        }

        if(startTime >= endTime)
        {
            // do something to delete arrow
            Active = false;
        }
    }
}

public class SilverArrow : IProjectile
{
    private Vector2 position;
    string direction;
    private double startTime = 0.0;
    private double endTime = 0.5;
    public bool Active { get; set; }

    private ISprite sprite;
    private ProjectileSpriteFactory spriteFactory;

    public SilverArrow(Vector2 position, string direction, ProjectileSpriteFactory spriteFactory)
    {
        this.position = position;
        this.direction = direction;
        this.spriteFactory = spriteFactory;
        sprite = spriteFactory.CreateSilverArrowSprite(position, direction);
    }
    public void Draw()
    {
        sprite.SpriteDraw(position);
    }
    public void Update(GameTime gametime)
    {
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        switch (direction)
        {
            case "up":
                position.Y -= 5;
                break;
            case "down":
                position.Y += 5;
                break;
            case "left":
                position.X -= 5;
                break;
            case "right":
                position.X += 5;
                break;
        }

        if (startTime >= endTime)
        {
            // do something to delete arrow
        }
    }
}

public class Bomb : IProjectile
{
    public bool Active { get; set; }
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
