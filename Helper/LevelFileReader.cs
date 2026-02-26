using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;

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
        using (StreamReader reader = new StreamReader(filePath)) {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');

                foreach (string col in cols) { 
                    gameEnv.tiles.Add(gameEnv.tileMap[col]);
                }
            }
        }
    }

}