using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ItemFactory
{
    private Texture2D itemTexture;
    private SpriteBatch spriteBatch;

    public ItemFactory(Texture2D itemTexture, SpriteBatch spriteBatch)
    {
        this.itemTexture = itemTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateCompassSprite()
    {
        return new CompassSprite(itemTexture, spriteBatch);
    }

    public ISprite CreateMapSprite()
    {
        return new MapSprite(itemTexture, spriteBatch);
    }

    public ISprite CreateKeySprite()
    {
        return new KeySprite(itemTexture, spriteBatch);
    }

    public ISprite CreateHeartContainerSprite()
    {
        return new HeartContainerSprite(itemTexture, spriteBatch);
    }
    public ISprite CreateTriForcePieceSprite()
    {
        return new TriForcePieceSprite(itemTexture, spriteBatch);
    }
    public ISprite CreateWoodenBoomerangSprite()
    {
        return new WoodenBoomerangSprite(itemTexture, spriteBatch);
    }

    public ISprite CreateBowSprite()
    {
        return new BowSprite(itemTexture, spriteBatch);
    }

    public ISprite CreateHeartSprite()
    {
        return new HeartSprite(itemTexture, spriteBatch);
    }

    public ISprite CreateRupeeSprite()
    {
        return new RupeeSprite(itemTexture, spriteBatch);
    }
    public ISprite CreateFairySprite()
    {
        return new FairySprite(itemTexture, spriteBatch);
    }
    public ISprite CreateClockSprite()
    {
        return new ClockSprite(itemTexture, spriteBatch);
    }
}