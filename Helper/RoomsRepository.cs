using Enums;
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

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
<<<<<<< HEAD

    private static RoomDefinition CreateRoom99_99()
    {
        var tiles = new string[][]
        {
            new string[] { "Spike", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "Spike" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "PushSquareBlock", "BlueFloor", "Stair", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "TreasureChest", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "Spike", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "Spike" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "Wall" }, { "Bottom", "Wall" }, { "Left", "Wall" } };

        return new RoomDefinition(99, 99, tiles, doors);
    }

    private static RoomDefinition CreateRoom0_1()
    {
        var tiles = new string[][]
        {
            new string[] { "Spike", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "Spike" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "PushSquareBlock", "BlueFloor", "Stair", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "TreasureChest", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "Spike", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "Spike" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "KeyLockedDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };

        return new RoomDefinition(0, 1, tiles, doors);
    }

    private static RoomDefinition CreateRoom0_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueFloor" },
            new string[] { "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor" },
            new string[] { "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor" },
            new string[] { "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor" },
            new string[] { "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "Wall" }, { "Bottom", "KeyLockedDoor" }, { "Left", "KeyLockedDoor" } };
        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Goriya", 7, 0),
            new EnemyDefinition("Goriya", 6, 2),
            new EnemyDefinition("Goriya", 7, 4),
        };

        // TODO - Item logic is missing from other classes
        var items = new List<ItemDefinition>
        {
            new ItemDefinition(ItemType.Key, 6, 1)
        };
        return new RoomDefinition(0, 2, tiles, doors, enemies, items);
    }

    private static RoomDefinition CreateRoom1_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueFloor", "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap" },
            new string[] { "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap" },
            new string[] { "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor" },
            new string[] { "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueGap" },
            new string[] { "BlueGap", "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap", "BlueFloor", "BlueFloor", "BlueFloor", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueFloor", "BlueFloor", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
        };
        var doors = new Dictionary<string, string> { { "Top", "KeyLockedDoor" }, { "Right", "Wall" }, { "Bottom", "OpenDoor" }, { "Left", "Wall" } };
        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Skeleton", 1, 1),
            new EnemyDefinition("Skeleton", 3, 4),
            new EnemyDefinition("Skeleton", 8, 1),
        };
        return new RoomDefinition(1, 2, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom2_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "OpenDoor" }, { "Right", "KeyLockedDoor" }, { "Bottom", "BombedWall" }, { "Left", "OpenDoor" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Gel", 1, 0),
            new EnemyDefinition("Gel", 9, 2),
            new EnemyDefinition("Gel", 2, 4),
            new EnemyDefinition("Gel", 9, 6),
        };
        return new RoomDefinition(2, 2, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom2_1()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "PushSquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "KeyLockedDoor" }, { "Left", "DiamondLockedDoor:BlockPushed" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Gel", 1, 3),
            new EnemyDefinition("Gel", 5, 0),
            new EnemyDefinition("Gel", 5, 5),
        };
        return new RoomDefinition(2, 1, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom2_0()
    {
        var tiles = new string[][]
        {
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
            new string[] { "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor", "BlackFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("OldMan", 5, 3),
        };

        return new RoomDefinition(2, 0, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom3_1()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "KeyLockedDoor" }, { "Right", "DiamondLockedDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Bat", 1, 3),
            new EnemyDefinition("Bat", 5, 9),
            new EnemyDefinition("Bat", 5, 2),
            new EnemyDefinition("Bat", 1, 3),
            new EnemyDefinition("Bat", 5, 0),
            new EnemyDefinition("Bat", 3, 5),
        };
        return new RoomDefinition(3, 1, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom3_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "BombedWall" }, { "Right", "OpenDoor" }, { "Bottom", "OpenDoor" }, { "Left", "OpenDoor" } };
        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Skeleton", 1, 3),
            new EnemyDefinition("Skeleton", 2, 4),
            new EnemyDefinition("Skeleton", 5, 2),
            new EnemyDefinition("Skeleton", 4, 3),
            new EnemyDefinition("Skeleton", 5, 0),
  
        };
        return new RoomDefinition(3, 2, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom4_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "OpenDoor" }, { "Right", "Wall" }, { "Bottom", "KeyLockedDoor" }, { "Left", "Wall" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Skeleton", 1, 3),
            new EnemyDefinition("Skeleton", 2, 4),
            new EnemyDefinition("Skeleton", 5, 2),
           

        };
        return new RoomDefinition(4, 2, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom5_1()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Bat", 1, 3),
            new EnemyDefinition("Bat", 2, 4),
            new EnemyDefinition("Bat", 5, 2),


        };
        return new RoomDefinition(5, 1, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom5_2()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueSand", "BlueSand", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "LeftStatue", "BlueFloor", "BlueSand", "LeftStatue", "BlueSand", "BlueSand", "RightStatue", "BlueSand", "BlueFloor", "RightStatue", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueSand", "BlueSand", "BlueSand", "BlueSand", "BlueSand", "BlueSand", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "KeyLockedDoor" }, { "Right", "OpenDoor" }, { "Bottom", "OpenDoor" }, { "Left", "OpenDoor" } };
        return new RoomDefinition(5, 2, tiles, doors);
    }

    private static RoomDefinition CreateRoom2_3()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "BombedWall" }, { "Left", "KeyLockedDoor" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Goriya", 1, 3),
            new EnemyDefinition("Goriya", 5, 0),
            new EnemyDefinition("Goriya", 5, 5),
        };
        return new RoomDefinition(2, 3, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom3_3()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "BombedWall" }, { "Right", "Wall" }, { "Bottom", "Wall" }, { "Left", "OpenDoor" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Bat", 1, 3),
            new EnemyDefinition("Bat", 5, 9),
            new EnemyDefinition("Bat", 5, 2),
            new EnemyDefinition("Bat", 3, 3),
            new EnemyDefinition("Bat", 5, 0),
            new EnemyDefinition("Bat", 3, 5),
        };
        return new RoomDefinition(3, 3, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom5_3()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "Wall" }, { "Bottom", "Wall" }, { "Left", "OpenDoor" } };
       
        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Skeleton", 1, 3),
            
            new EnemyDefinition("Skeleton", 5, 2),
           
            new EnemyDefinition("Skeleton", 2, 5),


        };

        return new RoomDefinition(5, 3, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom1_4()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "DiamondLockedDoor:Boss" }, { "Bottom", "DiamondLockedDoor:Boss" }, { "Left", "Wall" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Aquamentus", 6, 3),
          
        };
        return new RoomDefinition(1, 4, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom2_4()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "KeyLockedDoor" }, { "Right", "Wall" }, { "Bottom", "Wall" }, { "Left", "OpenDoor" } };

        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Skeleton", 7, 3),
            new EnemyDefinition("Goriya", 2, 1),
            new EnemyDefinition("Goriya", 2, 5),
            new EnemyDefinition("Goriya", 4, 1),
            new EnemyDefinition("Skeleton", 7, 5),
            new EnemyDefinition("Gel", 11, 5),
            new EnemyDefinition("Gel", 11, 1),
            new EnemyDefinition("Skeleton", 0, 6)
        };
        return new RoomDefinition(2, 4, tiles, doors, enemies);
    }

    private static RoomDefinition CreateRoom1_5()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "LeftStatue", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "RightStatue", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "BlueFloor", "BlueFloor", "SquareBlock", "SquareBlock", "SquareBlock", "SquareBlock", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "Wall" }, { "Bottom", "Wall" }, { "Left", "OpenDoor" } };

        // TODO_IMPORTANT: ADD TRIFORCE PIECE HERE
        return new RoomDefinition(1, 5, tiles, doors);
    }
=======
>>>>>>> 68585459a282252ddd9750142888515af0092881
}
