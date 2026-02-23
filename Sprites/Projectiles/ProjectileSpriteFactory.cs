using Enums;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
