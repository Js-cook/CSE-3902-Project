using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class TextFactory
{
    private SpriteFont spriteFont;
    public TextFactory(SpriteFont font)
    { 
        spriteFont = font;
    }

    public RupeeText CreateRupeeText(Vector2 position)
    {
        return new RupeeText(spriteFont, position);
    }
}