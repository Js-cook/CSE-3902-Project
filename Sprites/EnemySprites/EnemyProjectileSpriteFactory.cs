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





