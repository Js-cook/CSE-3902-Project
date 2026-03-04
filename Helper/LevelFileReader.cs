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

            gameEnv.tiles.Clear();
            gameEnv.doorMap.Clear();

            var tileRows = doc.Descendants("Tiles").Descendants("row");
            foreach (var rowElement in tileRows)
            {
                string[] cols = rowElement.Value.Trim().Split(',');
                if (cols.Length > 0 && !string.IsNullOrWhiteSpace(cols[0]))
                {
                    ISprite[] tileRow = new ISprite[cols.Length];
                    for (int i = 0; i < cols.Length; i++)
                    {
                        string key = cols[i].Trim();
                        if (gameEnv.tileMap.ContainsKey(key))
                        {
                            tileRow[i] = gameEnv.tileMap[key];
                        }
                    }
                    gameEnv.tiles.Add(tileRow);
                }
            }

            var doors = doc.Descendants("Doors").Elements();
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
                gameEnv.AssignDoor(direction, type);
            }
        }
    }
}