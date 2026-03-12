using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class HUD
{
    private Rectangle hudPositioning;
    private HUDSpriteFactory textFactory;
    private ISprite hudBackground;
    private LinkInventory playerInventory;

    public HUDText rupeeText { get; set; }
    public HUDText keyText { get; set; }
    public HUDText itemText { get; set; }
    public HUDText healthHeader { get; set; }

    //private List<HUDHeart> heartDisplay = new();
    private Vector2 hudHeartStartPosition;
    
    public HUD(Rectangle hudPositioning, HUDSpriteFactory textFactory, HUDBackgroundSprite hudBackground, LinkInventory playerInventory)
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

        hudHeartStartPosition = new Vector2(hudPositioning.X + 705, hudPositioning.Y + 130);
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

        int totalHearts = playerInventory.currentHearts;
        string type;

        for (int i = 0; i < playerInventory.maxHearts; i++)
        {
            if(totalHearts == 1)
            {
                type = "half";
                totalHearts--;
            } else if (totalHearts > 0)
            {
                type = "full";
                totalHearts -= 2;
            } else
            {
                type = "empty";
            }

            Vector2 pos = new Vector2(hudHeartStartPosition.X + (i % 8) * 30, hudHeartStartPosition.Y + (i / 8) * 30);
            ISprite heart = textFactory.CreateHUDHeart(type);
            heart.SpriteDraw(pos);
        }

        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();
    }
}