using Enums;
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public static class RoomsRepository
{
    private static Dictionary<(int, int), RoomDefinition> _rooms;
    private static Dictionary<(int, int), RoomInfo> _roomInfos = new Dictionary<(int, int), RoomInfo>();

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

                    // Create and store RoomInfo for quick access to door types
                    var roomInfo = RoomInfo.CreateFromDoors(row, col, doors);
                    _roomInfos[(row, col)] = roomInfo;
                }
            }
        }
    }

    public static RoomDefinition GetRoom(int row, int col)
    {
        return _rooms.TryGetValue((row, col), out var room) ? room : null;
    }

    public static RoomInfo GetRoomInfo(int row, int col)
    {
        return _roomInfos.TryGetValue((row, col), out var info) ? info : null;
    }

}
