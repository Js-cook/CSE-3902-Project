using Enums;
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
public class EnemyDefinition
{
    public string Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int count { get; set; } // used for wallmaster manager

    public EnemyDefinition(string type, int x, int y, int count = 1)
    {
        Type = type;
        X = x;
        Y = y;
        this.count = count;
    }
}

public class ItemDefinition
{
    public ItemType Type { get; set; }
    public bool Acquired { get; set; } = false;
    public int X { get; set; }
    public int Y { get; set; }
    public ItemDefinition(ItemType type, int x, int y)
    {
        Type = type;
        X = x;
        Y = y;
    }
}

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

// compass in 3,3 map is in 2, 2

public static class RoomsRepository
{
    private static Dictionary<(int, int), RoomDefinition> _rooms;

    static RoomsRepository()
    {
        _rooms = new Dictionary<(int, int), RoomDefinition>();

        string filePath = Path.Combine("Content", "RoomData.xml");

        Debug.WriteLine(filePath);

        using (XmlReader reader = XmlReader.Create(filePath))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Room")
                {
                    int row = int.Parse(reader.GetAttribute("row"));
                    int col = int.Parse(reader.GetAttribute("col"));

                    string[][] tiles = null;
                    var doors = new Dictionary<string, string>();
                    var enemies = new List<EnemyDefinition>();
                    var items = new List<ItemDefinition>();

                    using (XmlReader roomReader = reader.ReadSubtree())
                    {
                        while (roomReader.Read())
                        {
                            // -------- TILES --------
                            if (roomReader.NodeType == XmlNodeType.Element && roomReader.Name == "Tiles")
                            {
                                var tileRows = new List<string[]>();

                                using (XmlReader tileReader = roomReader.ReadSubtree())
                                {
                                    while (tileReader.Read())
                                    {
                                        if (tileReader.NodeType == XmlNodeType.Element && tileReader.Name == "row")
                                        {
                                            string rowData = tileReader.ReadElementContentAsString();
                                            string[] tilesSplit = rowData.Split(',');
                                            tileRows.Add(tilesSplit);
                                        }
                                    }
                                }

                                tiles = tileRows.ToArray();
                            }

                            // -------- DOORS --------
                            if (roomReader.NodeType == XmlNodeType.Element && roomReader.Name == "Doors")
                            {
                                using (XmlReader doorReader = roomReader.ReadSubtree())
                                {
                                    while (doorReader.Read())
                                    {
                                        if (doorReader.NodeType == XmlNodeType.Element)
                                        {
                                            if (doorReader.Name == "Top" ||
                                                doorReader.Name == "Right" ||
                                                doorReader.Name == "Bottom" ||
                                                doorReader.Name == "Left")
                                            {
                                                string type = doorReader.GetAttribute("type");
                                                doors[doorReader.Name] = type;
                                            }
                                        }
                                    }
                                }
                            }

                            // -------- ENEMIES --------
                            if (roomReader.NodeType == XmlNodeType.Element && roomReader.Name == "Enemy")
                            {
                                string type = roomReader.GetAttribute("type");

                                // Default to 0 if parsing fails
                                int.TryParse(roomReader.GetAttribute("x"), out int x);
                                int.TryParse(roomReader.GetAttribute("y"), out int y);

                                // Default count to 1 if not specified or parsing fails
                                int count = 1;
                                string countAttribute = roomReader.GetAttribute("count");
                                if (!string.IsNullOrEmpty(countAttribute))
                                {
                                    int.TryParse(countAttribute, out count);
                                }

                                enemies.Add(new EnemyDefinition(type, x, y, count));
                            }

                            if (roomReader.NodeType == XmlNodeType.Element && roomReader.Name == "Items")
                            {
                                using (XmlReader itemReader = roomReader.ReadSubtree())
                                {
                                    while (itemReader.Read())
                                    {
                                        if (itemReader.NodeType == XmlNodeType.Element && itemReader.Name == "Item")
                                        {
                                            string typeStr = itemReader.GetAttribute("type");
                                            int x = int.Parse(itemReader.GetAttribute("x"));
                                            int y = int.Parse(itemReader.GetAttribute("y"));

                                            if (Enum.TryParse(typeStr, out ItemType type))
                                            {
                                                items.Add(new ItemDefinition(type, x, y));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    var roomDef = new RoomDefinition(row, col, tiles, doors, enemies, items);
                    _rooms[(row, col)] = roomDef;
                }
            }
        }
    }

    public static RoomDefinition GetRoom(int row, int col)
    {
        return _rooms.TryGetValue((row, col), out var room) ? room : null;
    }
}
