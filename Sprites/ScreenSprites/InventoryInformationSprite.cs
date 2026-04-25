using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class InventoryInformationSprite : ISprite
{
    private HUDSpriteFactory spriteFactory;
    private LinkInventory playerInventory;
    private HUDText rupeeText { get; set; }
    private HUDText keyText { get; set; }
    private HUDText itemText { get; set; }

    public InventoryInformationSprite(Texture2D texture, SpriteBatch spriteBatch, HUDSpriteFactory spriteFactory, LinkInventory playerInventory)
    {
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
    }

    public void Update(GameTime gameTime)
    {
        rupeeText.Text = "" + playerInventory.rupees;
        keyText.Text = "" + playerInventory.keys;
        itemText.Text = "" + playerInventory.calculateNumberOfSecondaryItems();
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
        rupeeText.Draw();
        keyText.Draw();
        itemText.Draw();

        RenderHearts();
    }
}