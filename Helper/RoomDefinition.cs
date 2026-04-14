using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class RoomDefinition
{
    public int Row { get; set; }
    public int Col { get; set; }
    public string[][] Tiles { get; set; }
    public Dictionary<string, string> Doors { get; set; }
    public List<EnemyDefinition> Enemies { get; set; }

    public List<ItemDefinition> PickupItems { get; set; }

    public RoomDefinition(int row, int col, string[][] tiles, Dictionary<string, string> doors, List<EnemyDefinition> enemies = null, List<ItemDefinition> items = null)
    {
        Row = row;
        Col = col;
        Tiles = tiles;
        Doors = doors;
        PickupItems = items ?? new List<ItemDefinition>();
        Enemies = enemies ?? new List<EnemyDefinition>();
    }
}