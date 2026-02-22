using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Enums;

public class ProjectileSpriteFactory
{
    private Texture2D projectileTexture;
    private SpriteBatch spriteBatch;

    public ProjectileSpriteFactory(Texture2D texture, SpriteBatch spriteBatch)
    {
        projectileTexture = texture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateBoomerangSprite(Vector2 position)
    {
        return new BoomerangSprite(projectileTexture, position, spriteBatch);
    }
    public ISprite CreateMagicBoomerangSprite(Vector2 position)
    {
        return new MagicBoomerangSprite(projectileTexture, position, spriteBatch);
    }
    public ISprite CreateArrowSprite(Vector2 position, Direction direction)
    {
        return new ArrowSprite(projectileTexture, position, spriteBatch, direction);
    }
    public ISprite CreateSilverArrowSprite(Vector2 position, Direction direction)
    {
        return new SilverArrowSprite(projectileTexture, position, spriteBatch, direction);
    }
    public ISprite CreateBombSprite(Vector2 position)
    {
        return new BombSprite(projectileTexture, position, spriteBatch);
    }
    public ISprite CreateFireballSprite(Vector2 position)
    {
        return new FireballSprite(projectileTexture, position, spriteBatch);
    }
    public ISprite CreateArrowParticleSprite(Vector2 position)
    {
        return new ArrowParticleSprite(projectileTexture, position, spriteBatch);
    }

    public ISprite CreateBombParticleSprite(Vector2 position)
    {
        return new BombParticleSprite(projectileTexture, position, spriteBatch);
    }

}

public class BoomerangSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(64, 185, 7, 15),
        new Rectangle(73, 185, 7, 15),
        new Rectangle(82, 185, 7, 15),
    };

    public BoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        currentFrame = 0;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

public class MagicBoomerangSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(91, 185, 7, 15),
        new Rectangle(100, 185, 7, 15),
        new Rectangle(109, 185, 7, 15),
    };

    public MagicBoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        currentFrame = 0;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

public class ArrowSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Direction direction;

    private Rectangle sourceRectangleHorizontal = new Rectangle(10, 185, 15, 15);
    private Rectangle sourceRectangleVertical = new Rectangle(1, 185, 7, 15);

    public ArrowSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction direction)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        this.direction = direction;
    }
    public void SpriteDraw(Vector2 position)
    {
        switch(direction)
        {
            case Direction.UP:
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
            case Direction.DOWN:
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, new Vector2(0,0), 1.5f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case Direction.LEFT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, new Vector2(0,0), 1.5f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case Direction.RIGHT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
        // arrow doesn't need to animate
    }
}

public class ArrowParticleSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    private Rectangle sourceRectangle = new Rectangle(53, 185, 7, 15);

    public ArrowParticleSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceRectangle, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
    }
}

public class SilverArrowSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Direction direction;

    private Rectangle sourceRectangleHorizontal = new Rectangle(36, 185, 15, 15);
    private Rectangle sourceRectangleVertical = new Rectangle(27, 185, 7, 15);
    public SilverArrowSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, Direction direction)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        this.direction = direction;
    }
    public void SpriteDraw(Vector2 position)
    {
        switch (direction)
        {
            case Direction.UP:
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
            case Direction.DOWN:
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case Direction.LEFT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case Direction.RIGHT:
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
    }
}

public class BombSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private Rectangle frame = new Rectangle(129, 185, 8, 15);
    public BombSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.position = position;
        this.spriteBatch = spriteBatch;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
    }
}

public class BombParticleSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame = 0;

    private double animationTimer = 0.0;
    private double animationDuration = 0.25;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(138, 185, 15, 15),
        new Rectangle(155, 185, 15, 15),
        new Rectangle(172, 185, 15, 15)

    };

    public BombParticleSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0.0f);
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if(animationTimer >= animationDuration)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

public class FireballSprite : ISprite
{
    
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle frame = new Rectangle(191, 185, 15, 15);
    bool flipped = false;

    public FireballSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
    }
    public void SpriteDraw(Vector2 position)
    {
        if (flipped)
        {
            spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, new Vector2(0,0), 1.5f, SpriteEffects.None, 0.0f);
        } else
        {
            spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, new Vector2(0, 0), 1.5f, SpriteEffects.FlipHorizontally, 0.0f);
        }
    }
    public void Update(GameTime gametime)
    {
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if(animationTimer >= animationInterval)
        {
            flipped = !flipped;
            animationTimer = 0;
        }
    }
}
