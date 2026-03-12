using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class HUDSpriteFactory
{
    private SpriteFont spriteFont;
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    public HUDSpriteFactory(SpriteFont font, SpriteBatch spriteBatch, Texture2D texture)
    { 
        spriteFont = font;
        this.spriteBatch = spriteBatch;
        this.texture = texture;
    }

    public HUDText CreateHUDText(Vector2 position)
    {
        return new HUDText(spriteFont, position, spriteBatch);
    }

    public HUDHeart CreateHUDHeart(string state)
    {
        return new HUDHeart(texture, spriteBatch, state);
    }
}