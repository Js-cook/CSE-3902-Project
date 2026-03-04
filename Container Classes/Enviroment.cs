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
    public Dictionary<int, ISprite> doorMap = new Dictionary<int, ISprite>();
    public Dictionary<string, ISprite> tileMap { get; set; }
    private TileFactory factory;

    private const int tileSize = 32;
    private const int hudHeight = 112;
    private const int wallOffset = 64;

    public Environment(TileFactory factory)
    {
        this.factory = factory;
        tiles = new List<ISprite[]>();


        tileMap = new Dictionary<string, ISprite> 
        {
            { "SquareBlock", factory.CreateSquareBlockSprite() },
            { "PushSquareBlock", factory.CreatePushSquareBlockSprite() },
            { "Fire", factory.CreateFireSprite()  },
            { "BlueGap", factory.CreateBlueGapSprite() },
            { "Stair", factory.CreateStairSprite() },
            { "WhiteBrick", factory.CreateWhiteBrickSprite() },
            { "Ladder", factory.CreateLadderSprite() },
            { "BlueFloor", factory.CreateBlueFloorSprite() },
            { "BlueSand", factory.CreateBlueSandSprite() },
            { "RoomExterior", factory.CreateRoomExteriorSprite() },
            { "LeftStatue", factory.CreateLeftStatueSprite()  },
            { "RightStatue", factory.CreateRightStatueSprite()  }
        };
    }

    public void AssignDoor(int direction, string type)
    {
        doorMap[direction] = type switch
        {
            "BombedWall" => factory.CreateBombedWallSprite(direction),
            "DiamondLockedDoor" => factory.CreateDiamondLockedDoorSprite(direction),
            "KeyLockedDoor" => factory.CreateKeyLockedDoorSprite(direction),
            "OpenDoor" => factory.CreateOpenDoorSprite(direction),
            _ => factory.CreateWallSprite(direction)
        };
    }

    private Vector2 GetDoorPosition(int direction)
    {
        return direction switch
        {
            0 => new Vector2(224, 112),
            1 => new Vector2(448, 256),
            2 => new Vector2(224, 400),
            3 => new Vector2(0, 256),
            _ => Vector2.Zero
        };
    }

    public void Update(GameTime gameTime)
    {
        tileMap["RoomExterior"].Update(gameTime);
        foreach (ISprite[] tileRow in tiles)
        {
            foreach (ISprite tile in tileRow) tile.Update(gameTime);
        }
        foreach (var door in doorMap.Values) door.Update(gameTime);
    }

    public void Draw()
    {

        Vector2 currentPos = new Vector2(wallOffset, hudHeight + wallOffset);
        foreach (ISprite[] tileRow in tiles)
        {
            float rowStartX = currentPos.X;
            foreach (ISprite tile in tileRow)
            {
                tile.SpriteDraw(currentPos);
                currentPos.X += tileSize;
            }
            currentPos.X = rowStartX;
            currentPos.Y += tileSize;
        }

        tileMap["RoomExterior"].SpriteDraw(new Vector2(0, hudHeight));

        foreach (var kvp in doorMap)
        {
            kvp.Value.SpriteDraw(GetDoorPosition(kvp.Key));
        }
    }
}