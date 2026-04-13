using Microsoft.Xna.Framework;
using Enums;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

public class HUD
{
    public Rectangle hudPositioning { get; set; }
    private HUDSpriteFactory spriteFactory;
    private ISprite hudBackground;
    private LinkInventory playerInventory;

    private ISprite primaryItemSprite;
    private ISprite secondaryItemSprite;

    private ISprite hudMapCover;
    private ISprite hudLocator;
    private ISprite compassLocator;
    private Dictionary<(int, int), Vector2> mapIndicators;

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

        hudHeartStartPosition = new Vector2(hudPositioning.X + 705, hudPositioning.Y + 130);

        primaryItemSprite = determineItemSprite(playerInventory.primaryItem, new Vector2(hudPositioning.X + 575, hudPositioning.Y + 100));
        secondaryItemSprite = determineItemSprite(playerInventory.secondaryItem, new Vector2(hudPositioning.X + 625, hudPositioning.Y + 130));
        
        itemText = spriteFactory.CreateHUDText(new Vector2(hudPositioning.X + 390, hudPositioning.Y + 165));
        itemText.Text = "" + playerInventory.calculateNumberOfSecondaryItems();
        itemText.TextColor = Color.White;

        hudMapCover = spriteFactory.CreateHUDSquareSprite(new Rectangle(hudPositioning.X + 63, hudPositioning.Y + 32, 275, 190), Color.Black);

        mapIndicators = new()
        {
            {(0, 1), new Vector2(hudPositioning.X + 125, hudPositioning.Y + 45) },
            {(0, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 45) },
            {(1, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 70) },
            {(2, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 95) },
            {(2, 1), new Vector2(hudPositioning.X + 125, hudPositioning.Y + 95) },
            {(2, 0), new Vector2(hudPositioning.X + 83, hudPositioning.Y + 95) },
            {(3, 1), new Vector2(hudPositioning.X + 125, hudPositioning.Y + 120) },
            {(3, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 120) },
            {(4, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 145) },
            {(5, 1), new Vector2(hudPositioning.X + 125, hudPositioning.Y + 170) },
            {(5, 2), new Vector2(hudPositioning.X + 167, hudPositioning.Y + 170) }, // starting room
            {(2, 3), new Vector2(hudPositioning.X + 209, hudPositioning.Y + 95) },
            {(3, 3), new Vector2(hudPositioning.X + 209, hudPositioning.Y + 120) },
            {(5, 3), new Vector2(hudPositioning.X + 209, hudPositioning.Y + 170) },
            {(1, 4), new Vector2(hudPositioning.X + 251, hudPositioning.Y + 70) },
            {(2, 4), new Vector2(hudPositioning.X + 251, hudPositioning.Y + 95) },
            {(1, 5), new Vector2(hudPositioning.X + 293, hudPositioning.Y + 70) },
        };

        hudLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle((int)mapIndicators[((int)(playerInventory.currentRoom.X), (int)(playerInventory.currentRoom.Y))].X, (int)mapIndicators[((int)playerInventory.currentRoom.X, (int)playerInventory.currentRoom.Y)].Y, 10, 10), Color.LimeGreen);
        compassLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle(hudPositioning.X + 293, hudPositioning.Y + 70, 10, 10), Color.Red);
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
        itemText.Text = "" + playerInventory.calculateNumberOfSecondaryItems();
        primaryItemSprite = determineItemSprite(playerInventory.primaryItem, new Vector2(hudPositioning.X + 575, hudPositioning.Y + 100));
        secondaryItemSprite = determineItemSprite(playerInventory.secondaryItem, new Vector2(hudPositioning.X + 625, hudPositioning.Y + 130));

        hudLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle((int)mapIndicators[((int)(playerInventory.currentRoom.X), (int)(playerInventory.currentRoom.Y))].X, (int)mapIndicators[((int)playerInventory.currentRoom.X, (int)playerInventory.currentRoom.Y)].Y, 10, 10), Color.LimeGreen);
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


        if (playerInventory.hasCompass)
        {
            compassLocator.SpriteDraw(Vector2.Zero);
        }

        if (!playerInventory.hasMap)
        {
            hudMapCover.SpriteDraw(new Vector2(hudPositioning.X + 300, hudPositioning.Y + 50));
        }

        hudLocator.SpriteDraw(Vector2.Zero);
    }
}