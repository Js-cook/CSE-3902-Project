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

    public Item(FactoryStorage factoryStorage)
    {
        // arbitrary starting position
        position = new Vector2(400, 100);
        currentItemIndex = 0;

        items = new List<ISprite>()
        {
            factoryStorage.itemFactory.CreateCompassSprite(),
            factoryStorage.itemFactory.CreateMapSprite(),
            factoryStorage.itemFactory.CreateKeySprite(),
            factoryStorage.itemFactory.CreateHeartContainerSprite(),
            factoryStorage.itemFactory.CreateTriForcePieceSprite(),
            factoryStorage.itemFactory.CreateWoodenBoomerangSprite(),
            factoryStorage.itemFactory.CreateBowSprite(),
            factoryStorage.itemFactory.CreateStaticArrowSprite(),
            factoryStorage.itemFactory.CreateStaticBombSprite(),
            factoryStorage.itemFactory.CreateHeartSprite(),
            factoryStorage.itemFactory.CreateRupeeSprite(),
            factoryStorage.itemFactory.CreateFairySprite(),
            factoryStorage.itemFactory.CreateClockSprite()
        };


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