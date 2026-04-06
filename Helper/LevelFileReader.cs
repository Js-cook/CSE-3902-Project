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
    private RoomManager roomManager;

    public LevelFileReader(Environment gameEnv, EnemyLoader enemyLoader)
    {
        this.gameEnv = gameEnv;
        this.enemyLoader = enemyLoader;
    }

    public void SetRoomManager(RoomManager roomManager)
    {
        this.roomManager = roomManager;
    }

    public bool LoadLevel(string filePath, int row, int col, bool spawnEnemies = true)
    {
        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            XDocument doc = XDocument.Load(stream);

            var roomNode = doc.Descendants("Room")
            .FirstOrDefault(r => (int)r.Attribute("row") == row &&
                                 (int)r.Attribute("col") == col);

            if (roomNode == null)
            {
                Debug.WriteLine($"Room {row},{col} not found in {filePath}");
                return false;
            }

            gameEnv.tiles.Clear();
            gameEnv.doorMap.Clear();
            gameEnv.spikeTiles.Clear();
            gameEnv.treasureChests.Clear();
            gameEnv.doorways.Clear();

            var tileRows = roomNode.Descendants("Tiles").Descendants("row");
            foreach (var rowElement in tileRows)
            {
                string[] cols = rowElement.Value.Trim().Split(',');
                if (cols.Length > 0 && !string.IsNullOrWhiteSpace(cols[0]))
                {
                    ISprite[] tileRow = new ISprite[cols.Length];
                    for (int i = 0; i < cols.Length; i++)
                    {
                        string key = cols[i].Trim();
                        if (key == "Spike")
                        {
                            tileRow[i] = gameEnv.tileMap["BlueFloor"];
                            // Add spike as a separate overlay
                            Vector2 spikePosition = new Vector2(
                                64 * 2 + (i * (32 * 2)),
                                112 * 2 + 64 * 2 + ((gameEnv.tiles.Count) * (32 * 2)));
                            gameEnv.AddSpike(spikePosition);
                        }
                        else if(key == "TreasureChest")
                        {
                            tileRow[i] = gameEnv.tileMap["BlueFloor"];

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
                            tileRow[i] = gameEnv.tileMap[key];
                        }
                    }
                    gameEnv.tiles.Add(tileRow);
                }
            }

            var doors = roomNode.Descendants("Doors").Elements();
            foreach (var door in doors)
            {
                int direction = door.Name.LocalName switch
                {
                    "Top" => 0,
                    "Right" => 1,
                    "Bottom" => 2,
                    "Left" => 3,
                    _ => 0
                };
                string type = door.Attribute("type").Value;
                gameEnv.AssignDoor(direction, type, roomManager, row, col);
            }
            if (spawnEnemies)
            {
                enemyLoader.LoadEnemiesFromRoom(roomNode);
            }
            else
            {
                enemyLoader.ClearEnemies();
            }
            return true;
        }
    }
}