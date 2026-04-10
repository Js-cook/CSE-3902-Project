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

    public InventoryState(LinkInventory inventory, SpriteBatch spriteBatch)
    {
        Signal = GameStateSignal.NONE;
        //savedPlayingState = playingState;
        playerInventory = inventory;
        this.spriteBatch = spriteBatch;
    }
    public void LoadContent(ContentManager contentLoader)
    {
        // Load inventory content here
        textFactory = new HUDSpriteFactory(contentLoader.Load<SpriteFont>("Fonts/the-legend-of-zelda-nes"), spriteBatch, contentLoader.Load<Texture2D>("HUD"), contentLoader.Load<Texture2D>("LinkSprites"));
        inventoryScreenSprite = new InventoryScreenSprite(contentLoader.Load<Texture2D>("HUD"), spriteBatch, textFactory, playerInventory);
    }
    public void ResolveKey(KeyboardState keyState)
    {
        if (keyState.IsKeyDown(Keys.LeftControl))
        {
            Signal = GameStateSignal.TO_SAVED_PLAYING;
        }
    }
    public void Update(GameTime gameTime)
    {
        // Update inventory state here
        inventoryScreenSprite.Update(gameTime);
    }
    public void Draw()
    {
        // Draw inventory UI here
        inventoryScreenSprite.SpriteDraw(Vector2.Zero);
    }
    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        // Reset inventory state if necessary
    }
}