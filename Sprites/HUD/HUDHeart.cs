using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class HUDHeart : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle fullHeart = new Rectangle(645, 117, 7, 7);
    private Rectangle halfHeart = new Rectangle(636, 117, 7, 7);
    private Rectangle emptyHeart = new Rectangle(627, 117, 7, 7);
    private Rectangle selectedHeart;
    private string state;

    public HUDHeart(Texture2D texture, SpriteBatch spriteBatch, string state)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.state = state;
        switch (state)
        {
            case "full":
                selectedHeart = fullHeart;
                break;
            case "half":
                selectedHeart = halfHeart;
                break;
            case "empty":
                selectedHeart = emptyHeart;
                break;
        }
    }

    public void Update(GameTime gametime)
    {
        switch (state)
        {
            case "full":
                selectedHeart = fullHeart;
                break;
            case "half":
                selectedHeart= halfHeart;
                break;
            case "empty":
                selectedHeart= emptyHeart;
                break;
        }
    }

    public void SpriteDraw(Vector2 position)
    {
        int scale = 4;

        Rectangle destinationRectangle = new Rectangle(
            (int)position.X,
            (int)position.Y,
            selectedHeart.Width * scale,
            selectedHeart.Height * scale
        );
        spriteBatch.Draw(texture, destinationRectangle, selectedHeart, Color.White);
    }
}