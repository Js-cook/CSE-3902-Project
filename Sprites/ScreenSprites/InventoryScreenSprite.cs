using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class InventoryScreenSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle topThird = new Rectangle(1,11, 255, 87);
    private Rectangle middleThird = new Rectangle(258, 112, 255, 87);
    private Rectangle bottomThird = new Rectangle(258, 11, 255, 55);

    private HUDSpriteFactory spriteFactory;
    private LinkInventory playerInventory;

    private HUDText rupeeText { get; set; }
    private HUDText keyText { get; set; }
    private HUDText itemText { get; set; }

    private Dictionary<(int, int), Vector2> mapIndicators;
    private ISprite hudMapCover;
    private ISprite hudLocator;
    private ISprite compassLocator;

    private InventoryMapSprite inventoryMap;

    private ISprite compassSprite;
    private ISprite mapSprite;
    private ISprite redRingSprite;
    private ISprite powerBraceletSprite;

    public InventoryScreenSprite(Texture2D texture, SpriteBatch spriteBatch, HUDSpriteFactory spriteFactory, LinkInventory playerInventory)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;

        this.spriteFactory = spriteFactory;
        this.playerInventory = playerInventory;

        rupeeText = spriteFactory.CreateHUDText(new Vector2(390, 715));
        rupeeText.Text = "" + playerInventory.rupees;
        rupeeText.TextColor = Color.White;

        keyText = spriteFactory.CreateHUDText(new Vector2(390, 800));
        keyText.Text = "" + playerInventory.keys;
        keyText.TextColor = Color.White;

        itemText = spriteFactory.CreateHUDText(new Vector2(390, 855));
        itemText.Text = "" + playerInventory.calculateNumberOfSecondaryItems();
        itemText.TextColor = Color.White;

        hudMapCover = spriteFactory.CreateHUDSquareSprite(new Rectangle(63, 645 + 32, 275, 195), Color.Black);

        mapIndicators = new()
        {
            {(0, 1), new Vector2(125, 618 + 65) },
            {(0, 2), new Vector2(167, 618 + 65) },
            {(1, 2), new Vector2(167, 618 + 105) },
            {(2, 2), new Vector2(167, 618 + 140) },
            {(2, 1), new Vector2(125, 618 + 140) },
            {(2, 0), new Vector2(83, 618 + 140) },
            {(3, 1), new Vector2(125, 618 + 170) },
            {(3, 2), new Vector2(167, 618 + 170) },
            {(4, 2), new Vector2(167, 618 + 200) },
            {(5, 1), new Vector2(125, 618 + 240) },
            {(5, 2), new Vector2(167, 618 + 240) }, // starting room
            {(2, 3), new Vector2(209, 618 + 140) },
            {(3, 3), new Vector2(209, 618 + 170) },
            {(5, 3), new Vector2(209, 618 + 240) },
            {(1, 4), new Vector2(251, 618 + 105) },
            {(2, 4), new Vector2(251, 618 + 140) },
            {(1, 5), new Vector2(293, 618 + 105) },
        };

        try
        {
            hudLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle((int)mapIndicators[((int)(playerInventory.currentRoom.X), (int)(playerInventory.currentRoom.Y))].X, (int)mapIndicators[((int)playerInventory.currentRoom.X, (int)playerInventory.currentRoom.Y)].Y, 10, 10), Color.LimeGreen);
        }
        catch
        {
            hudLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle((int)mapIndicators[(0, 1)].X, (int)mapIndicators[(0, 1)].Y, 10, 10), Color.LimeGreen);
        }
        compassLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle(0 + 293, 618 + 70, 10, 10), Color.Red);

        inventoryMap = new InventoryMapSprite(texture, spriteBatch, playerInventory, spriteFactory);

        compassSprite = spriteFactory.CreateHUDCompassSprite();
        mapSprite = spriteFactory.CreateHUDMapSprite();
        redRingSprite = spriteFactory.CreateHUDRedRingSprite();
        powerBraceletSprite = spriteFactory.CreateHUDPowerBraceletSprite();
    }

    public void Update(GameTime gametime)
    {
        rupeeText.Text = "" + playerInventory.rupees;
        keyText.Text = "" + playerInventory.keys;
        itemText.Text = "" + playerInventory.calculateNumberOfSecondaryItems();

        hudLocator = spriteFactory.CreateHUDSquareSprite(new Rectangle((int)mapIndicators[((int)(playerInventory.currentRoom.X), (int)(playerInventory.currentRoom.Y))].X, (int)mapIndicators[((int)playerInventory.currentRoom.X, (int)playerInventory.currentRoom.Y)].Y, 10, 10), Color.LimeGreen);

        inventoryMap.Update(gametime);
    }

    private void RenderHearts()
    {
        int totalHearts = playerInventory.currentHearts;
        string type;

        for (int i = 0; i < playerInventory.maxHearts; i++)
        {
            if (totalHearts == 1)
            {
                type = "half";
                totalHearts--;
            }
            else if (totalHearts > 0)
            {
                type = "full";
                totalHearts -= 2;
            }
            else
            {
                type = "empty";
            }

            Vector2 pos = new Vector2(740 + (i % 8) * 30, 760 + (i / 8) * 30);
            ISprite heart = spriteFactory.CreateHUDHeart(type);
            heart.SpriteDraw(pos);

        }
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 309), topThird, Color.White);
        spriteBatch.Draw(texture, new Rectangle(0, 309, 1025, 309), middleThird, Color.White);
        spriteBatch.Draw(texture, new Rectangle(0, 618, 1025, 309), bottomThird, Color.White);

        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();

        inventoryMap.SpriteDraw(Vector2.Zero);

        RenderHearts();

        if (!playerInventory.hasMap)
        {
            hudMapCover.SpriteDraw(new Vector2(300, 618 + 50));
        } else
        {
            mapSprite.SpriteDraw(new Vector2(190, 393));
        }

        if (playerInventory.hasCompass)
        {
            compassLocator.SpriteDraw(Vector2.Zero);
            compassSprite.SpriteDraw(new Vector2(178, 535));
        }

        if (playerInventory.hasRedRing)
        {
            redRingSprite.SpriteDraw(new Vector2(520, 90));
        }

        if (playerInventory.hasPowerBracelet)
        {
            powerBraceletSprite.SpriteDraw(new Vector2(620, 80));
        }

        hudLocator.SpriteDraw(Vector2.Zero);
    }
}
