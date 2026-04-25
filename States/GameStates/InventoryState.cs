using System;
using System.Collections.Generic;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

public class InventoryState : IGameState
{
    public GameStateSignal Signal { get; set; }
    //private IGameState savedPlayingState;

    public LinkInventory playerInventory { get; set; }

    private InventoryScreenSprite inventoryScreenSprite;
    private SpriteBatch spriteBatch;

    private HUDSpriteFactory textFactory;

    private int[] cursorXPositions = [523, 619, 715, 811];
    private int[] cursorYPositions = [175, 232];

    private Dictionary<Vector2, Weapon> cursorLocationItemMap = new Dictionary<Vector2, Weapon>{
        { new Vector2(523, 175), Weapon.ARROW },
        { new Vector2(619, 175), Weapon.SILVER_ARROW },
        { new Vector2(715, 175), Weapon.BOMB },
        { new Vector2(811, 175), Weapon.BOOMERANG },
        { new Vector2(523, 232), Weapon.MAGIC_BOOMERANG },
        { new Vector2(619, 232), Weapon.NONE },
        { new Vector2(715, 232), Weapon.NONE },
        { new Vector2(811, 232), Weapon.NONE },
    };

    private int currentX = 0;
    private int currentY = 0;

    private HUDCursorSprite cursorSprite;

    private ISprite selectedSecondaryItem;

    private ISprite[] secondaryItems;
    private int[] secondaryItemCounts;

    private int buttonCooldown = 0;

    public InventoryState(LinkInventory inventory, SpriteBatch spriteBatch)
    {
        Signal = GameStateSignal.NONE;
        playerInventory = inventory;
        this.spriteBatch = spriteBatch;
    }
    public void LoadContent(ContentManager contentLoader)
    {
        // Load inventory content here
        textFactory = new HUDSpriteFactory(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), spriteBatch, contentLoader.Load<Texture2D>("HUD"), contentLoader.Load<Texture2D>("LinkSprites"));
        inventoryScreenSprite = new InventoryScreenSprite(contentLoader.Load<Texture2D>("HUD"), spriteBatch, textFactory, playerInventory);
        cursorSprite = textFactory.CreateHUDCursorSprite(new Vector2(cursorXPositions[0], cursorXPositions[0]));
        InitializeSecondaryItems();
    }
    private void InitializeSecondaryItems()
    {
        secondaryItems = new ISprite[8];
        secondaryItems[0] = textFactory.CreateHUDArrowSprite(new Vector2(cursorXPositions[0], cursorYPositions[0]));
        secondaryItems[1] = textFactory.CreateHUDSilverArrowSprite(new Vector2(cursorXPositions[1], cursorYPositions[0]));
        secondaryItems[2] = textFactory.CreateHUDBombSprite(new Vector2(cursorXPositions[2], cursorYPositions[0]));
        secondaryItems[3] = textFactory.CreateHUDBoomerangSprite(new Vector2(cursorXPositions[3], cursorYPositions[0]));
        secondaryItems[4] = textFactory.CreateHUDMagicBoomerangSprite(new Vector2(cursorXPositions[0], cursorYPositions[1]));
        secondaryItems[5] = null;
        secondaryItems[6] = null;
        secondaryItems[7] = null;

        secondaryItemCounts = [ playerInventory.arrows, playerInventory.silverArrows, playerInventory.bombs, playerInventory.boomerangs, playerInventory.magicBoomerangs ];

    }
    private void UpdateSecondaryItem()
    {
        switch(cursorLocationItemMap[new Vector2(cursorXPositions[currentX], cursorYPositions[currentY])])
        {
            case Weapon.ARROW:
                if (secondaryItemCounts[0] == 0)
                    goto default;
                selectedSecondaryItem = textFactory.CreateHUDArrowSprite(new Vector2(272, 170));
                playerInventory.secondaryItem = Weapon.ARROW;
                break;
            case Weapon.SILVER_ARROW:
                if (secondaryItemCounts[1] == 0)
                    goto default;
                selectedSecondaryItem = textFactory.CreateHUDSilverArrowSprite(new Vector2(272, 170));
                playerInventory.secondaryItem = Weapon.SILVER_ARROW;
                break;
            case Weapon.BOMB:
                if (secondaryItemCounts[2] == 0)
                    goto default;
                selectedSecondaryItem = textFactory.CreateHUDBombSprite(new Vector2(272, 170));
                playerInventory.secondaryItem = Weapon.BOMB;
                break;
            case Weapon.BOOMERANG:
                if (secondaryItemCounts[3] == 0)
                    goto default;
                selectedSecondaryItem = textFactory.CreateHUDBoomerangSprite(new Vector2(272, 170));
                playerInventory.secondaryItem = Weapon.BOOMERANG;
                break;
            case Weapon.MAGIC_BOOMERANG:
                if (secondaryItemCounts[4] == 0)
                    goto default;
                selectedSecondaryItem = textFactory.CreateHUDMagicBoomerangSprite(new Vector2(272, 170));
                playerInventory.secondaryItem = Weapon.MAGIC_BOOMERANG;
                break;
            default:
                selectedSecondaryItem = null;
                playerInventory.secondaryItem = Weapon.NONE;
                break;
        }
    }
    public void ResolveKey(KeyboardState keyState)
    {

        if (keyState.IsKeyDown(Keys.LeftControl))
        {
            Signal = GameStateSignal.TO_SAVED_PLAYING;
        }

        if(keyState.IsKeyDown(Keys.Left) && buttonCooldown == 0)
        {
            if(currentX == 0)
            {
                currentX = cursorXPositions.Length - 1;
            } else
            {
                currentX--;
            }
            buttonCooldown = 20;
        }
        if(keyState.IsKeyDown(Keys.Right) && buttonCooldown == 0)
        {
            currentX = (currentX + 1) % cursorXPositions.Length;
            buttonCooldown = 20;
        }
        if(keyState.IsKeyDown(Keys.Up) && buttonCooldown == 0)
        {
            if(currentY == 0)
            {
                currentY = 1;
            } else
            {
                currentY--;
            }
            buttonCooldown = 20;
        }
        if(keyState.IsKeyDown(Keys.Down) && buttonCooldown == 0)
        {
            currentY = (currentY + 1) % cursorYPositions.Length;
            buttonCooldown = 20;
        }
        UpdateSecondaryItem();
    }
    public void Update(GameTime gameTime)
    {
        // Update inventory state here
        if (buttonCooldown > 0)
        {
            buttonCooldown--;
        }
        inventoryScreenSprite.Update(gameTime);
        secondaryItemCounts = [playerInventory.arrows, playerInventory.silverArrows, playerInventory.bombs, playerInventory.boomerangs, playerInventory.magicBoomerangs];
    }

    private void DrawSecondaryItems()
    {
        int x = 0;
        int y = 0;
        int c = 0;
        foreach (ISprite sprite in secondaryItems)
        {
            if (sprite != null && secondaryItemCounts[c] > 0)
            {
                sprite.SpriteDraw(new Vector2(cursorXPositions[x] + 5, cursorYPositions[y] - 10));
            }
            if (x == 3)
            {
                x = 0;
                y++;
            }
            else
            {
                x++;
            }
            c++;
        }
    }

    public void Draw()
    {
        // Draw inventory UI here
        inventoryScreenSprite.SpriteDraw(Vector2.Zero);
        DrawSecondaryItems();
        cursorSprite.SpriteDraw(new Vector2(cursorXPositions[currentX], cursorYPositions[currentY]));
        selectedSecondaryItem?.SpriteDraw(new Vector2(272, 170));
    }
    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        // Reset inventory state if necessary
    }
}