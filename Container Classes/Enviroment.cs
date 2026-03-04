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

    public Dictionary<int, BaseTile> doorMap = new Dictionary<int, BaseTile>();

    public Dictionary<string, ISprite> tileMap { get; set; }

    public Environment(TileFactory factory)
    {
        tiles = new List<ISprite[]>();


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
            { "Wall", factory.CreateWallSprite(direction) },
            { "BombedWall", factory.CreateBombedWallSprite(direction)},
            { "OpenDoor", factory.CreateOpenDoorSprite(direction)},
            { "KeyLockedDoor", factory.CreateKeyLockedDoorSprite(direction)},
            { "DiamondLockedDoor", factory.CreateDiamondLockedDoorSprite(direction)},
            { "RoomExterior", factory.CreateRoomExteriorSprite() }
        };

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
        int tileSize = 32;
        int hudHeight = 112;
        int wallOffset = 64; // 2 tiles * 32px

        // Start floor at X:64, Y:112(HUD) + 64(Wall) = 176
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

        // Draw walls starting right under the HUD
        tileMap["RoomExterior"].SpriteDraw(new Vector2(0, hudHeight));
    }
}