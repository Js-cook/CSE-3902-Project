using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DodongoSpriteFactory
{
    private Texture2D dodongoTexture;
    private SpriteBatch spriteBatch;

    public DodongoSpriteFactory(Texture2D dodongoTexture, SpriteBatch spriteBatch)
    {
        this.dodongoTexture = dodongoTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingDodongoSprite(Vector2 position, Direction direction = Direction.UP)
    {
        return new MovingDodongoSprite(dodongoTexture, position, spriteBatch, direction);
    }

    public ISprite CreateDamagedDodongoSprite(Vector2 position, Direction direction = Direction.UP)
    {
        return new DamagedDodongoSprite(dodongoTexture, position, spriteBatch, direction);
    }
}