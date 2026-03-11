using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class HUD
{
    private Rectangle hudPositioning;
    private TextFactory textFactory;
    private ISprite hudBackground;
    private LinkInventory playerInventory;

    public HUDText rupeeText { get; set; }
    public HUDText keyText { get; set; }
    public HUDText itemText { get; set; }
    public HUDText healthHeader { get; set; }

    

    public HUD(Rectangle hudPositioning, TextFactory textFactory, HUDBackgroundSprite hudBackground, LinkInventory playerInventory)
    {
        this.hudPositioning = hudPositioning;
        this.textFactory = textFactory;
        this.playerInventory = playerInventory;
        this.hudBackground = hudBackground;

        rupeeText = textFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 67));
        rupeeText.Text = "" + playerInventory.rupees;
        rupeeText.TextColor = Color.White;

        keyText = textFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 130));
        keyText.Text = "" + playerInventory.keys;
        keyText.TextColor = Color.White;

        itemText = textFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 165));
        itemText.Text = "" + playerInventory.items;
        itemText.TextColor = Color.White;
    }

    public void Update(GameTime gameTime)
    {
        rupeeText.Text = "" + playerInventory.rupees;
        keyText.Text = "" + playerInventory.keys;
        itemText.Text = "" + playerInventory.items;
    }
    public void Draw()
    {
        hudBackground.SpriteDraw(new Vector2(hudPositioning.X, hudPositioning.Y));

        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();
    }
}