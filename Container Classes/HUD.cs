using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class HUD
{
    private Rectangle hudPositioning;
    private TextFactory textFactory;
    private ISprite hudBackground;

    public RupeeText rupeeText { get; set; }

    public HUD(Rectangle hudPositioning, TextFactory textFactory)
    {
        this.hudPositioning = hudPositioning;
        this.textFactory = textFactory;

        rupeeText = textFactory.CreateRupeeText(new Vector2(hudPositioning.X + 100, hudPositioning.Y + 100));
    }

    public void Update(GameTime gameTime)
    {

    }
    public void Draw()
    {


    }
}