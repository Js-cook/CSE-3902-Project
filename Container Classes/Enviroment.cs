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
        // fix magic number calculations here
        position = new Vector2(32 * (800/255.0f), 32 * (480 / 175.0f));
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
            position.X = 32 * (800/255.0f);
            position.Y += increment;
        }
        position.Y = 32 * (480 / 175.0f);
        tileMap["RoomExterior"].SpriteDraw(Vector2.Zero);
        //tiles[currentTileIndex].SpriteDraw(position);
    }

    public List<Tile> GetCollidableTiles()
    {
        List<Tile> collidableTiles = new List<Tile>();

        Vector2 gridOffset = new Vector2(32 * (800 / 255.0f), 32 * (480 / 175.0f));
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
                              sprite is StatueSprite ||
                              sprite is KeyLockedDoorSprite ||
                              sprite is DiamondLockedDoorSprite;

                collidableTiles.Add(new Tile(sprite, tilePosition, isSolid));
            }
        }

        // Add boundary walls to prevent player from going off screen
        // The playable area starts at gridOffset, not (0,0)
        // Screen boundaries should be just outside the visible area
        int boundaryThickness = 64;
        int playableLeft = 0;
        int playableTop = 0;
        int playableRight = 800;
        int playableBottom = 480;

        // Top boundary (spanning full width)
        for (int x = playableLeft - boundaryThickness; x < playableRight + boundaryThickness; x += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(x, playableTop - boundaryThickness), true));
        }

        // Bottom boundary (spanning full width)
        for (int x = playableLeft - boundaryThickness; x < playableRight + boundaryThickness; x += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(x, playableBottom), true));
        }

        // Left boundary (spanning full height plus extra)
        for (int y = playableTop - boundaryThickness; y < playableBottom + boundaryThickness; y += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(playableLeft - boundaryThickness, y), true));
        }

        // Right boundary (spanning full height plus extra)
        for (int y = playableTop - boundaryThickness; y < playableBottom + boundaryThickness; y += tileSize)
        {
            collidableTiles.Add(new Tile(null, new Vector2(playableRight, y), true));
        }

        return collidableTiles;
    }
}