using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class InventoryScreenSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle topThird = new Rectangle(1,11, 255, 87);
    private Rectangle middleThird = new Rectangle(1, 112, 255, 87);
    private Rectangle bottomThird = new Rectangle(258, 11, 255, 55);

    private HUDSpriteFactory spriteFactory;
    private LinkInventory playerInventory;

    private ISprite primaryItem;
    private ISprite secondaryItem;

    private HUDText rupeeText { get; set; }
    private HUDText keyText { get; set; }
    private HUDText itemText { get; set; }

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
        itemText.Text = "" + playerInventory.items;
        itemText.TextColor = Color.White;

        secondaryItem = determineItemSprite(playerInventory.secondaryItem, new Vector2(550, 715));
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

    public void Update(GameTime gametime)
    {
        rupeeText.Text = "" + playerInventory.rupees;
        keyText.Text = "" + playerInventory.keys;
        itemText.Text = "" + playerInventory.items;
        //primaryItemSprite = determineItemSprite(playerInventory.primaryItem, new Vector2(hudPositioning.X + 575, hudPositioning.Y + 100));
        //secondaryItemSprite = determineItemSprite(playerInventory.secondaryItem, new Vector2(hudPositioning.X + 625, hudPositioning.Y + 130));
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, new Rectangle(0, 0, 1025, 309), topThird, Color.White);
        spriteBatch.Draw(texture, new Rectangle(0, 309, 1025, 309), middleThird, Color.White);
        spriteBatch.Draw(texture, new Rectangle(0, 618, 1025, 309), bottomThird, Color.White);

        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();
        
        secondaryItem.SpriteDraw(new Vector2(272, 170));

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
}
