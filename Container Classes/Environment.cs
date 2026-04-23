using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Enums;

public class Environment
{
    public List<ISprite[]> tiles { get; set; }
    public List<SpikeTile> spikeTiles { get; set; }
    private Link Player;
    public List<TreasureChest> treasureChests { get; set; }
    public List<Doorway> doorways { get; set; }
    public List<PushableBlock> pushableBlocks { get; set; }
    public Dictionary<int, ISprite> doorMap = new Dictionary<int, ISprite>();
    public Dictionary<string, ISprite> tileMap { get; set; }
    private TileFactory factory;
    public bool IsSecretRoom { get; set; } = false;

    private const int tileSize = 32*2;
    private const int hudHeight = 112*2;
    private const int wallOffset = 64;

    public Environment(TileFactory factory, Link player)
    {
        this.factory = factory;
        tiles = new List<ISprite[]>();
        spikeTiles = new List<SpikeTile>();
        Player = player;
        treasureChests = new List<TreasureChest>();
        doorways = new List<Doorway>();
        pushableBlocks = new List<PushableBlock>();


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
            { "BlackFloor", factory.CreateBlackFloorSprite() },
            { "BlueSand", factory.CreateBlueSandSprite() },
            { "RoomExterior", factory.CreateRoomExteriorSprite() },
            { "LeftStatue", factory.CreateLeftStatueSprite()  },
            { "RightStatue", factory.CreateRightStatueSprite()  }
        };
    }

    public void AssignDoor(int direction, string type, RoomManager roomManager, int row, int col)
    {
        // TEMPORARY DEBUG: Log the door type string
        if (type.Contains("Diamond"))
        {
            System.Diagnostics.Debug.WriteLine($"*** PARSING DIAMOND DOOR: '{type}' at Room ({row},{col}) Direction {direction}");
        }

        // Parse door type and trigger (format: "DiamondLockedDoor:AllEnemies" or just "KeyLockedDoor")
        string[] parts = type.Split(':');
        string doorType = parts[0].Trim(); // Trim whitespace
        DoorTriggerType triggerType = DoorTriggerType.None;

        // Parse trigger type if specified
        if (parts.Length > 1)
        {
            string triggerString = parts[1].Trim(); // Trim whitespace
            triggerType = triggerString switch
            {
                "AllEnemies" => DoorTriggerType.AllEnemies,
                "BlockPushed" => DoorTriggerType.BlockPushed,
                "Boss" => DoorTriggerType.Boss,
                _ => DoorTriggerType.None
            };

            // Debug output
            System.Diagnostics.Debug.WriteLine($"Room ({row},{col}) Dir {direction}: DoorType={doorType}, Trigger={triggerString} => {triggerType}, Parts.Length={parts.Length}");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine($"Room ({row},{col}) Dir {direction}: DoorType={doorType}, NO TRIGGER (parts.Length={parts.Length})");
        }

        // Check if this door was previously unlocked
        bool wasUnlocked = roomManager != null && roomManager.IsDoorUnlocked(row, col, direction);

        // If the door was unlocked, treat it as an open door
        if (wasUnlocked && (doorType == "KeyLockedDoor" || doorType == "DiamondLockedDoor"))
        {
            doorType = "OpenDoor";
        }

        // Track if this was originally a bombed wall (before it might be converted to open)
        bool isBombedWall = doorType == "BombedWall";

        // If bombed wall was unlocked (bombed), keep it as BombedWall type but mark as unlocked
        // This preserves the cracked sprite appearance instead of converting to clean open door
        bool wasBombedWall = false;
        if (wasUnlocked && doorType == "BombedWall")
        {
            wasBombedWall = true;
            isBombedWall = false; // Mark as no longer locked, but preserve sprite
        }

        ISprite sprite = doorType switch
        {
            // Use WallSprite for unopened bombed walls so they look like normal walls
            "BombedWall" when !wasUnlocked => factory.CreateWallSprite(direction),
            // Use BombedWallSprite for bombed walls that have been destroyed (permanent cracked appearance)
            "BombedWall" when wasUnlocked => factory.CreateBombedWallSprite(direction),
            "DiamondLockedDoor" => factory.CreateDiamondLockedDoorSprite(direction),
            "KeyLockedDoor" => factory.CreateKeyLockedDoorSprite(direction),
            "OpenDoor" => factory.CreateOpenDoorSprite(direction),
            _ => factory.CreateWallSprite(direction)
        };
        doorMap[direction] = sprite;

        // Only add actual doors to doorways list, not walls
        // Walls should only be visual sprites, not collidable doorways
        bool isActualDoor = doorType == "OpenDoor" || doorType == "KeyLockedDoor" || doorType == "DiamondLockedDoor" || doorType == "BombedWall";

        if (isActualDoor)
        {
            // BombedWall is locked only if it hasn't been bombed yet
            bool isLocked = (doorType == "KeyLockedDoor" || doorType == "DiamondLockedDoor" || (doorType == "BombedWall" && !wasUnlocked));
            Vector2 pos = GetDoorPosition(direction);

            // Debug output for doorway creation
            System.Diagnostics.Debug.WriteLine($"Creating doorway: Type={doorType}, IsLocked={isLocked}, IsBombedWall={isBombedWall}, TriggerType={triggerType}");

            doorways.Add(new Doorway(sprite, pos, direction, isLocked, isBombedWall, triggerType));
        }
    }

    public Vector2 GetDoorPosition(int direction)
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
        spikeTiles.Add(new SpikeTile(factory.CreateSpikeSprite(), position, Player));
    }

    public void AddTreasureChest(Vector2 position)
    {
        treasureChests.Add(new TreasureChest(factory.CreateTreasureChestSprite(), position));
    }

    public void AddPushableBlock(Vector2 position, HashSet<int> allowedDirections = null)
    {
        pushableBlocks.Add(new PushableBlock(factory.CreatePushSquareBlockSprite(), position, allowedDirections));
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

        foreach (SpikeTile spike in spikeTiles)
        {
            spike.Update(gameTime);
        }

        treasureChests.RemoveAll(chest => chest.IsOpened); // Remove opened chests from the list before next update/draw loop


    }

    public void Draw()
    {

        Vector2 currentPos = IsSecretRoom ? new Vector2(0, hudHeight) : new Vector2(wallOffset*2, (hudHeight + wallOffset*2));
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

        if (!IsSecretRoom)
        {
            tileMap["RoomExterior"].SpriteDraw(new Vector2(0, hudHeight));
        }

        foreach (SpikeTile spike in spikeTiles)
        {
            spike.Sprite.SpriteDraw(spike.Position);
        }
        foreach (TreasureChest chest in treasureChests)
        {
            chest.Sprite.SpriteDraw(chest.Position);
        }
        foreach (PushableBlock block in pushableBlocks)
        {
            block.Draw();
        }

        // Draw doorways directly so sprite changes (like bombing) are immediately visible
        foreach (Doorway doorway in doorways)
        {
            doorway.Sprite.SpriteDraw(doorway.Position);
        }

        // Also draw any door sprites that don't have doorway objects (like walls)
        foreach (var kvp in doorMap)
        {
            if (!doorways.Exists(d => d.Direction == kvp.Key))
            {
                kvp.Value.SpriteDraw(GetDoorPosition(kvp.Key));
            }
        }
    }

    public List<ICollidable> GetCollidableTiles()
    {
        List<ICollidable> collidableTiles = new List<ICollidable>();

        Vector2 gridOffset = IsSecretRoom ? new Vector2(0, hudHeight) : new Vector2(wallOffset*2, hudHeight + wallOffset*2); // Match Draw() calculation
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

                Tile tile = new Tile(sprite, tilePosition, isSolid);
                tile.BlocksProjectiles = isSolid;
                if (sprite is BlueGapSprite)
                {
                    tile.BlocksProjectiles = false;
                }
                collidableTiles.Add(tile);
            }
        }

        // Add boundary walls to contain player within the floor tile area
        // The floor tiles start at gridOffset and form the playable area
        // Calculate boundaries based on actual tile grid dimensions

        if (tiles.Count == 0)
            return collidableTiles; // No tiles loaded yet

        if (IsSecretRoom)
            return collidableTiles; // No boundaries for secret room

        int numCols = tiles[0].Length;
        int numRows = tiles.Count;

        // Calculate the actual floor area boundaries
        int floorLeft = (int)gridOffset.X;
        int floorTop = (int)gridOffset.Y;
        int floorRight = floorLeft + (numCols * scaledTileSize);
        int floorBottom = floorTop + (numRows * scaledTileSize);

        int wallThickness = 64; // Use scaled wall thickness

        // Top boundary - leave gap if top door exists (open or locked)
        for (int x = floorLeft - wallThickness; x <= floorRight + wallThickness; x += scaledTileSize)
        {
            bool inTopDoorGap = false;

            if (HasDoor(0))
            {
                Vector2 topDoorPos = GetDoorPosition(0);

                int gapLeft = (int)topDoorPos.X;
                int gapRight = gapLeft + 2 * scaledTileSize;

                inTopDoorGap = x >= gapLeft && x < gapRight;
            }

            if (!inTopDoorGap)
            {
                Tile boundaryTile = new Tile(null, new Vector2(x, floorTop - wallThickness), true);
                boundaryTile.BlocksProjectiles = true;
                collidableTiles.Add(boundaryTile);
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
                Tile boundaryTile = new Tile(null, new Vector2(x, floorBottom), true);
                boundaryTile.BlocksProjectiles = true;
                collidableTiles.Add(boundaryTile);
            }
        }
        // Left boundary - leave gap if left door exists (open or locked)
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += scaledTileSize)
        {
            bool inLeftDoorGap = false;

            if (HasDoor(3))
            {
                Vector2 leftDoorPos = GetDoorPosition(3);

                int gapTop = (int)leftDoorPos.Y;
                int gapBottom = gapTop + scaledTileSize;

                inLeftDoorGap = y >= gapTop && y < gapBottom;
            }

            if (!inLeftDoorGap)
            {
                Tile boundaryTile = new Tile(null, new Vector2(floorLeft - wallThickness, y), true);
                boundaryTile.BlocksProjectiles = true;
                collidableTiles.Add(boundaryTile);
            }
        }

        // Right boundary - leave gap if right door exists (open or locked)
        for (int y = floorTop - wallThickness; y <= floorBottom + wallThickness; y += scaledTileSize)
        {
            bool inRightDoorGap = false;

            if (HasDoor(1))
            {
                Vector2 rightDoorPos = GetDoorPosition(1);

                int gapTop = (int)rightDoorPos.Y;
                int gapBottom = gapTop + scaledTileSize;

                inRightDoorGap = y >= gapTop && y < gapBottom;
            }

            if (!inRightDoorGap)
            {
                Tile boundaryTile = new Tile(null, new Vector2(floorRight, y), true);
                boundaryTile.BlocksProjectiles = true;
                collidableTiles.Add(boundaryTile);
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
        foreach (PushableBlock block in pushableBlocks)
        {
            collidableTiles.Add(block);
        }
        foreach (Doorway doorway in doorways)
        {
            collidableTiles.Add(doorway);
        }
        return collidableTiles;
    }
}