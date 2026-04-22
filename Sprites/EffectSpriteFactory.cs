using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class EffectSpriteFactory
{
    private Texture2D playerTexture;
    private SpriteBatch spriteBatch;
    public EffectSpriteFactory(Texture2D playerTexture, SpriteBatch spriteBatch)
    {
        this.playerTexture = playerTexture;
        this.spriteBatch = spriteBatch;
    }


    public ISprite CreateDeathCloudSprite(Vector2 position)
    {
        return new DeathCloudSprite(playerTexture, position, spriteBatch);
    }

}








