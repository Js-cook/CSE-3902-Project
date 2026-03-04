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

    public LevelFileReader(Environment gameEnv)
    {
        this.gameEnv = gameEnv;
    }

    public void LoadLevel(string filePath)
    {
        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            XDocument doc = XDocument.Load(stream);

            var tileRows = doc.Descendants("Tiles").Descendants("row");

            foreach (var rowElement in tileRows)
            {
                string[] cols = rowElement.Value.Trim().Split(',');

                if (cols.Length > 0 && !string.IsNullOrWhiteSpace(cols[0]))
                {
                    ISprite[] tileRow = new ISprite[cols.Length];

                    for (int i = 0; i < cols.Length; i++)
                    {
                        string tileKey = cols[i].Trim();
                        if (gameEnv.tileMap.ContainsKey(tileKey))
                        {
                            tileRow[i] = gameEnv.tileMap[tileKey];
                        }
                    }
                    gameEnv.tiles.Add(tileRow);
                }
            
            }

            // 3. PARSE DOORS and store in gameEnv
            var doors = doc.Descendants("Doors").Elements();
            foreach (var door in doors)
            {
                string sideName = door.Name.LocalName;
                string type = door.Attribute("type")?.Value;

                int direction = sideName switch
                {
                    "Top" => 0,
                    "Right" => 1,
                    "Bottom" => 2,
                    "Left" => 3,
                    _ => 0
                };

                // Create the door and store it immediately in gameEnv
                gameEnv.doorMap[direction] = type switch
                {
                    "BombedWall" => gameEnv.factory.CreateBombedWallSprite(direction),
                    "DiamondLockedDoor" => gameEnv.factory.CreateDiamondLockedDoorSprite(direction),
                    "KeyLockedDoor" => gameEnv.factory.CreateKeyLockedDoorSprite(direction),
                    "OpenDoor" => gameEnv.factory.CreateOpenDoorSprite(direction),
                    _ => gameEnv.factory.CreateWallSprite(direction)
                };
            }
        }
    }
}