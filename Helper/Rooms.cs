using System;
using System.Collections.Generic;
public class EnemyDefinition
{
    public string Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public EnemyDefinition(string type, int x, int y)
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

    public RoomDefinition(int row, int col, string[][] tiles, Dictionary<string, string> doors, List<EnemyDefinition> enemies = null)
    {
        Row = row;
        Col = col;
        Tiles = tiles;
        Doors = doors;
        Enemies = enemies ?? new List<EnemyDefinition>();
    }
}

public static class RoomsRepository
{
    private static Dictionary<(int, int), RoomDefinition> _rooms;

    static RoomsRepository()
    {
        _rooms = new Dictionary<(int, int), RoomDefinition>
        {
            { (99, 99), CreateRoom99_99() },
            { (0, 1), CreateRoom0_1() },
            { (0, 2), CreateRoom0_2() },
            { (1, 2), CreateRoom1_2() },
            { (2, 2), CreateRoom2_2() },
            { (2, 1), CreateRoom2_1() },
            { (2, 0), CreateRoom2_0() },
            { (3, 1), CreateRoom3_1() },
            { (3, 2), CreateRoom3_2() },
            { (4, 2), CreateRoom4_2() },
            { (5, 1), CreateRoom5_1() },
            { (5, 2), CreateRoom5_2() },
            { (2, 3), CreateRoom2_3() },
            { (3, 3), CreateRoom3_3() },
            { (5, 3), CreateRoom5_3() },
            { (1, 4), CreateRoom1_4() },
            { (2, 4), CreateRoom2_4() },
            { (1, 5), CreateRoom1_5() },
        };
    }

    public static RoomDefinition GetRoom(int row, int col)
    {
        return _rooms.TryGetValue((row, col), out var room) ? room : null;
    }

    private static RoomDefinition CreateRoom99_99()
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
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "Stair", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "TreasureChest", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "Spike", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "Spike" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "KeyLockedDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };
        var enemies = new List<EnemyDefinition>
        {
            new EnemyDefinition("Gel", 0, 3),
            new EnemyDefinition("Goriya", 4, 3),
            new EnemyDefinition("Skeleton", 2, 2),
            new EnemyDefinition("Bat", 3, 3),
        };
        return new RoomDefinition(0, 1, tiles, doors, enemies);
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
            new EnemyDefinition("Aquamentus", 6, 1),
        };
        return new RoomDefinition(0, 2, tiles, doors, enemies);
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
        return new RoomDefinition(1, 2, tiles, doors);
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
        return new RoomDefinition(2, 2, tiles, doors);
    }

    private static RoomDefinition CreateRoom2_1()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "SquareBlock", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
            new string[] { "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor", "BlueFloor" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "KeyLockedDoor" }, { "Left", "DiamondLockedDoor" } };
        return new RoomDefinition(2, 1, tiles, doors);
    }

    private static RoomDefinition CreateRoom2_0()
    {
        var tiles = new string[][]
        {
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
            new string[] { "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap", "BlueGap" },
        };
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "OpenDoor" }, { "Bottom", "Wall" }, { "Left", "Wall" } };
        return new RoomDefinition(2, 0, tiles, doors);
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
        return new RoomDefinition(3, 1, tiles, doors);
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
        return new RoomDefinition(3, 2, tiles, doors);
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
        return new RoomDefinition(4, 2, tiles, doors);
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
        return new RoomDefinition(5, 1, tiles, doors);
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
        return new RoomDefinition(2, 3, tiles, doors);
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
        return new RoomDefinition(3, 3, tiles, doors);
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
        return new RoomDefinition(5, 3, tiles, doors);
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
        var doors = new Dictionary<string, string> { { "Top", "Wall" }, { "Right", "DiamondLockedDoor" }, { "Bottom", "KeyLockedDoor" }, { "Left", "Wall" } };
        return new RoomDefinition(1, 4, tiles, doors);
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
        return new RoomDefinition(2, 4, tiles, doors);
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
        return new RoomDefinition(1, 5, tiles, doors);
    }
}
