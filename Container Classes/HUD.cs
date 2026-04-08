using Microsoft.Xna.Framework;
using Enums;
using System;
using System.Collections.Generic;

public class HUD
{
    public Rectangle hudPositioning { get; set; }
    private HUDSpriteFactory spriteFactory;
    private ISprite hudBackground;
    private LinkInventory playerInventory;

    private ISprite primaryItemSprite;
    private ISprite secondaryItemSprite;
    //private ISprite[] primarySecondaryItems;

    public HUDText rupeeText { get; set; }
    public HUDText keyText { get; set; }
    public HUDText itemText { get; set; }
    public HUDText healthHeader { get; set; }

    private Vector2 hudHeartStartPosition;
    
    public HUD(Rectangle hudPositioning, HUDSpriteFactory spriteFactory, HUDBackgroundSprite hudBackground, LinkInventory playerInventory)
    {
        this.hudPositioning = hudPositioning;
        this.spriteFactory = spriteFactory;
        this.playerInventory = playerInventory;
        this.hudBackground = hudBackground;

        rupeeText = spriteFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 67));
        rupeeText.Text = "" + playerInventory.rupees;
        rupeeText.TextColor = Color.White;

        keyText = spriteFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 130));
        keyText.Text = "" + playerInventory.keys;
        keyText.TextColor = Color.White;

        itemText = spriteFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 165));
        itemText.Text = "" + playerInventory.items;
        itemText.TextColor = Color.White;

        hudHeartStartPosition = new Vector2(hudPositioning.X + 705, hudPositioning.Y + 130);

        primaryItemSprite = determineItemSprite(playerInventory.primaryItem, new Vector2(hudPositioning.X + 575, hudPositioning.Y + 100));
        secondaryItemSprite = determineItemSprite(playerInventory.secondaryItem, new Vector2(hudPositioning.X + 625, hudPositioning.Y + 130));
    }

    private ISprite determineItemSprite(Weapon weapon, Vector2 position)
    {
        ISprite selectedSprite = null;
        switch (weapon)
        {
            case Weapon.WOOD_SWORD:
                selectedSprite = spriteFactory.CreateHUDWoodSwordSprite(position);
                break;
            case Weapon.ARROW:
                selectedSprite = spriteFactory.CreateHUDArrowSprite(position);
                break;
            case Weapon.SILVER_ARROW:
                selectedSprite = spriteFactory.CreateHUDSilverArrowSprite(position);
                break;
            case Weapon.BOMB:
                selectedSprite = spriteFactory.CreateHUDBombSprite(position);
                break;
            case Weapon.BOOMERANG:
                selectedSprite = spriteFactory.CreateHUDBoomerangSprite(position);
                break;
            case Weapon.MAGIC_BOOMERANG:
                selectedSprite = spriteFactory.CreateHUDMagicBoomerangSprite(position);
                break;
            case Weapon.NONE:
                break;
        }

        return selectedSprite;
    }

    public void Update(GameTime gameTime)
    {
        rupeeText.Text = "" + playerInventory.rupees;
        keyText.Text = "" + playerInventory.keys;
        itemText.Text = "" + playerInventory.items;
        primaryItemSprite = determineItemSprite(playerInventory.primaryItem, new Vector2(hudPositioning.X + 575, hudPositioning.Y + 100));
        secondaryItemSprite = determineItemSprite(playerInventory.secondaryItem, new Vector2(hudPositioning.X + 625, hudPositioning.Y + 130));
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
            ISprite heart = spriteFactory.CreateHUDHeart(type);
            heart.SpriteDraw(pos);
        }

        if (primaryItemSprite != null)
            primaryItemSprite.SpriteDraw(new Vector2(hudPositioning.X + 613, hudPositioning.Y + 100));

        if (secondaryItemSprite != null)
            secondaryItemSprite.SpriteDraw(new Vector2(hudPositioning.X + 514, hudPositioning.Y + 100));

        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();
    }
}