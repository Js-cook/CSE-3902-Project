using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class TileFactory
{
    private Texture2D tileTexture;
    private SpriteBatch spriteBatch;

    public TileFactory(Texture2D tileTexture, SpriteBatch spriteBatch)
    {
        this.tileTexture = tileTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateStatueSprite()
    {
        return new StatueSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateSquareBlockSprite()
    {
        return new SquareBlockSprite(tileTexture, spriteBatch);
    }
    public ISprite CreateBlueGapSprite()
    {
        return new BlueGapSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateStairSprite()
    {
        return new StairSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateWhiteBrickSprite()
    {
        return new WhiteBrickSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateLadderSprite()
    {
        return new LadderSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBlueFloorSprite()
    {
        return new BlueFloorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBlueSandSprite()
    {
        return new BlueSandSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateWallSprite()
    {
        return new WallSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBombedWallSprite()
    {
        return new BombedWallSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateOpenDoorSprite()
    {
        return new OpenDoorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateKeyLockedDoorSprite()
    {
        return new KeyLockedDoorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateDiamondLockedDoorSprite()
    {
        return new DiamondLockedDoorSprite(tileTexture, spriteBatch);
    }
}