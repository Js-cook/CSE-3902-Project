using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class HUDSpriteFactory
{
    private SpriteFont spriteFont;
    private Texture2D texture;
    private Texture2D itemTexture;
    private SpriteBatch spriteBatch;
    public HUDSpriteFactory(SpriteFont font, SpriteBatch spriteBatch, Texture2D texture, Texture2D itemTexture)
    { 
        spriteFont = font;
        this.spriteBatch = spriteBatch;
        this.texture = texture;
        this.itemTexture = itemTexture;
    }

    public HUDText CreateHUDText(Vector2 position)
    {
        return new HUDText(spriteFont, position, spriteBatch);
    }

    public HUDHeart CreateHUDHeart(string state)
    {
        return new HUDHeart(texture, spriteBatch, state);
    }

    public HUDArrowSprite CreateHUDArrowSprite(Vector2 position) {
        return new HUDArrowSprite(itemTexture, spriteBatch);
    }

    public HUDBombSprite CreateHUDBombSprite(Vector2 position)
    {
        return new HUDBombSprite(itemTexture, spriteBatch);
    }

    public HUDBoomerangSprite CreateHUDBoomerangSprite(Vector2 position)
    {
        return new HUDBoomerangSprite(itemTexture, spriteBatch);
    }

    public HUDMagicBoomerangSprite CreateHUDMagicBoomerangSprite(Vector2 position)
    {
        return new HUDMagicBoomerangSprite(itemTexture, spriteBatch);
    }

    public HUDSilverArrowSprite CreateHUDSilverArrowSprite(Vector2 position)
    {
        return new HUDSilverArrowSprite(itemTexture, spriteBatch);
    }

    public HUDWoodSwordSprite CreateHUDWoodSwordSprite(Vector2 position)
    {
        return new HUDWoodSwordSprite(itemTexture, spriteBatch);
    }

    public HUDCursorSprite CreateHUDCursorSprite(Vector2 position)
    {
        return new HUDCursorSprite(texture, spriteBatch);
    }

    public HUDSquareSprite CreateHUDSquareSprite(Rectangle coverage, Color color)
    {
        return new HUDSquareSprite(coverage, spriteBatch, texture, color);
    }

    public InventoryMapTileSprite CreateInventoryMapTileSprite(Vector2 source)
    {
        return new InventoryMapTileSprite(spriteBatch, texture, source);
    }

    public HUDCompassSprite CreateHUDCompassSprite()
    {
        return new HUDCompassSprite(texture, spriteBatch);
    }

    public HUDMapSprite CreateHUDMapSprite()
    {
        return new HUDMapSprite(texture, spriteBatch);
    }

    public HUDRedRingSprite CreateHUDRedRingSprite()
    {
        return new HUDRedRingSprite(texture, spriteBatch);
    }

    public HUDPowerBraceletSprite CreateHUDPowerBraceletSprite()
    {
        return new HUDPowerBraceletSprite(texture, spriteBatch);
    }
}