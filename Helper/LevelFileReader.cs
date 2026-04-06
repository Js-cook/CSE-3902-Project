using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;

public class LevelFileReader
{
    private Environment gameEnv;
    private EnemyLoader enemyLoader;

    public LevelFileReader(Environment gameEnv, EnemyLoader enemyLoader)
    {
        this.gameEnv = gameEnv;
        this.enemyLoader = enemyLoader;
    }

    public bool LoadLevel(int row, int col, bool spawnEnemies = true)
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
            gameEnv.AssignDoor(direction, type);
        }

        // Load enemies
        if (spawnEnemies)
        {
            enemyLoader.LoadEnemiesFromRoom(roomDef.Enemies);
        }
        else
        {
            enemyLoader.ClearEnemies();
        }
        return true;
    }
}