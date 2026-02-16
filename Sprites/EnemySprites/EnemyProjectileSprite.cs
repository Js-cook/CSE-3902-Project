using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Security.AccessControl;

public class EnemyProjectileSpriteFactory
{
    private Texture2D projectileTexture;
    private SpriteBatch spriteBatch;

    public EnemyProjectileSpriteFactory(Texture2D texture, SpriteBatch spriteBatch)
    {
        projectileTexture = texture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateGoriyaBoomerangSprite(Vector2 position)
    {
        return new GoriyaBoomerangSprite(projectileTexture, position, spriteBatch);
    }

}




    public class GoriyaBoomerangSprite : ISprite
    {
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    private int currentFrame;

    private double animationTimer = 0.0;
    private double animationInterval = 0.1;

    private Rectangle[] sourceFrames =
    {
        new Rectangle(290, 11, 8, 16),
        new Rectangle(299, 11, 8, 16),
        new Rectangle(308, 11, 8, 16),
    };

    public GoriyaBoomerangSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.position = position;
        currentFrame = 0;
    }
    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, sourceFrames[currentFrame], Color.White);
    }
    public void Update(GameTime gametime)
    {
        Debug.WriteLine("UPDATE BOOMERANG");
        animationTimer += gametime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= animationInterval)
        {
            currentFrame = (currentFrame + 1) % sourceFrames.Length;
            animationTimer = 0.0;
        }
    }
}

