using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Environment
{
    public List<ISprite[]> tiles { get; set; }
    private int currentTileIndex;
    private Vector2 position;
    public Dictionary<string, ISprite> tileMap { get; set; }

    public Environment(TileFactory factory)
    {
        // arbitrary starting position
        position = new Vector2(32,32);
        currentTileIndex = 0;

        tiles = new List<ISprite[]>();

        //tiles = new List<ISprite>();
        //tiles.Add(factory.CreateStatueSprite());
        //tiles.Add(factory.CreateSquareBlockSprite());
        //tiles.Add(factory.CreatePushSquareBlockSprite());
        //tiles.Add(factory.CreateFireSprite());
        //tiles.Add(factory.CreateBlueGapSprite());
        //tiles.Add(factory.CreateStairSprite());
        //tiles.Add(factory.CreateWhiteBrickSprite());
        //tiles.Add(factory.CreateLadderSprite());
        //tiles.Add(factory.CreateBlueFloorSprite());
        //tiles.Add(factory.CreateBlueSandSprite());
        //tiles.Add(factory.CreateWallSprite());
        //tiles.Add(factory.CreateBombedWallSprite());
        //tiles.Add(factory.CreateKeyLockedDoorSprite());
        //tiles.Add(factory.CreateDiamondLockedDoorSprite());
        //tiles.Add(factory.CreateOpenDoorSprite());

        tileMap = new Dictionary<string, ISprite> 
        {
            { "Statue", factory.CreateStatueSprite() },
            { "SquareBlock", factory.CreateSquareBlockSprite() },
            { "PushSquareBlock", factory.CreatePushSquareBlockSprite() },
            { "Fire", factory.CreateFireSprite()  },
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
            { "OpenDoor", factory.CreateOpenDoorSprite() },
            { "RoomExterior", factory.CreateRoomExteriorSprite() }
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
        //tiles[currentTileIndex].Update(gameTime);
        tileMap["RoomExterior"].Update(gameTime);
        foreach (ISprite[] tileRow in tiles)
        {
            foreach (ISprite tile in tileRow)
            {
                tile.Update(gameTime);
            }
        }
    }

    public void Draw()
    {
        int increment = 32;
        foreach (ISprite[] tileRow in tiles)
        {
            foreach(ISprite tile in tileRow)
            {
                tile.SpriteDraw(position);
                position.X += increment; // TODO: make it so that it wraps back around to do next row; also change scaling in all the tile sprite classes (15x15)
            }
            position.X = 32;
            position.Y += increment;
        }
        position.Y = 32;
        tileMap["RoomExterior"].SpriteDraw(Vector2.Zero);
        //tiles[currentTileIndex].SpriteDraw(position);
    }
}