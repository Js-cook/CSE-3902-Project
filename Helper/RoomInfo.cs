using System.Collections.Generic;
using Enums;

// RoomInfo uses the Direction enum and DoorType enum for clarity.
public class RoomInfo
{
    public int Row { get; }
    public int Col { get; }

    // Door types keyed by Direction enum. Missing keys mean no door.
    public Dictionary<Direction, DoorType> DoorTypes { get; } = new Dictionary<Direction, DoorType>();

    public RoomInfo(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public static RoomInfo CreateFromDoors(int row, int col, Dictionary<string, string> doors)
    {
        var info = new RoomInfo(row, col);
        if (doors == null) return info;

        var directionMap = new Dictionary<string, Direction>
        {
            { "Top", Direction.UP },
            { "Right", Direction.RIGHT },
            { "Bottom", Direction.DOWN },
            { "Left", Direction.LEFT }
        };

        foreach (var kv in doors)
        {
            if (!directionMap.ContainsKey(kv.Key)) continue;
            Direction dir = directionMap[kv.Key];

            // Map door type string to DoorType enum. Default to Wall if unknown.
            DoorType dtype = kv.Value switch
            {
                "OpenDoor" => DoorType.OpenDoor,
                "KeyLockedDoor" => DoorType.KeyLockedDoor,
                "DiamondLockedDoor" => DoorType.DiamondLockedDoor,
                "BombedWall" => DoorType.BombedWall,
                _ => DoorType.Wall
            };

            info.DoorTypes[dir] = dtype;
        }

        return info;
    }
}
