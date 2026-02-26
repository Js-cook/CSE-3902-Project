using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

public class LevelFileReader
{
    private TileFactory tileFactory;
    private List<ISprite> levelContent = new();

    public LevelFileReader(TileFactory tileFactory)
    {
        this.tileFactory = tileFactory;
    }

    // possibly change out string for enum or something
    public void LoadLevel(string filePath)
    {

    }

}