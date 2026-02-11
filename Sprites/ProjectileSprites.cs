using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
    public ISprite CreateArrowSprite(Vector2 position, string direction)
    {
        return new ArrowSprite(projectileTexture, position, spriteBatch, direction);
    }
    public ISprite CreateSilverArrowSprite(Vector2 position, string direction)
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
}

public class BoomerangSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;

    private Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);

    public BoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
    }
    public void SpriteDraw(Vector2 position)
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}

public class MagicBoomerangSprite : ISprite
{
    public MagicBoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
    }
    public void SpriteDraw(Vector2 position)
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}

public class ArrowSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private string direction;

    private Rectangle sourceRectangleHorizontal = new Rectangle(9, 184, 17, 17);
    private Rectangle sourceRectangleVertical = new Rectangle(0, 184, 9, 17);

    public ArrowSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, string direction)
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
            case "up":
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White);
                break;
            case "down":
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, new Vector2(0,0), 1.0f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case "left":
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, new Vector2(0,0), 1.0f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case "right":
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
        // arrow doesn't need to animate
    }
}

public class SilverArrowSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private string direction;

    private Rectangle sourceRectangleHorizontal = new Rectangle(35, 184, 17, 17);
    private Rectangle sourceRectangleVertical = new Rectangle(26, 184, 9, 17);
    public SilverArrowSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, string direction)
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
            case "up":
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White);
                break;
            case "down":
                spriteBatch.Draw(texture, position, sourceRectangleVertical, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipVertically, 0.0f);
                break;
            case "left":
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 0.0f);
                break;
            case "right":
                spriteBatch.Draw(texture, position, sourceRectangleHorizontal, Color.White);
                break;
        }
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}

public class BombSprite : ISprite
{
    public BombSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
    }
    public void SpriteDraw(Vector2 position)
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}

public class FireballSprite : ISprite
{
    public FireballSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
    }
    public void SpriteDraw(Vector2 position)
    {
        throw new NotImplementedException();
    }
    public void Update(GameTime gametime)
    {
        throw new NotImplementedException();
    }
}
