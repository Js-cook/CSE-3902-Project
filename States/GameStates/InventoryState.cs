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

    private int currentX = 0;
    private int currentY = 0;

    private HUDCursorSprite cursorSprite;

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
    }
    public void Update(GameTime gameTime)
    {
        // Update inventory state here
        if (buttonCooldown > 0)
        {
            buttonCooldown--;
        }
        inventoryScreenSprite.Update(gameTime);
    }
    public void Draw()
    {
        // Draw inventory UI here
        inventoryScreenSprite.SpriteDraw(Vector2.Zero);
        cursorSprite.SpriteDraw(new Vector2(cursorXPositions[currentX], cursorYPositions[currentY]));
    }
    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        // Reset inventory state if necessary
    }
}