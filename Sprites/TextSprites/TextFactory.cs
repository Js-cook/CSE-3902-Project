using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class TextFactory
{
    private SpriteFont spriteFont;
    private SpriteBatch spriteBatch;
    public TextFactory(SpriteFont font, SpriteBatch spriteBatch)
    { 
        spriteFont = font;
        this.spriteBatch = spriteBatch;
    }

    public RupeeText CreateRupeeText(Vector2 position)
    {
        return new RupeeText(spriteFont, position, spriteBatch);
    }
}