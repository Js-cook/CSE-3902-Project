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
    private Texture2D linkTexture;
    private SpriteBatch spriteBatch;
    public TileFactory(Texture2D tileTexture, Texture2D linkTexture, SpriteBatch spriteBatch)
    {
        this.tileTexture = tileTexture;
        this.linkTexture = linkTexture;
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
    public ISprite CreatePushSquareBlockSprite()
    {
        return new PushSquareBlockSprite(tileTexture, spriteBatch);
    }
    public ISprite CreateBlueGapSprite()
    {
        return new BlueGapSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateFireSprite()
    {
        return new FireSprite(linkTexture, spriteBatch);
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

    public ISprite CreateRoomExteriorSprite()
    {
        return new RoomExteriorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateWallSprite(int direction) 
    { 
        return new WallSprite(tileTexture, spriteBatch, direction); 
    }
    public ISprite CreateBombedWallSprite(int direction)
    { 
        return new BombedWallSprite(tileTexture, spriteBatch, direction); 
    }
    public ISprite CreateDiamondLockedDoorSprite(int direction) 
    { 
        return new DiamondLockedDoorSprite(tileTexture, spriteBatch, direction); 
    }
    public ISprite CreateKeyLockedDoorSprite(int direction) 
    { 
        return new KeyLockedDoorSprite(tileTexture, spriteBatch, direction); 
    }
    public ISprite CreateOpenDoorSprite(int direction) 
    { 
        return new OpenDoorSprite(tileTexture, spriteBatch, direction); 
    }
}