using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Enums;

public class RupeeText : IText
{
    private SpriteFont font;
    private Vector2 position;
    private SpriteBatch spriteBatch;

    public string Text { get; set; }
    public Color TextColor { get; set; }

    public RupeeText(SpriteFont font, Vector2 position, SpriteBatch spriteBatch)
    {
        this.font = font;
        this.position = position;
        this.spriteBatch = spriteBatch;
    }
    
    public void Update()
    {

    }

    public void Draw()
    {
        spriteBatch.DrawString(font, Text, position, TextColor, 0, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
    }
}