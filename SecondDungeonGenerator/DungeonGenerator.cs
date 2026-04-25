using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class DungeonGenerator
{
    private readonly TemplateLoader _templateLoader;
    private readonly GraphGenerator _graphGenerator;
    private readonly RoomTemplateAssigner _templateAssigner;
    private readonly DoorCalculator _doorCalculator;
    private readonly DungeonXMLExporter _xmlExporter;
    private readonly Random _random;

    public DungeonGenerator()
    {
        // Initialize our isolated logic blocks
        _templateLoader = new TemplateLoader();
        _graphGenerator = new GraphGenerator(gridSize: 6);
        _templateAssigner = new RoomTemplateAssigner(maxTemplateUses: 3);
        _doorCalculator = new DoorCalculator();
        _xmlExporter = new DungeonXMLExporter();
        _random = new Random();
    }

    public void Generate(string sourceXmlPath, string outputXmlPath)
    {
        // Extract Templates
        var templates = _templateLoader.LoadTemplates(sourceXmlPath);

        // Determine Room Count and Generate Layout Map
        int targetRoomCount = _random.Next(5, 37);
        var occupiedCells = _graphGenerator.Generate(targetRoomCount, startNode: (1, 0));

        // Create Room Node Objects
        List<RoomNode> dungeonRooms = new List<RoomNode>();
        foreach (var cell in occupiedCells)
        {
            dungeonRooms.Add(new RoomNode(cell.row, cell.col));
        }

        // Run through the pipeline
        _templateAssigner.Assign(dungeonRooms, templates);
        _doorCalculator.AssignDoors(dungeonRooms, occupiedCells);


      

        // 5. Save the final result
        _xmlExporter.Export(dungeonRooms, outputXmlPath);

        Debug.WriteLine("\n================ DUNGEON MAP ================");

        // 1. Print the 6x6 visual grid
        for (int r = 0; r < 6; r++)
        {
            string rowString = "";
            for (int c = 0; c < 6; c++)
            {
                // Check if a room exists at this coordinate
                var room = dungeonRooms.FirstOrDefault(node => node.Row == r && node.Col == c);

                if (room != null)
                {
                    if (r == 1 && c == 0) rowString += "[S] "; // Starting Room
                    else rowString += "[R] "; // Normal Room
                }
                else
                {
                    rowString += "[ ] "; // Empty Space
                }
            }
            Debug.WriteLine(rowString);
        }

        Debug.WriteLine("\n============= ROOM DOOR DATA =============");

        // 2. Print the exact door data to verify connections
        foreach (var room in dungeonRooms.OrderBy(n => n.Row).ThenBy(n => n.Col))
        {
            Debug.WriteLine($"Room ({room.Row}, {room.Col}) | Doors -> Top: {room.TopDoor,-4} | Bottom: {room.BottomDoor,-4} | Left: {room.LeftDoor,-4} | Right: {room.RightDoor,-4}");
        }

        Debug.WriteLine("=============================================\n");


    }
}