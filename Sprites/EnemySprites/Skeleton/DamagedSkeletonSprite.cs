using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DamagedSkeletonSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Rectangle currentFrame;

    public bool Hurt { get; set; }

    private Rectangle sourceRectangle1 = new Rectangle(404, 194, 16, 16);
    private int colorIndex = 0;
    private Color[] hurtColors = [Color.Red, Color.Green, Color.Blue];
    private int frameCounter = 0;

    public DamagedSkeletonSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        currentFrame = sourceRectangle1;
    }

    public void Update(GameTime gametime)
    {
        frameCounter++;
        if (frameCounter >= 5)
        {
            colorIndex = (colorIndex + 1) % hurtColors.Length; 
        }

    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, position, currentFrame, hurtColors[colorIndex], 0.0f, new Vector2(0, 0), Settings.Instance.scale, SpriteEffects.None, 0.0f);
    }
}