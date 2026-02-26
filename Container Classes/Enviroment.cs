using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;

public class Environment
{
    public List<ISprite> tiles { get; set; }
    private int currentTileIndex;
    private Vector2 position;

    public Dictionary<string, ISprite> tileMap { get; set; }

    public Environment(TileFactory factory)
    {
        // arbitrary starting position
        position = Vector2.Zero;
        currentTileIndex = 0;

        tiles = new List<ISprite>();
        tiles.Add(factory.CreateStatueSprite());
        tiles.Add(factory.CreateSquareBlockSprite());
        tiles.Add(factory.CreatePushSquareBlockSprite());
        tiles.Add(factory.CreateFireSprite());
        tiles.Add(factory.CreateBlueGapSprite());
        tiles.Add(factory.CreateStairSprite());
        tiles.Add(factory.CreateWhiteBrickSprite());
        tiles.Add(factory.CreateLadderSprite());
        tiles.Add(factory.CreateBlueFloorSprite());
        tiles.Add(factory.CreateBlueSandSprite());
        tiles.Add(factory.CreateWallSprite());
        tiles.Add(factory.CreateBombedWallSprite());
        tiles.Add(factory.CreateKeyLockedDoorSprite());
        tiles.Add(factory.CreateDiamondLockedDoorSprite());
        tiles.Add(factory.CreateOpenDoorSprite());

        tileMap = new Dictionary<string, ISprite> 
        {
            { "Statue", factory.CreateStatueSprite() },
            { "SquareBlock", factory.CreateSquareBlockSprite() },
            { "PushSquareBlock", factory.CreatePushSquareBlockSprite() },
            {  "Fire", factory.CreateFireSprite()  },
            { "BlueGap", factory.CreateBlueGapSprite() },
            { "Stair", factory.CreateStairSprite() },
            { "WhiteBrick", factory.CreateWhiteBrickSprite() },
            { "Ladder", factory.CreateLadderSprite() },
            { "BlueFloor", factory.CreateBlueFloorSprite() },
            { "BlueSand", factory.CreateBlueSandSprite() },
            { "Wall", factory.CreateWallSprite() },
            { "BombedWall", factory.CreateBombedWallSprite() },
            { "KeyLockedDoor", factory.CreateKeyLockedDoorSprite() },
            { "DiamondLockedDoor", factory.CreateDiamondLockedDoorSprite() },
            { "OpenDoor", factory.CreateOpenDoorSprite() }
        };

    }

    public void CycleRight()
    {
        currentTileIndex++;
        if (currentTileIndex >= tiles.Count)
            currentTileIndex = 0;
    }

    public void CycleLeft()
    {
        currentTileIndex--;
        if (currentTileIndex < 0)
            currentTileIndex = tiles.Count - 1;
    }

    public void CycleReset()
    {
        currentTileIndex = 0;
    }

    public void Update(GameTime gameTime)
    {
        tiles[currentTileIndex].Update(gameTime);
    }

    public void Draw()
    {
        foreach(ISprite tile in tiles)
        {
            tile.SpriteDraw(position);
            position.X += 15;
        }
        //tiles[currentTileIndex].SpriteDraw(position);
    }
}