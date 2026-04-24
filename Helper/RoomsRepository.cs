using Enums;
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public static class RoomsRepository
{
    private static Dictionary<(int, int), RoomDefinition> _roomsLevel1;
    private static Dictionary<(int, int), RoomDefinition> _roomsLevel2;
    private static Dictionary<(int, int), RoomDefinition> _activeRooms;
    
    private static Dictionary<(int, int), RoomInfo> _roomInfosLevel1;
    private static Dictionary<(int, int), RoomInfo> _roomInfosLevel2;
    private static Dictionary<(int, int), RoomInfo> _activeRoomInfos;

    private static DungeonLevel _currentLevel = DungeonLevel.Level1;

    static RoomsRepository()
    {
        _roomsLevel1 = new Dictionary<(int, int), RoomDefinition>();
        _roomsLevel2 = new Dictionary<(int, int), RoomDefinition>();
        _roomInfosLevel1 = new Dictionary<(int, int), RoomInfo>();
        _roomInfosLevel2 = new Dictionary<(int, int), RoomInfo>();

        // Load both dungeons at startup
        LoadDungeonFromFile("Content/RoomData.xml", _roomsLevel1, _roomInfosLevel1);
        LoadDungeonFromFile("Content/PlayableDungeon2.xml", _roomsLevel2, _roomInfosLevel2);

        // Set initial active level to Level 1
        _activeRooms = _roomsLevel1;
        _activeRoomInfos = _roomInfosLevel1;
    }

    private static void LoadDungeonFromFile(string filePath, Dictionary<(int, int), RoomDefinition> roomsDict, Dictionary<(int, int), RoomInfo> roomInfosDict)
    {
        Debug.WriteLine($"[RoomsRepository] Loading dungeon from: {filePath}");

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
                    roomsDict[(row, col)] = roomDef;

                    // Create and store RoomInfo for quick access to door types
                    var roomInfo = RoomInfo.CreateFromDoors(row, col, doors);
                    roomInfosDict[(row, col)] = roomInfo;
                }
            }
        }

        Debug.WriteLine($"[RoomsRepository] Loaded {roomsDict.Count} rooms from {filePath}");
    }

    public static void SetActiveLevel(DungeonLevel level)
    {
        Debug.WriteLine($"[RoomsRepository] Setting active level to {level}");
        _currentLevel = level;

        if (level == DungeonLevel.Level1)
        {
            _activeRooms = _roomsLevel1;
            _activeRoomInfos = _roomInfosLevel1;
        }
        else if (level == DungeonLevel.Level2)
        {
            _activeRooms = _roomsLevel2;
            _activeRoomInfos = _roomInfosLevel2;
        }
    }

    public static DungeonLevel GetCurrentLevel() => _currentLevel;

    public static RoomDefinition GetRoom(int row, int col)
    {
        return _activeRooms.TryGetValue((row, col), out var room) ? room : null;
    }

    public static RoomInfo GetRoomInfo(int row, int col)
    {
        return _activeRoomInfos.TryGetValue((row, col), out var info) ? info : null;
    }

    public static void ResetAllItemAcquiredFlags()
    {
        ResetItemAcquiredFlagsForLevel(_roomsLevel1);
        ResetItemAcquiredFlagsForLevel(_roomsLevel2);
    }

    private static void ResetItemAcquiredFlagsForLevel(Dictionary<(int, int), RoomDefinition> roomsDict)
    {
        foreach (var room in roomsDict.Values)
        {
            if (room.PickupItems != null)
            {
                foreach (var item in room.PickupItems)
                {
                    item.Acquired = false;
                }
            }
        }
    }
}
