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
    public List<SpikeTile> spikeTiles { get; set; }
    public List<TreasureChest> treasureChests { get; set; }
    public List<Doorway> doorways { get; set; }
    public Dictionary<int, ISprite> doorMap = new Dictionary<int, ISprite>();
    public Dictionary<string, ISprite> tileMap { get; set; }
    private TileFactory factory;

    private const int tileSize = 32*2;
    private const int hudHeight = 112*2;
    private const int wallOffset = 64;

    public Environment(TileFactory factory)
    {
        this.factory = factory;
        tiles = new List<ISprite[]>();
        spikeTiles = new List<SpikeTile>();
        treasureChests = new List<TreasureChest>();
        doorways = new List<Doorway>();


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

    public void AssignDoor(int direction, string type, RoomManager roomManager, int row, int col)
    {
        // Check if this door was previously unlocked
        bool wasUnlocked = roomManager != null && roomManager.IsDoorUnlocked(row, col, direction);

        // If the door was unlocked, treat it as an open door
        if (wasUnlocked && (type == "KeyLockedDoor" || type == "DiamondLockedDoor"))
        {
            type = "OpenDoor";
        }

        ISprite sprite = type switch
        {
            "BombedWall" => factory.CreateBombedWallSprite(direction),
            "DiamondLockedDoor" => factory.CreateDiamondLockedDoorSprite(direction),
            "KeyLockedDoor" => factory.CreateKeyLockedDoorSprite(direction),
            "OpenDoor" => factory.CreateOpenDoorSprite(direction),
            _ => factory.CreateWallSprite(direction)
        };
        doorMap[direction] = sprite;

        // Only actual door types should be unlockable, not walls
        bool isLocked = type == "KeyLockedDoor" || type == "DiamondLockedDoor";
        Vector2 pos = GetDoorPosition(direction);

        doorways.Add(new Doorway(sprite, pos, direction, isLocked));
    }

    private Vector2 GetDoorPosition(int direction)
    {
        return direction switch
        {
            0 => new Vector2(224*2, 112 * 2),
            1 => new Vector2(448 * 2, 256 * 2),
            2 => new Vector2(224 * 2, 400 * 2),
            3 => new Vector2(0, 256 * 2),
            _ => Vector2.Zero
        };
    }
    public void AddSpike(Vector2 position)
    {
        spikeTiles.Add(new SpikeTile(factory.CreateSpikeSprite(), position));
    }

    public void AddTreasureChest(Vector2 position)
    {
        treasureChests.Add(new TreasureChest(factory.CreateTreasureChestSprite(), position));
    }
    private bool IsOpenDoor(int direction)
    {
        return doorways.Exists(d => d.Direction == direction && !d.IsLocked);
    }

    private bool HasDoor(int direction)
    {
        return doorways.Exists(d => d.Direction == direction);
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

        Vector2 currentPos = new Vector2(wallOffset*2, (hudHeight + wallOffset*2));
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
        
        foreach (SpikeTile spike in spikeTiles)
        {
            spike.Sprite.SpriteDraw(spike.Position);
        }
        foreach (TreasureChest chest in treasureChests)
        {
            chest.Sprite.SpriteDraw(chest.Position);
        }

        foreach (var kvp in doorMap)
        {
            kvp.Value.SpriteDraw(GetDoorPosition(kvp.Key));
        }
    }

    public List<ICollidable> GetCollidableTiles()
    {
        List<ICollidable> collidableTiles = new List<ICollidable>();

        Vector2 gridOffset = new Vector2(wallOffset*2, hudHeight + wallOffset*2); // Match Draw() calculation
        int scaledTileSize = tileSize; // Use the constant which is already scaled (32*2 = 64)

        for (int row = 0; row < tiles.Count; row++)
        {
            for (int col = 0; col < tiles[row].Length; col++)
            {
                ISprite sprite = tiles[row][col];
                Vector2 tilePosition = new Vector2(
                    gridOffset.X + (col * scaledTileSize),
                    gridOffset.Y + (row * scaledTileSize)
                );

                // Determine if tile is solid (blocks player movement)
                // Note: Door sprites are NOT checked here because doors are handled
                // as Doorway objects with their own collision logic
                bool isSolid = sprite is WallSprite ||
                              sprite is SquareBlockSprite ||
                              sprite is PushSquareBlockSprite ||
                              sprite is WhiteBrickSprite ||
                              sprite is LeftStatueSprite ||
                              sprite is RightStatueSprite ||
                              sprite is BlueGapSprite;

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
        int floorRight = floorLeft + (numCols * scaledTileSize);
        int floorBottom = floorTop + (numRows * scaledTileSize);

        int wallThickness = 64; // Use scaled wall thickness

        // Top boundary - leave gap if top door is open
        for (int x = floorLeft - wallThickness; x <= floorRight + wallThickness; x += scaledTileSize)
        {
            bool inTopDoorGap = false;

            if (IsOpenDoor(0))
            {
                Vector2 topDoorPos = GetDoorPosition(0);

                int gapLeft = (int)topDoorPos.X;
                int gapRight = gapLeft + 2 * scaledTileSize;

                inTopDoorGap = x >= gapLeft && x < gapRight;
            }

            if (!inTopDoorGap)
            {
                collidableTiles.Add(new Tile(null, new Vector2(x, floorTop - wallThickness), true));
            }
        }

        // Bottom boundary - leave gap if bottom door exists (open or locked)
        for (int x = floorLeft - wallThickness; x <= floorRight + wallThickness; x += scaledTileSize)
        {
            bool inBottomDoorGap = false;

            if (HasDoor(2))
            {
                Vector2 bottomDoorPos = GetDoorPosition(2);

                int gapLeft = (int)bottomDoorPos.X;
                int gapRight = gapLeft + 2 * scaledTileSize;

                inBottomDoorGap = x >= gapLeft && x < gapRight;
            }

            if (!inBottomDoorGap)
            {
                collidableTiles.Add(new Tile(null, new Vector2(x, floorBottom), true));
            }
        }
        // Left boundary - leave gap if left door exists (open or locked)
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += scaledTileSize)
        {
            bool inLeftDoorGap = HasDoor(3) && y >= floorTop + 2 * scaledTileSize && y <= floorTop + 3 * scaledTileSize;

            if (!inLeftDoorGap)
            {
                collidableTiles.Add(new Tile(null, new Vector2(floorLeft - wallThickness, y), true));
            }
        }

        // Right boundary - leave gap if right door exists (open or locked)
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += scaledTileSize)
        {
            bool inRightDoorGap = HasDoor(1) && y >= floorTop + 2 * scaledTileSize && y <= floorTop + 3 * scaledTileSize;

            if (!inRightDoorGap)
            {
                collidableTiles.Add(new Tile(null, new Vector2(floorRight, y), true));
            }
        }
        foreach (SpikeTile spike in spikeTiles)
        {
            collidableTiles.Add(spike);
        }
        foreach (TreasureChest chest in treasureChests)
        {
            collidableTiles.Add(chest);
        }
        foreach (Doorway doorway in doorways)
        {
            collidableTiles.Add(doorway);
        }
        return collidableTiles;
    }
}