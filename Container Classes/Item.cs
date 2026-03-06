using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Item
{
    private List<ISprite> items;
    private int currentItemIndex;
    private Vector2 position;

    public Item(ItemFactory factory)
    {
        // arbitrary starting position
        position = new Vector2(400, 100);
        currentItemIndex = 0;

        items = new List<ISprite>();
        items.Add(factory.CreateCompassSprite());
        items.Add(factory.CreateMapSprite());
        items.Add(factory.CreateKeySprite());
        items.Add(factory.CreateHeartContainerSprite());
        items.Add(factory.CreateTriForcePieceSprite());
        items.Add(factory.CreateWoodenBoomerangSprite());
        items.Add(factory.CreateBowSprite());
        items.Add(factory.CreateStaticArrowSprite());
        items.Add(factory.CreateStaticBombSprite());
        items.Add(factory.CreateHeartSprite());
        items.Add(factory.CreateRupeeSprite());
        items.Add(factory.CreateFairySprite());
        items.Add(factory.CreateClockSprite());


    }

    public void CycleRight()
    {
        currentItemIndex++;
        if (currentItemIndex >= items.Count)
            currentItemIndex = 0;
    }

    public void CycleLeft()
    {
        currentItemIndex--;
        if (currentItemIndex < 0)
            currentItemIndex = items.Count - 1;
    }

    public void CycleReset()
    {
        currentItemIndex = 0;
    }

    public void Update(GameTime gameTime)
    {
        items[currentItemIndex].Update(gameTime);
    }

    public void Draw()
    {
        items[currentItemIndex].SpriteDraw(position);
    }
}