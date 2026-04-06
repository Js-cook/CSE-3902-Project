using System;
using System.Collections.Generic;
using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


public class InventoryState : IGameState
{
    public GameStateSignal Signal { get; set; }
    public InventoryState()
    {
        Signal = GameStateSignal.NONE;
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