using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using System;
using Controllers;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;

public class LevelFileReader
{
    private Environment gameEnv;
    private EnemyLoader enemyLoader;
    private RoomManager _roomManager;
    private ItemController itemController;
    private Link playerRef;

    public LevelFileReader(Environment gameEnv, EnemyLoader enemyLoader, ItemController itemController = null, Link playerRef = null)
    {
        this.gameEnv = gameEnv;
        this.enemyLoader = enemyLoader;
        this.itemController = itemController;
        this.playerRef = playerRef;
    }

    public void SetRoomManager(RoomManager roomManager)
    {
        this._roomManager = roomManager;
    }

    public bool LoadLevel(int row, int col, RoomManager roomManager, bool spawnEnemies = true)
    {
        RoomDefinition roomDef = RoomsRepository.GetRoom(row, col);

        if (roomDef == null)
        {
            Debug.WriteLine($"Room {row},{col} not found");
            return false;
        }

        gameEnv.tiles.Clear();
        gameEnv.doorMap.Clear();
        gameEnv.spikeTiles.Clear();
        gameEnv.treasureChests.Clear();
        gameEnv.doorways.Clear();
        gameEnv.pushableBlocks.Clear();
        // Clear any items from previous room so items don't persist across rooms
        if (itemController != null)
        {
            itemController.ClearItems();
        }

        // Load tiles from room definition
        foreach (var tileRow in roomDef.Tiles)
        {
            ISprite[] spriteRow = new ISprite[tileRow.Length];
            for (int i = 0; i < tileRow.Length; i++)
            {
                string key = tileRow[i];
                if (key == "Spike")
                {
                    spriteRow[i] = gameEnv.tileMap["BlueFloor"];
                    // Add spike as a separate overlay
                    Vector2 spikePosition = new Vector2(
                        64 * 2 + (i * (32 * 2)),
                        112 * 2 + 64 * 2 + ((gameEnv.tiles.Count) * (32 * 2)));
                    gameEnv.AddSpike(spikePosition);
                }
                else if (key == "TreasureChest")
                {
                    spriteRow[i] = gameEnv.tileMap["BlueFloor"];

                    const int tileSize = 32 * 2;
                    const int hudHeight = 112 * 2;
                    const int wallOffset = 64;

                    Vector2 chestPosition = new Vector2(
                        wallOffset * 2 + (i * tileSize),
                        hudHeight + wallOffset * 2 + (gameEnv.tiles.Count * tileSize)
                    );

                    gameEnv.AddTreasureChest(chestPosition);
                }
                else if (key == "PushSquareBlock")
                {
                    spriteRow[i] = gameEnv.tileMap["BlueFloor"];

                    const int tileSize = 32 * 2;
                    const int hudHeight = 112 * 2;
                    const int wallOffset = 64;

                    Vector2 blockPosition = new Vector2(
                        wallOffset * 2 + (i * tileSize),
                        hudHeight + wallOffset * 2 + (gameEnv.tiles.Count * tileSize)
                    );

                    gameEnv.AddPushableBlock(blockPosition);
                }
                else if (gameEnv.tileMap.ContainsKey(key))
                {
                    spriteRow[i] = gameEnv.tileMap[key];
                }
            }
            gameEnv.tiles.Add(spriteRow);
        }

        // Load doors from room definition
        var directionMap = new Dictionary<string, int>
        {
            { "Top", 0 },
            { "Right", 1 },
            { "Bottom", 2 },
            { "Left", 3 }
        };

        foreach (var doorEntry in roomDef.Doors)
        {
            int direction = directionMap[doorEntry.Key];
            string type = doorEntry.Value;
            gameEnv.AssignDoor(direction, type, roomManager, row, col);
        }

        // Load enemies
        if (spawnEnemies)
        {
            enemyLoader.LoadEnemiesFromRoom(roomDef.Enemies, playerRef, roomManager);
        }
        else
        {
            enemyLoader.ClearEnemies();
        }
        // Load pickup items (if any)
        if (roomDef.PickupItems != null && roomDef.PickupItems.Count > 0 && itemController != null)
        {
            const int tileSize = 32 * 2;
            const int hudHeight = 112 * 2;
            const int wallOffset = 64;
            Vector2 gridOffset = new Vector2(wallOffset * 2, hudHeight + wallOffset * 2);

            foreach (var itemDef in roomDef.PickupItems)
            {
                // Skip items that were already collected
                if (itemDef.Acquired) continue;

                float x = gridOffset.X + (itemDef.X * tileSize);
                float y = gridOffset.Y + (itemDef.Y * tileSize);
                Vector2 position = new Vector2(x, y);
                // Spawn with room and grid info so collection can be persisted
                itemController.SpawnItem(itemDef.Type, position, row, col, itemDef.X, itemDef.Y);
            }
        }
        return true;
    }
}