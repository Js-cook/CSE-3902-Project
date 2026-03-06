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

    public List<Tile> GetCollidableTiles()
    {
        List<Tile> collidableTiles = new List<Tile>();

        Vector2 gridOffset = new Vector2(wallOffset, hudHeight + wallOffset); // Match Draw() calculation
        int tileSize = 32;

        for (int row = 0; row < tiles.Count; row++)
        {
            for (int col = 0; col < tiles[row].Length; col++)
            {
                ISprite sprite = tiles[row][col];
                Vector2 tilePosition = new Vector2(
                    gridOffset.X + (col * tileSize),
                    gridOffset.Y + (row * tileSize)
                );

                // Determine if tile is solid (blocks player movement)
                bool isSolid = sprite is WallSprite ||
                              sprite is SquareBlockSprite ||
                              sprite is PushSquareBlockSprite ||
                              sprite is WhiteBrickSprite ||
                              sprite is LeftStatueSprite ||
                              sprite is RightStatueSprite ||
                              sprite is KeyLockedDoorSprite ||
                              sprite is DiamondLockedDoorSprite;

                collidableTiles.Add(new Tile(sprite, tilePosition, isSolid));
            }
        }

        // Add boundary walls to contain player within the floor tile area
        // The floor tiles start at gridOffset and form the playable area
        // Calculate boundaries based on actual tile grid dimensions

        if (tiles.Count == 0)
            return collidableTiles; // No tiles loaded yet

        int numCols = tiles[0].Length;
        int numRows = tiles.Count;

        // Calculate the actual floor area boundaries
        int floorLeft = (int)gridOffset.X;
        int floorTop = (int)gridOffset.Y;
        int floorRight = floorLeft + (numCols * tileSize);
        int floorBottom = floorTop + (numRows * tileSize);

        int wallThickness = 32;

        // Top boundary - just above the floor area
        for (int x = floorLeft - wallThickness; x <= floorRight + wallThickness; x += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(x, floorTop - wallThickness), true));
        }

        // Bottom boundary - just below the floor area
        for (int x = floorLeft - wallThickness; x <= floorRight + wallThickness; x += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(x, floorBottom), true));
        }

        // Left boundary - along the left side of floor area
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(floorLeft - wallThickness, y), true));
        }

        // Right boundary - along the right side of floor area
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(floorRight, y), true));
        }

        return collidableTiles;
    }
}