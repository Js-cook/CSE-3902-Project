using System;
using System.Collections.Generic;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

public class InventoryState : IGameState
{
    public GameStateSignal Signal { get; set; }
    private IGameState savedPlayingState;

    private HUD HUD;
    private LinkInventory playerInventory;

    private InventoryScreenSprite inventoryScreenSprite;

    // TODO: add inventory background sprite 

    public InventoryState(IGameState playingState, HUD hud, LinkInventory inventory)
    {
        Signal = GameStateSignal.NONE;
        savedPlayingState = playingState;
        HUD = hud;
        playerInventory = inventory;
    }
    public void LoadContent(ContentManager contentLoader)
    {
        // Load inventory content here
    }
    public void ResolveKey(KeyboardState keyState)
    {
        // Handle inventory key inputs here
    }
    public void Update(GameTime gameTime)
    {
        // Update inventory state here
    }
    public void Draw()
    {
        // Draw inventory UI here
    }
    public void ResetState()
    {
        Signal = GameStateSignal.NONE;
        // Reset inventory state if necessary
    }
}