using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public class LevelFileReader
{
    private Environment gameEnv;

    public LevelFileReader(Environment gameEnv)
    {
        this.gameEnv = gameEnv;
    }

    // possibly change out string for enum or something
    public void LoadLevel(string filePath)
    {
        Stream stream = TitleContainer.OpenStream(filePath);

        using (StreamReader reader = new StreamReader(stream)) {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                ISprite[] tileRow = new ISprite[cols.Length];

                for (int i = 0; i < cols.Length; i++) { 
                    //gameEnv.tiles.Add(gameEnv.tileMap[col]);
                    tileRow[i] = gameEnv.tileMap[cols[i]];
                    Debug.WriteLine($"Loaded tile: {cols[i]}");
                }
                gameEnv.tiles.Add(tileRow);
            }
        }
    }

}