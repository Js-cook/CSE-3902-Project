using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class HUD
{
    private Rectangle hudPositioning;
    private TextFactory textFactory;
    private ISprite hudBackground;
    private LinkInventory playerInventory;

    public RupeeText rupeeText { get; set; }

    public HUD(Rectangle hudPositioning, TextFactory textFactory, HUDBackgroundSprite hudBackground, LinkInventory playerInventory)
    {
        this.hudPositioning = hudPositioning;
        this.textFactory = textFactory;
        this.playerInventory = playerInventory;
        this.hudBackground = hudBackground;

        rupeeText = textFactory.CreateRupeeText(new Vector2(hudPositioning.X + 100, hudPositioning.Y + 100));
        rupeeText.Text = "Keys: " + playerInventory.keys;
        rupeeText.TextColor = Color.White;


    }

    public void Update(GameTime gameTime)
    {
        rupeeText.Text = "Keys: " + playerInventory.keys;
    }
    public void Draw()
    {
        hudBackground.SpriteDraw(new Vector2(hudPositioning.X, hudPositioning.Y));
        rupeeText.Draw();
    }
}